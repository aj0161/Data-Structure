using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ReverseWordinaPhrase
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Program.reverseWord("abcde name is ajay"));
            Console.WriteLine(   IsStringIsomorphic("paper", "title"));
           
        }

        static string reverseWord(string input)
        {
            var words = input.Split(' ');
            StringBuilder reverseWord = new StringBuilder();
            
            foreach (var word in words)
            {
                var theWord = word.ToCharArray();
                for (int i = theWord.Length - 1; i >= 0; i--)
                {
                    reverseWord.Append(theWord[i]);
                }
                reverseWord.Append(" ");

            }
            return reverseWord.ToString();
        }

        private static bool IsStringIsomorphic(String first, string second)
        {
            if (first == null || second == null)
                return false;

            if (first.Length != second.Length)
                return false;

            bool isIsomoorphic = false;
            Dictionary<char, char> HT = new Dictionary<char, char>();

            for (int i = 0; i < first.Length; i++)
            {
                if (HT.ContainsKey(first[i]))
                {
                    if  (HT[first[i]].Equals(second[i]))
                    {
                        isIsomoorphic = true;
                    }
                    else
                        return false;
                }
                else
                    HT.Add(first[i], second[i]); //add it
            }

            return isIsomoorphic;

        }
    }

    
}
