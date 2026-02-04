using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopCustomerData
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public bool Validate()
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(Email) &&
                   Age < 0 && Age > 120;
        }

        public bool ValidateWithTryParse()
        {
            if (string.IsNullOrWhiteSpace(Name)) 
            {
                Console.WriteLine();
                return false; 
            }
            else if (string.IsNullOrWhiteSpace(Email)) 
            { 
                return false; 
            }
            else if (Age < 0 || Age > 120) 
            { 
                return false; 
            }

            return true;
        }
    }
}
