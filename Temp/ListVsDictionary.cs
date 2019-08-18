using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Temp
{

    public class ListVsDictionary
    {
         static void Main(string[] args)
         {
            var summary = BenchmarkRunner.Run<ListVsDictionary>();

            List<int> intList = new List<int>() { 1, 4, 56, 47, 333, 11 };
            Dictionary<int, int> intDict = new Dictionary<int, int>()
            {
                {1,1},
                {4,4},
                {56,56},
                {47,47},
                {333,333},
                {11,11}
            };           

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            int sumUsingList = GetSumOfList(intList);
            stopwatch.Stop();

            Console.WriteLine("accessing whole list takes " + stopwatch.Elapsed + "sec");

            stopwatch.Reset();
            stopwatch.Start();
            int sumUsingDict = GetSumOfDict(intDict);
            stopwatch.Stop();
            Console.WriteLine("accesing whole dictionary takes " + stopwatch.Elapsed+ "sec");

            stopwatch.Reset();
            stopwatch.Start();
            bool flag = intDict.ContainsValue(4);
            stopwatch.Stop();
            Console.WriteLine("finding a value in dictionary takes: " + stopwatch.Elapsed);

            stopwatch.Reset();
            stopwatch.Start();
            bool flagOfDict = ContainsValue(intList, 4);
            stopwatch.Stop();
            Console.WriteLine("finding a value in list takes: " + stopwatch.Elapsed);      


        }

        
        private static bool ContainsValue(List<int> intList, int v)
        {
            foreach(int ele in intList)
            {
                if (ele == v) return true;
            }return false;
        }
        [Benchmark]
        private static int GetSumOfDict(Dictionary<int, int> intDict)
        {
            int sum = 0;
            IDictionaryEnumerator enumerator = intDict.GetEnumerator();
            while (enumerator.MoveNext())
            {
                sum += Convert.ToInt32(enumerator.Key);
            }
            return sum;
        }

        [Benchmark]
        private static int GetSumOfList(List<int> intList)
        {
            int sum = 0;
            foreach(int ele in intList)
            {
                sum += ele;
            }
            return sum;
        }
    }
}
