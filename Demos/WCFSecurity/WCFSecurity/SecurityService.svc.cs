using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace WCFSecurity
{
    public class SecurityService : Security
    {

        DbSecurityEntities db = new DbSecurityEntities();

        public ResponseModel AddRole(string username, string role)
        {
            throw new NotImplementedException();
        }

        public ResponseModel changePassword(string username, string actualPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public ResponseModel CreateUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        const string key = "BeX30vkH8iy5ZMEzGG0qmw==";
        public string GetToken(string username, string password)
        {

            var common = new Common();
            var passwordResult = common.Decrypt(password, key);

            var user = db.User.FirstOrDefault(x => x.Username == username
                       && password == common.GenerateSHA256(passwordResult));

            if (user == null)
                return "Credenciales no validas";

            //Obtener los nombre de los roles autorizados por el usuario
            var roles = db.UsersInRoles.Where(x => x.User.UserId == user.UserId)
                        .Select(x => x.Role.Name).ToArray();

            //se establece la entidad del token con un tiempo de expiración fijo de 1 minuto

            var token = new TokenSecurityModel
            {
                DisplayName = string.Concat("Mr ", user.Username),
                Expiration = DateTime.Now.AddMinutes(1),
                Username = user.Username,
                Roles = roles
            };


            //Se serializa a formato JSON (Javascript Serialization Object Notation) el token
            /*
             *  {
             *      'DisplayName': 'Mr svargas',
             *      'Expiration' : '1246843218798654', // UTC del Fecha y Hora 
             *      'Username': 'svargas'
             *      'Roles': [{'admin', 'sadmin', 'operador'}]
             *  }
             */
            var tokenString = JsonConvert.SerializeObject(token);
            //Se cifra y se codifica a UTF 8 el resultado obteniendo los bytes de la codificación 
            var tokenBytes = Encoding.UTF8.GetBytes(common.Encrypt(tokenString, key));
            //Se retorna la codificación a Base64 para su transporte por HTTP
            return Convert.ToBase64String(tokenBytes);
        }
    }
}
