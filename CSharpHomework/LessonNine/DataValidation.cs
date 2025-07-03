using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class AuthenticationSystem
{
    
    public class UserNameNotAcceptableException : Exception
    {
        public UserNameNotAcceptableException() : base("Username cannot be empty.") { }
    }

    public class PasswordTooShortException : Exception
    {
        public PasswordTooShortException() : base("Password is too short. It must be at least 8 characters long.") { }
    }

    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException() : base("Password must contain at least one uppercase letter, one lowercase letter, and one number.") { }
    }

    public class InvalidCredentialException : Exception
    {
        public InvalidCredentialException() : base("Invalid username or password.") { }
    }

    private static readonly Dictionary<string, string> ValidCredentials = new Dictionary<string, string>
    {
        { "admin", "Admin123" },
        { "user1", "UserPass456" },
        { "testuser", "Test@789" }
    };

    public static void Execute()
    {
        Console.WriteLine(" Authentication System ");

        Console.Write("Enter username: ");
        string? usernameInput = Console.ReadLine();
        string username = usernameInput ?? string.Empty;

        string password;
        bool passwordIsValid = false;

        do
        {
            Console.Write("Enter password: ");
            string? passwordInput = Console.ReadLine();
            password = passwordInput ?? string.Empty;

            try
            {
                
                ValidatePasswordCriteria(password);
                passwordIsValid = true; 
            }
            catch (PasswordTooShortException ex)
            {
                Console.WriteLine($"\nPassword validation failed: {ex.Message}");
                Console.WriteLine("Please try again.");
            }
            catch (InvalidPasswordException ex)
            {
                Console.WriteLine($"\nPassword validation failed: {ex.Message}");
                Console.WriteLine("Please try again.");
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"\nAn unexpected error occurred during password input: {ex.Message}");
                Console.WriteLine("Please try again.");
            }

        } while (!passwordIsValid); 

        try
        {
            
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new UserNameNotAcceptableException();
            }

            AuthenticateCredentials(username, password);
            Console.WriteLine("\nAuthentication successful!");
        }
        catch (UserNameNotAcceptableException ex)
        {
            Console.WriteLine($"\nAuthentication failed: {ex.Message}");
        }
        catch (InvalidCredentialException ex)
        {
            Console.WriteLine($"\nAuthentication failed: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn unexpected error occurred during final authentication: {ex.Message}");
        }

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }

    public static void ValidatePasswordCriteria(string password)
    {
        
        if (password.Length < 8)
        {
            throw new PasswordTooShortException();
        }

        bool hasUppercase = Regex.IsMatch(password, "[A-Z]");
        bool hasLowercase = Regex.IsMatch(password, "[a-z]");
        bool hasNumber = Regex.IsMatch(password, "[0-9]");

        if (!hasUppercase || !hasLowercase || !hasNumber)
        {
            throw new InvalidPasswordException();
        }
    }

    public static void AuthenticateCredentials(string username, string password)
    {
        if (ValidCredentials.TryGetValue(username, out string? storedPassword))
        {
            if (storedPassword != password)
            {
                throw new InvalidCredentialException();
            }
        }
        else 
        {
            throw new InvalidCredentialException();
        }
    }
}