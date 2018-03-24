using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.StringConverterLibrary
{
    public static class StringConverter
    {
        public static int ToInt (this string str)
        {
            if (String.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException($"{nameof(str)} is null, empty or whitespace");
            }

            int result = 0, sign, startPosition;

            startPosition = ProcessFirstSymbol(str[0],out sign);

            try
            {
                checked
                {
                    foreach(char x in str.Substring(startPosition))
                    {
                        result = result * 10;
                        result += GetNumber(x) * sign;
                    }
                }
            }
            catch(OverflowException ex)
            {
                throw new OverflowException($"{str} is too big and cannot be stored in int type", ex);
            }

            return result;
        }

        // Here is used '0' to cut all the characters except 0 to 9.
        private static int GetNumber(char charNumber)
        {
            int value = charNumber - '0';
            if (value < 0 || value > 9)
            {
                throw new FormatException($"The {charNumber.GetType()} value '{charNumber}' is not in a recognizable format.");
            }

            return value;
        }


        // Checks the first character entered. If a string begins with a number, it returns the starting position 0, 
        // otherwise the starting position 1. Also the method returns sign of a number in out paramether.
        private static int ProcessFirstSymbol(char firstSymbol, out int sign)
        {
            if (firstSymbol == '-')
            {
                sign = -1;
                return 1;
            }
            if (firstSymbol == '+')
            {
                sign = 1;
                return 1;
            }

            sign = 1;
            return 0;
        }
    }
}
