using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logic
{
    public class Validator
    {
        private bool isName, isAddress, isPhone;

        public bool Helper(string name, string address, string phone)
        {
            isName = IsValidName(name);
            isAddress = IsValidAddress(address);
            isPhone = IsValidPhone(phone);
            return isName && isAddress && isPhone;
        }

        private bool IsValidName(string name)
        {
            string nameField = "[A-Za-z]+";
            string spaceField = @"\s";
            string pattern = "^(" + nameField + spaceField + "*)+$";
            return Regex.IsMatch(name, pattern);
            // return Regex.IsMatch(name, @"^([A-Za-z]+\s*)+$");
        }

        private bool IsValidPhone(string phone)
        {
            string fourNumber = @"\d{4}-";
            string threeNumber = @"\d{3}";
            string pattern = "^(" + fourNumber + fourNumber + threeNumber + ")+$";
            return Regex.IsMatch(phone, pattern);
            //return Regex.IsMatch(phone, @"^(\d{4}-\d{4}-\d{3})+$");
        }

        // TODO
        private bool IsValidAddress(string address)
        {
            //string address = "[A-Za-z0-9]*";
            string zipCode = @"\d{4}\s";
            string city = @"[A-Za-z]+\s";
            string street = @"[A-Za-z]+\s[A-Za-z0-9]+\s[A-Za-z0-9]+";
            string pattern = "^(" + zipCode + city + street + ")+$";
            return Regex.IsMatch(address, pattern);
            //return Regex.IsMatch(email, @"^([A-Za-z0-9]*\@[a-z]{1,20}\.[a-z]{1,20})+$");
        }

        public override string ToString()
        {
            return string.Format("Name: {0}\nAddress: {1}\nPhone: {2}", isName, isAddress, isPhone);
        }

    }
}
