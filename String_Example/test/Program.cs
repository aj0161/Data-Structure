using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            StringExample.datetimeToDouble();
            int[] array = new int[] { 1,2,3, 1, 3, 4, 5,6,6 };
            bool res = StringExample.IsNumberPalindrome(12321);
            bool res1 = StringExample.isAnagram("cat", "atc");
            StringExample.CheckRepeatedNumber(array, array.Length);
            ThreadExample ex = new ThreadExample();
            Console.ReadKey();
        }
    }

    public class ThreadExample
    {
        int limit = 10;

        public ThreadExample()
        {
            Console.WriteLine("Starting threads...");
            var locker = new Object();
            int count = 0;
            Parallel.For(0, limit, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 10 }, i =>
            {
                Interlocked.Increment(ref count);
                lock (locker)
                {
                    Console.WriteLine("Number of active threads:" + count + " count: " + count);
                    Thread.Sleep(10);
                }
                Interlocked.Decrement(ref count);
            });
        }
    }

    public static class StringExample
    {
        //check repeated number in an array
        public static void CheckRepeatedNumber(int[] array, int size) {

            for (int i = 0; i < size; i++)
            {
                //check if the number are -ve
                int num = Math.Abs(array[i]);
                
                if (array[num] >= 0)
                {
                    //make it negative
                    array[i] = -num;
                }
                else
                {
                    Console.WriteLine(array[i] + "is repeated.");
                }
              
            }
        }

        public static bool IsNumberPalindrome(int number)
        {
            int reverse = 0;
            int copy = number;
            while (number != 0)
            {
                reverse = reverse * 10 + number % 10;
                number = number / 10;
            }
            return (reverse == copy);
        }

        public static bool isAnagram(String s, String t)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t)) 
                return false;
            else if (s.Length != t.Length) 
                return false;

            int[] letters = new int[256];
            char[] s_array = s.ToCharArray();

            foreach (char c in s_array)
            {
                letters[c]++; // increment array value by 1
            }

            for (int i = 0; i < t.Length; i++)
            {
                int c = t[i];
                if (--letters[c] < 0)
                {
                    return false;
                }
            }
            return true;
        }
    
         public static void datetimeToDouble()
        {
            DateTime time = DateTime.Now;
            double test = Convert.ToDouble(time);
            Console.WriteLine("time: " + test);
        }
    }

    
}
