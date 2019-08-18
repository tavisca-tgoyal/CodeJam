using System;
using System.Collections.Generic;

namespace StringPermutation
{
    class Program
    {
        string s = "abc";
        static void Main(string[] args)
        {
            int lengthOfString = 11;
            
            int i = 0;
            foreach(string str in GiveString(lengthOfString))
            {
                Console.WriteLine(str);
                i++;
            }
            Console.WriteLine(i);
            Console.Read();
        }

        private static IEnumerable<string> GiveString(int lengthOfString)
        {
            if (lengthOfString == 0) return null;
            if (lengthOfString == 1)
                return new List<string>() { "a","b","c"};

            List<string> temp = new List<string>();
            temp.AddRange(getConcatenatedStringswithCharacter('a',lengthOfString));
            temp.AddRange(getConcatenatedStringswithCharacter('b', lengthOfString));
            temp.AddRange(getConcatenatedStringswithCharacter('c', lengthOfString));

            return temp;
            
        }

        private static IEnumerable<string> getConcatenatedStringswithCharacter(char sym, int lengthOfString)
        {
            List<string> temp = new List<string>();
            foreach(string str in GiveString(lengthOfString - 1))
            {
                temp.Add(sym + "" + str);
            }
            return temp;
        }
    }
}
