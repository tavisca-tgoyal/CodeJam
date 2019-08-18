using System;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;
using System.Text;

namespace Codejam
{
    class CreatePairs
    {
        int MaximalSum(int[] data)
        {
            int sum = 0;

            if (data.Length == 0)
                Console.WriteLine("Enter More than one Value");

            int[] NegativeElements = GetNegativeElements(data);
            int ZeroCount = GetZeroCount(data);
            int OneCount = GetOneCount(data);
            int[] PositiveElements = GetPositiveElements(data);

            sum += HandleNegativeWithZeros(NegativeElements, ZeroCount);
            sum += HandleOnes(OneCount);
            sum += HandlePositiveElements(PositiveElements);

            return sum;


        }

        private int HandlePositiveElements(int[] positiveElements)
        {
            int intermediateSum = 0;
            Array.Sort(positiveElements);

            if (positiveElements.Length % 2 == 0)
            {
                intermediateSum = GetPairSum(positiveElements, positiveElements.Length);
            }
            else
            {
                intermediateSum = GetPairSum(positiveElements, positiveElements.Length) + positiveElements[0];
            }
            return intermediateSum;

        }

        private int HandleOnes(int oneCount)
        {
            return oneCount;
        }

        private int HandleNegativeWithZeros(int[] negativeElements, int zeroCount)
        {
            int intermediateSum = 0;
            Array.Sort(negativeElements);
            Array.Reverse(negativeElements);

            if (negativeElements.Length % 2 == 0)//in this case we don't need to use zeros
            {
                intermediateSum = GetPairSum(negativeElements, negativeElements.Length);
            }
            else
            {
                //if not even then remove the smallest and getpairsum of remaining                
                if (zeroCount > 0)//nullify this extra negative number with zero
                {
                    intermediateSum = GetPairSum(negativeElements, negativeElements.Length);
                }
                else
                {
                    intermediateSum = GetPairSum(negativeElements, negativeElements.Length) + negativeElements[0];
                }
            }

            return intermediateSum;
        }

        private int GetPairSum(int[] negativeElements, int v)
        {
            int sum = 0;

            while (v > 1)
            {
                sum += negativeElements[v - 1] * negativeElements[v - 2];
                v += -2;
            }
            return sum;
        }

        private int[] GetPositiveElements(int[] data)
        {
            List<int> temp = new List<int>();
            foreach (int ele in data)
            {
                if (ele > 1)
                {
                    temp.Add(ele);
                }
            }
            return temp.ToArray();
        }

        private int GetOneCount(int[] data)
        {
            int oneCount = 0;
            foreach (int ele in data)
            {
                if (ele == 1) oneCount++;
            }
            return oneCount;
        }

        private int GetZeroCount(int[] data)
        {
            int zeroCount = 0;
            foreach (int ele in data)
            {
                if (ele == 0) zeroCount++;
            }
            return zeroCount;
        }

        private int[] GetNegativeElements(int[] data)
        {
            List<int> temp = new List<int>();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] < 0) temp.Add(data[i]);
            }

            return temp.ToArray();
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            CreatePairs createPairs = new CreatePairs();
            do
            {
                int[] data = Array.ConvertAll<string, int>(input.Split(','), delegate (string s) { return Int32.Parse(s); });
                Console.WriteLine(createPairs.MaximalSum(data));
                input = Console.ReadLine();
            } while (input != "*");
        }
        #endregion
    }
}
