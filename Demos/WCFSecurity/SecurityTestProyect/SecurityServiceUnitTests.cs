using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCFSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFSecurity.Tests
{
    [TestClass()]
    public class SecurityServiceUnitTests
    {

        SecurityService security = new SecurityService();

        [TestMethod()]
        public void GetTokenTest()
        {
            var token = security.GetToken("svargas", "Abc123..");
            System.Diagnostics.Debug.WriteLine(token);

            Assert.IsTrue(!string.IsNullOrEmpty(token));

        }
    }
}