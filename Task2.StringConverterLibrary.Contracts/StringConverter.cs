using System;
using System.Diagnostics.Contracts;


namespace Task2.StringConverterLibrary.Contracts
{
    public static class StringConverter
    {
        public static int ToInt(this string str)
        {
            Contract.Requires<ArgumentException>(!String.IsNullOrWhiteSpace(str), "The string is null, empty or whitespace");
            Contract.Ensures(Contract.Result<int>() >= int.MinValue, "The number in string is too small and cannot be stored in int type");
            Contract.Ensures(Contract.Result<int>() <= int.MaxValue, "The number in string is too big and cannot be stored in int type");

            int result = 0, sign, startPosition;
            startPosition = ProcessFirstSymbol(str[0], out sign);

            foreach (char x in str.Substring(startPosition))
            {
                result = result * 10;
                result += GetNumber(x) * sign;
            }
 
            return result;
        }

        // Here is used '0' to cut all the characters except 0 to 9.
        private static int GetNumber(char charNumber)
        {
            Contract.Ensures(Contract.Result<int>() >= 0 && Contract.Result<int>() <= 9, $"The 'charNumber' is not in a recognizable format.");
            int value = charNumber - '0';
           
            return value;
        }


        // Checks the first character entered. If a string begins with a number, it returns the starting position 0, 
        // otherwise the starting position 1. Also the method returns sign of a number in out paramether.
        private static int ProcessFirstSymbol(char firstSymbol, out int sign)
        {
            Contract.Ensures(Contract.Result<int>() == 0 || Contract.Result<int>() == 1);
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
