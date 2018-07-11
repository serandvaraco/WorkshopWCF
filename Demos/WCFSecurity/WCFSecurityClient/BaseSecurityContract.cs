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

    }
}
