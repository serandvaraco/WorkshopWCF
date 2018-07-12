using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WCFSecurity;

namespace WCFSecurityClient
{
    public class TokenSecurityModel
    {
        public Guid id { get; set; }
        public DateTime Expiration { get; set; }
        public string[] Roles { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
    }

    class BaseSecurityContract
    {
        private HttpClient http;
        public BaseSecurityContract()
        {
            http = new HttpClient();
            http.BaseAddress = new Uri("http://localhost:51420/SecurityService.svc/");
        }
        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        private async Task<string> GetTokenAsync(string username, string password)
        {
            try
            {
                var result = await http.PostAsJsonAsync("GetToken", new { username, password });
                if (!result.IsSuccessStatusCode)
                    return null;
                return await result.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Gets the token user asynchronous.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> GetTokenUserAsync(string username, string password)
        {
            try
            {
                var common = new Common();
                var key = ConfigurationManager.AppSettings["KEY"];
                var passwordHash = common.Encrypt(password, key);
                var tokenJSON = await GetTokenAsync(username, passwordHash);
                var tokenHash = JsonConvert.DeserializeAnonymousType(tokenJSON,
                    new { GetTokenResult = "" });

                return tokenHash.GetTokenResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Sends the request URI HTTP.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="token">The token.</param>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task<string> SendRequestUriHttp<T>(string token, string requestUri, T obj)
        {
            try
            {
                http.DefaultRequestHeaders.Add("__TOKEN_SECURITY__", token);
                HttpResponseMessage result;
                if (obj == null)
                    result = await http.PostAsync(requestUri, null);
                else
                    result = await http.PostAsJsonAsync(requestUri, obj);


                if (!result.IsSuccessStatusCode)
                    return null;
                return await result.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// Sends the request URI put HTTP.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="token">The token.</param>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task<string> SendRequestUriPutHttp<T>(string token, string requestUri, T obj)
        {
            try
            {
                http.DefaultRequestHeaders.Add("__TOKEN_SECURITY__", token);
                HttpResponseMessage result;
                result = await http.PutAsJsonAsync(requestUri, obj);

                if (!result.IsSuccessStatusCode)
                    return null;
                return await result.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<UserModel> GetUser(string token)
        {
            try
            {
                var responseModelJson = await SendRequestUriHttp(token, "getuser", new { });
                var responseModel = JsonConvert.DeserializeObject<ResultModel>(responseModelJson);

                if (responseModel.GetUserResult.IsError)
                {
                    throw new Exception(responseModel.GetUserResult.Message, responseModel.GetUserResult.Exception);
                }

                var userModel = JsonConvert.DeserializeObject<UserModel>(responseModel.GetUserResult.Message);

                return userModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public async Task<ResultModel> CreateUser(string token, string username, string password)
        {
            var passwordhash = new Common().Encrypt(password, ConfigurationManager.AppSettings["KEY"]);
            var responseModelJson = await SendRequestUriHttp(token, "create", new { username, password = passwordhash });
            return JsonConvert.DeserializeObject<ResultModel>(responseModelJson);
        }
        /// <summary>
        /// Updates the password.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="username">The username.</param>
        /// <param name="actualpassword">The actualpassword.</param>
        /// <param name="newpassword">The newpassword.</param>
        /// <returns></returns>
        public async Task<ResultModel> UpdatePassword(string token, string username, string actualpassword, string newpassword)
        {
            var common = new Common();
            var key = ConfigurationManager.AppSettings["KEY"];
            var actualpasswordhash = common.Encrypt(actualpassword, key);
            var newpasswordhash = common.Encrypt(newpassword, key);

            var responseModelJson = await SendRequestUriPutHttp(token, "changepassword", new
            {
                username,
                actualpassword = actualpasswordhash,
                newpassword = newpasswordhash
            });

            return JsonConvert.DeserializeObject<ResultModel>(responseModelJson);
        }
        /// <summary>
        /// Creates the role.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="username">The username.</param>
        /// <param name="rolename">The rolename.</param>
        /// <returns></returns>
        public async Task<ResultModel> CreateRole(string token, string username, string rolename)
        {
            var responseModelJson = await SendRequestUriHttp(token, "createrole", new { username, role = rolename });
            return JsonConvert.DeserializeObject<ResultModel>(responseModelJson);
        }
    }
}
