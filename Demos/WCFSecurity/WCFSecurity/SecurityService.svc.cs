using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

using System.Security.Claims;
using System.Security.Permissions;

namespace WCFSecurity
{
    public class SecurityService : Security
    {

        DbSecurityEntities db = new DbSecurityEntities();

        /// <summary>
        /// Adds the role.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ResponseModel AddRole(string username, string role)
        {
            //TODO: super adminsitrador
            throw new NotImplementedException();
        }
        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="actualPassword">The actual password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ResponseModel changePassword(string username, string actualPassword, string newPassword)
        {
            //TODO: invitado, operador, consulta
            throw new NotImplementedException();
        }


        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public ResponseModel CreateUser(string username, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username))
                    throw new ArgumentNullException("username");

                if (string.IsNullOrWhiteSpace(password))
                    throw new ArgumentNullException("password");

                TokenSecurityModel token = ValidateToken();
                if (!token.Roles.Any(x => x == "admin"))
                    throw new Exception("No tiene permisos");


                //Validar que no exista el usuario, 

                if (db.User.Any(x => x.Username == username))
                    return new ResponseModel { Message = "Usuario Existente" };

                //El parámetro password llega encryptado con el algoritmo Rindjael
                var common = new Common();
                var passwordResult = common.Decrypt(password, key);
                var passwordSHA256 = common.GenerateSHA256(passwordResult);

                db.User.Add(new User
                {
                    DateCreate = DateTime.Now,
                    DateUpdate = DateTime.Now,
                    FailedAttempts = 0,
                    Username = username,
                    Password = passwordSHA256,
                    UserId = Guid.NewGuid()
                });

                db.SaveChanges();

                return new ResponseModel { Message = "Usuario agregado con exito" };
            }
            catch (Exception ex)
            {
                return new ResponseModel { Message = ex.Message, Exception = ex };
            }
        }

        public TokenSecurityModel ValidateToken()
        {
            //HttpContext.Current.Request["__TOKEN_SECURITY__"];
            var requestToken = "SjZiTGtRdEk1VUNKbG9yVmpBOW44VHR2OWVleFFrNXhFUWVTNzhVRk5mYjlvRDB6ZHhuc2xFM3NIbm1VckVjbFlKb1JFV0xTQ0I2ekc4UC9TRGJGTmxZNE1ucUlrUmVzMi9PVmgzbFpIak5sMjYrYkdIU2xuakdVVGJCazFxa1VMUENaQktzZXVUVDZoU0lYMTdXUktYV2N1VlFWYW95Z08rZlpyWkovdWxtWS90S0g0T20wK2tpb1oxZU85Rlo1aVJRN1R2bmRIYlVJK2VsR0VPODhKaWtjcWtROVU3MGcvK1BsSFZGUytTND0=";

            if (string.IsNullOrEmpty(requestToken))
                throw new Exception("Token Invalido");

            //Obtiene los bytes desde el base64 generado en el token 
            byte[] TokenBytes = Convert.FromBase64String(requestToken);
            //obtengo la codificación UTF8 del token
            string TokenUTF8Hash = Encoding.UTF8.GetString(TokenBytes);
            //se obtiene el Json de la codificación 
            string tokenJSON = new Common().Decrypt(TokenUTF8Hash, key);

            //se obtiene el TOKEN 
            TokenSecurityModel tokenSecurityModel =
                JsonConvert.DeserializeObject<TokenSecurityModel>(tokenJSON);

            if (tokenSecurityModel == null)
                throw new Exception("Token Invalido");

            if (tokenSecurityModel.Expiration <= DateTime.Now)
                throw new Exception("Token Expirado");

            //se obtiene el token con la información genrada
            return tokenSecurityModel;
        }

        const string key = "BeX30vkH8iy5ZMEzGG0qmw==";
        public string GetToken(string username, string password)
        {
            var common = new Common();
            var passwordResult = common.Decrypt(password, key);
            var passwordSHA256 = common.GenerateSHA256(passwordResult);
            var user = db.User.FirstOrDefault(x => x.Username == username && x.Password == passwordSHA256);
            if (user == null)
                return "Credenciales no validas";
            //Obtener los nombre de los roles autorizados por el usuario
            var roles = db.UsersInRoles.Where(x => x.User.UserId == user.UserId)
                        .Select(x => x.Role.Name).ToArray();
            //se establece la entidad del token con un tiempo de expiración fijo de 1 minuto
            var token = new TokenSecurityModel
            {
                DisplayName = string.Concat("Mr ", user.Username),
                Expiration = DateTime.Now.AddHours(1),
                Username = user.Username,
                Roles = roles,
                id = Guid.NewGuid()
            };
            #region Comments
            //Se serializa a formato JSON (Javascript Serialization Object Notation) el token
            /*
             *  {
             *      'DisplayName': 'Mr svargas',
             *      'Expiration' : '1246843218798654', // UTC del Fecha y Hora 
             *      'Username': 'svargas'
             *      'Roles': [{'admin', 'sadmin', 'operador'}]
             *  }
             */
            #endregion 
            var tokenString = JsonConvert.SerializeObject(token);
            //Se cifra y se codifica a UTF 8 el resultado obteniendo los bytes de la codificación 
            var tokenBytes = Encoding.UTF8.GetBytes(common.Encrypt(tokenString, key));
            //Se retorna la codificación a Base64 para su transporte por HTTP
            return Convert.ToBase64String(tokenBytes);
        }
    }
}
