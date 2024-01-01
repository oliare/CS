using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_practice
{
    internal class Account
    {
        private string email;
        private string password;
        public string Email
        {
            get => email;
            set
            {
                if (!validEmail(value))
                {
                    throw new Exception("! invalid email");
                }
                email = value;
            }
        }
        public string Password
        {
            get => password;
            set
            {
                if (!validPassword(value))
                {
                    throw new Exception("! invalid password");
                }
                password = value;
            }
        }

        public static bool validEmail(string email)
        {
            if (email.Length < 4 || email.Length > 50 || string.IsNullOrEmpty(email))
            {
                return false;
            }
            var hasOneAt = email.Where(x => x == '@').Count() == 1;
            if (!hasOneAt)
            {
                return false;
            }
            var hasCorrectSymbols = email
                .Where(x => char.IsLetterOrDigit(x) || x == '_' || x == '@')
                .Count() == email.Length;

            return hasCorrectSymbols;
        }
        public static bool validPassword(string password)
        {
            if (password.Length < 6 || string.IsNullOrEmpty(password))
            {
                return false;
            }

            bool digit = false, letter = false;
            foreach (char s in password)
            {
                if (char.IsDigit(s))
                {
                    digit = true;
                }
                else if (char.IsLetter(s))
                {
                    letter = true;
                }
            }
            return letter && digit;
        }
        // інтерфейс для вводу даних 
        private static string inputData(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }
        public string getEmail()
        {
            string email;
            while (true)
            {
                email = inputData("Enter e-mail: ");
                if (validEmail(email))
                {
                    break;
                }
                Console.WriteLine("! invalid email ...");
                Console.WriteLine();
            }
            return email;
        }
        public string getPassword()
        {
            string password;
            while (true)
            {
                password = inputData("Enter password: ");
                if (validPassword(password))
                {
                    break;
                }
                Console.WriteLine("! invalid password ...");
                Console.WriteLine();
            }
            return password;
        }

    }
}




