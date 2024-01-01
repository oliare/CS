using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("\tAccount >>>");
                //string email = "some@gmail";
                //string pass = "somepass111";

                //bool isEmail = Account.validEmail(email);
                //bool isPass = Account.validPassword(pass);

                //if (isEmail && isPass)
                //{
                //    Console.WriteLine("Valid email: " + email);
                //    Console.WriteLine("Valid password: " + pass);
                //}
                //else
                //{
                //    Console.WriteLine("Invalid input ...");
                //}
                Account account = new Account();

                string email = account.getEmail();
                account.Email = email;

                string password = account.getPassword();
                account.Password = password;

                Console.WriteLine($"\ne-mail   >> {account.Email}");
                Console.WriteLine($"password >> {account.Password}");
                Console.WriteLine("\n");

                // task 3
                CreditCard card = new CreditCard()
                {
                    Name = "test",
                    Number = "1234 5678 5901 5112",
                    ExpDate = new DateTime(2024, 2, 2),
                    CVV = "354"
                };
                Console.WriteLine("\tCredit Card >>>");
                Console.WriteLine(card);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
