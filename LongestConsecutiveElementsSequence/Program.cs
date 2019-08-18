using System;
using System.Collections.Generic;

namespace LongestConsecutiveElementsSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new[] { -20, -10, -5, 2, -1, 0, 1, -2 };

            HashSet<int> set = new HashSet<int>();

            int min = int.MaxValue;
            int max = FindMax(arr);
            for (int i = 0; i < arr.Length; i++)
            {                
                if (min < arr[i]) min = arr[i];
                set.Add(arr[i]);
            }

            foreach(var d in set)
            {
                Console.WriteLine(d);
            }

            int localCounter = 0;
            int globalCounter = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                int curEle = arr[i];
                if (set.Contains(curEle))
                {
                    
                    while (set.Contains(curEle)) localCounter++;
                }
                else
                {
                    globalCounter = Math.Max(localCounter, globalCounter);
                    localCounter = 0;
                }
            }

            Console.WriteLine(globalCounter);
            Console.Read();

        }

        private static int FindMax(int[] arr)
        {
            int max = arr[0];
            foreach(int ele in arr)
            {
                if (max < ele) max = ele;
            }
            return max;
        }
    }
}
