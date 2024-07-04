using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab1_ConnectedMode.VALIDATION
{
    public class Validators
    {
        public static bool isValidId(string input)
        {
            if(!Regex.IsMatch(input, @"^\d{4}$"))
            {
                return false;
            }

            return true;
        }

        public static bool isValidId(string input, int size)
        {
            if(!Regex.IsMatch(input, @"^\d{" + size + "}$"))
            {
                return false;
            }

            return true;
        }

        public static bool isValidName(string input)
        {
            if(input.Length == 0)
            {
                return false;
            }

            for(int i = 0; i < input.Length; i++)
            {
                if (!(char.IsLetter(input[i])) && !(!char.IsWhiteSpace(input[i]))) 
                {
                    return false;

                }
            }

            return true;
        }
    }
}
