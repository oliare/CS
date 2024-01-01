using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_practice
{
    internal class CreditCard
    {
        private string name;
        private string number;
        private DateTime expDate;
        private string cvv;
        public string Name
        {
            get => name;
            set
            {
                if (!isValidName(value))
                {
                    throw new Exception("! invalid card name");
                }
                name = value;
            }
        }
        public string Number
        {
            get => number;
            set
            {
                if (!isValidNumber(value))
                {
                    throw new Exception("! invalid card number");
                }
                number = value;
            }
        }
        public DateTime ExpDate
        {
            get => expDate;
            set
            {
                if (value < DateTime.Now)
                {
                    throw new Exception("! card is outdated");
                }
                expDate = value;
            }
        }
        public string CVV
        {
            get => cvv;
            set
            {
                if (value.Length != 3 
                  || value.Where(x => char.IsDigit(x)).Count() != 3)
                {

                    throw new Exception("! invalid card CVV");
                }
                cvv = value;
            }
        }
        public bool isValidName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            return true;
        }
        public bool isValidNumber(string number)
        {
            int numberLen = 16;
            if (string.IsNullOrEmpty(number)
                || number.Where(x => x != ' ').Count() != numberLen)
            {
                return false;
            }
            return true;
        }
        public override string ToString()
        {
            return $"Name: {name}\nNumber: {number}" +
                $"\nExpiration Date: {expDate.ToString("yyyy/MM/dd")}\nCVV: {cvv}";
        }

    }
}
