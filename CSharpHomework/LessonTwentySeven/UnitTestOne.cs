namespace LessonTwentySeven
{
    public class StringValidator
    {
        public static bool IsValidEmail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }

        public static bool IsPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Length == 10 && phoneNumber.All(char.IsDigit);
        }
    }



    public class StringUtils
    {
        public string Reverse(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }


        public bool IsPalindrome(string input)
        {
            string cleanedInput = input.ToLower().Replace(" ", "");
            string reversedInput = Reverse(cleanedInput);
            return cleanedInput == reversedInput;
        }
    }
}
