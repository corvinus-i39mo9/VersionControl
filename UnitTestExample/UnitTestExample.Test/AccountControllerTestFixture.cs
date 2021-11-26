using NUnit.Framework;
using System;
using System.Activities;
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


        [
    Test,
    TestCase("emese.orban@uni-corvinus", "abcd"),
    TestCase("emese.orban.uni-corvinus.hu", "ABCdef123"),
    TestCase("emese.orban@uni-corvinus.hu", "abcd2566"),
    TestCase("emese.orban@uni-corvinus.hu", "ABCD1234"),
    TestCase("emese.orban@uni-corvinus.hu", "abcdABCD"),
    TestCase("emese.orban@uni-corvinus.hu", "Ab1234"),
]
        public void TestRegisterValidateException(string email, string password)
        {
            // Arrange
            var accountController = new AccountController();

            // Act
            try
            {
                var actualResult = accountController.Register(email, password);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOf<ValidationException>(ex);
            }

            // Assert
        }
    }
}
