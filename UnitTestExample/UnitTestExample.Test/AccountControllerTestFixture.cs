using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Controllers;

namespace UnitTestExample.Test
{
    public class AccountControllerTestFixture
    {
        [
            Test,
            TestCase("abcd1234", false),
            TestCase("irf@uni-corvinus", false),
            TestCase("irf.uni-corvinus.hu", false),
            TestCase("irf@uni-corvinus.hu", true)
            ]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            // Arrange
            var accountController = new AccountController();

            // Act
            var actualResult = accountController.ValidateEmail(email);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }


        [
            Test,
            TestCase("abCdEfgh", false),
            TestCase("ABC2EFGH", false),
            TestCase("abcde123", false),
            TestCase("jelszo", false),
            TestCase("jelszó12", false),
            TestCase("A1b2C3d4", true),
            ]
        public void TestValidatePW(string pw, bool expectedResult)
        {
            // Arrange
            var accountController = new AccountController();

            // Act
            var actualResult = accountController.ValidatePassword(pw);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }


        [
    Test,
    TestCase("emese.orban@uni-corvinus.hu", "AbCd1234"),
    TestCase("emese.orban@uni-corvinus.hu", "1A2b3C4d5E"),
]
        public void TestRegisterHappyPath(string email, string pw)
        {
            // Arrange
            var accountController = new AccountController();

            // Act
            var actualResult = accountController.Register(email, pw);

            // Assert
            Assert.AreEqual(email, actualResult.Email);
            Assert.AreEqual(pw, actualResult.Password);
            Assert.AreNotEqual(Guid.Empty, actualResult.ID);
        }
    }
}
