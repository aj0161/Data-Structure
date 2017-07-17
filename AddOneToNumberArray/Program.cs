using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddOneToNumberArray
{
    class Program
    {
        static void Main(string[] args)
        {
           // int[] array = new int[] {0,9,9,9};
           // int[] array = new int[] { 1, 2, 9 };
            int[] array = new int[] { 1, 2,4 };
            int carry = 1;

            AddOneToArray(array, carry);
        }

        private static void AddOneToArray(int[] A, int carry) // this doesnt add new element in an array
        {
            if (A.Length == 0)
                return;

            bool CarryOver = false;
            int val = 0;
            for (int i= A.Length-1; i >=0; i--)
            {
                if (!CarryOver)
                    val = A[i] + carry;
                
                if (val >= 10)
                {
                    A[i] = 0; // right most digit if added more than one
                    CarryOver = true;

                    if (i > 0)
                        val = A[i - 1] + carry; //purpose of this is when it iterate next time, it will check value with carry is greater than 10 or not
                    else
                        A[i] = A[i] + carry;
                }
                else 
                {
                    A[i] = val;
                    break;
                }
            }

            //Print the array
            Console.Write("Output: ");
            foreach (int digit in A)
            {
                Console.Write(digit);
            }
        }
    }
}
