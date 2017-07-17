using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationOfAString
{
    class Program
    {
        static void Main(string[] args)
        {
 
            string str = "abc";
           // Combination(str, 3);
            Permutate("man".ToCharArray(), 0, 3);
        }


        static void Combination(string letters, int length , string prefix = "")
        {
            if (length == 0)
            {
                // We have a permutation so print it
                Console.WriteLine(prefix);
                return;
            }
            for (int i = 0; i < letters.Length; i++)
            {
                var newPrefix = prefix + letters[i];
                Combination(letters, length - 1, newPrefix);
            }
        }


        //swap
        private static void Swap(ref char left, ref char right)
        {
            var temp = left;
            left = right;
            right = temp;
        }

        static void Permutate(char[] str, int startIndex, int EndIndex)
        {
            if (startIndex == EndIndex)
            {
                Console.WriteLine( str);
                return;
            }
            else
            {
                for (int i = startIndex; i < EndIndex; i++)
                {
                    Swap( ref str[i], ref str[startIndex]); // why this???
                    Permutate(str, startIndex + 1, EndIndex); // startIndex + 1 --> move to another index
                    Swap(ref str[i], ref str[startIndex]); // why this???
                }
            }


        }
    }
}
