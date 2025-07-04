namespace LessonTwentySevenXunitOne
{
    using LessonTwentySeven;
    using Xunit;

    
        public class StringValidatorTests
        {
            [Theory]
            [InlineData("petre@xstar.com", true)]
            [InlineData("petre.marinescu@xstar.co", true)]
            [InlineData("petremarinescu.com", false)]
            [InlineData("petre@com", false)]
            public void IsValidEmail_ShouldReturnExpectedResult(string email, bool expected)
            {
                var result = StringValidator.IsValidEmail(email);
                Assert.Equal(expected, result);
            }

            [Theory]
            [InlineData("1234567890", true)]
            [InlineData("987654321", false)]
            [InlineData("abcdefghij", false)]
            [InlineData("12345abcde", false)]
            public void IsPhoneNumber_ShouldReturnExpectedResult(string phoneNumber, bool expected)
            {
                var result = StringValidator.IsPhoneNumber(phoneNumber);
                Assert.Equal(expected, result);
            }
        }

        public class StringUtilsTests
        {
            private readonly StringUtils _utils = new();

            [Theory]
            [InlineData("hello", "olleh")]
            [InlineData("12345", "54321")]
            [InlineData("a", "a")]
            [InlineData("", "")]
            public void Reverse_ShouldReturnReversedString(string input, string expected)
            {
                var result = _utils.Reverse(input);
                Assert.Equal(expected, result);
            }

            [Theory]
            [InlineData("Racecar", true)]
            [InlineData("Never Odd Or Even", true)]
            [InlineData("Hello", false)]
            [InlineData("Was it a car or a cat I saw", true)]
            public void IsPalindrome_ShouldReturnExpectedResult(string input, bool expected)
            {
                var result = _utils.IsPalindrome(input);
                Assert.Equal(expected, result);
            }
        }
    
}