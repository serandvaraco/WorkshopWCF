using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace WCFSecurity.Tests
{
    [TestClass()]
    public class CommonUnitTests
    {

        WCFSecurity.Common common = new Common();

        [TestMethod()]
        public void GenerateSHA256Test()
        {
            var hash = common.GenerateSHA256("ABC123..");
            Debug.WriteLine(hash);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(hash));
        }

        [TestMethod()]
        public void GenerateKeyTest()
        {
            var key = common.GenerateKey();
            Debug.WriteLine(key);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(key));
        }

        [TestMethod()]
        public void EncryptTest()
        {
            var encrypted = common.Encrypt("Este es un mensaje de prueba", "SdwAqXg2YLzhvZeo/RbhgA==");
            Debug.WriteLine(encrypted);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(encrypted));
        }

        [TestMethod()]
        public void DecriptTest()
        {
            var decrypted = common.Decript("812UfOqM55MW4pvzHD+UHMkVzNtqHERQqFNDt2MdCug=", "SdwAqXg2YLzhvZeo/RbhgA==");
            Debug.WriteLine(decrypted);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(decrypted));
        }
    }
}