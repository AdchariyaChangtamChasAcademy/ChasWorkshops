using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopTDD
{
    public class EmailValidator
    {
        public bool IsValid(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            if (email.EndsWith("@gmail.com") ||
                email.EndsWith("@gmail.se") ||
                email.EndsWith("@hotmail.com") ||
                email.EndsWith("@hotmail.se"))
            {
                return true;
            }

            return false;
        }
    }
}
