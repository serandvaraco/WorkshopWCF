using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCFSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WCFSecurity.Tests
{
    [TestClass()]
    public class SecurityServiceUnitTests
    {

        SecurityService security = new SecurityService();

        [TestMethod()]
        public void GetTokenTest()
        {
            var passwordHash =
                new Common().Encrypt("ABC123..", "BeX30vkH8iy5ZMEzGG0qmw==");

            var token = security.GetToken("svargas", passwordHash);
            System.Diagnostics.Debug.WriteLine(token);

            Assert.IsTrue(!string.IsNullOrEmpty(token));

        }

        [TestMethod()]
        public void ValidateTokenTest()
        {
            try
            {
                TokenSecurityModel token =
                    security.ValidateToken();
                Assert.IsNotNull(token);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod()]
        public void CreateUserTest()
        {
            var passwordHash =
               new Common().Encrypt("ABC123..", "BeX30vkH8iy5ZMEzGG0qmw==");

            ResponseModel response = security.CreateUser("evargas", passwordHash);

            if (response.IsError)
                Assert.Fail(response.Message);

            Assert.IsTrue(true, response.Message);

        }
    }
}