using System;
using Xunit;

namespace PasswordApp.Tests
{
    public class PasswordTests
    {
        [Fact]
        public void Validate_GivenLongerThan8Chars_ReturnsTrue()
        {
            var testTarget = new DefaultPasswordValidator();
            var password = MakePassword(7) + "A";
            var validationResult = testTarget.Validate(password);

            Assert.True(validationResult);
        }

        [Fact]
        public void Validate_GivenShorterThan8Chars_ReturnsFalse()
        {
            var testTarget = new DefaultPasswordValidator();
            var password = MakePassword(7);
            var validationResult = testTarget.Validate(password);

            Assert.False(validationResult);
        }

        [Fact]
        public void Validate_GivenNoUpperCase_ReturnFalse()
        {
            var testTarget = new DefaultPasswordValidator();
            var password = MakePassword(8); // all lower case
            var validationResult = testTarget.Validate(password);

            Assert.False(validationResult);
        }

        [Fact]
        public void Validate_GivenUpperCase_ReturnTrue()
        {
            var testTarget = new DefaultPasswordValidator();
            var password = "Abcd1234"; // at least one upper case
            var validationResult = testTarget.Validate(password);

            Assert.True(validationResult);
        }

        private string MakePassword(int length)
        {
            string result = "";
            for (int i = 1; i <= length; i++)
            {
                result += "a";
            }

            return result;
        }
    }
}
