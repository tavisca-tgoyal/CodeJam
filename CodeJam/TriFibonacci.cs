using System;
using System.Collections.Generic;
using System.Text;

namespace Codejam
{
    public class TriFibonacci
    {
        public int Complete(int[] test)
        {

            

            //length validation
            if (test.Length < 4) return -1;

            //number of -1 validation
            List<int> countOfMinusOne = new List<int>();
            for (int i = 0; i < test.Length; i++)
            {
                if (test[i] == -1)
                   countOfMinusOne.Add(i);                
            }
            if (countOfMinusOne.Count > 1) return -1;

            int indexToBeFixed = countOfMinusOne[0];

            //-1 is at 0th index
            if (indexToBeFixed == 0)
            {
                int value = test[3] - (test[1] + test[2]);
                if (value <= 0) return -1;
                else
                {
                    test[indexToBeFixed] = value;
                    if (ValidateTriFib(test, test.Length)) return value;
                    else return -1;
                }
                   
                
            }

            //-1 is at 1st index
            if (indexToBeFixed == 1)
            {
                int value = test[3] - (test[0] + test[2]);
                if (value <= 0) return -1;
                else
                {
                    test[indexToBeFixed] = value;
                    if (ValidateTriFib(test, test.Length)) return value;
                    else return -1;
                }

            }

            //-1 is at 2nd index
            if (indexToBeFixed == 2)
            {
                int value = test[3] - (test[1] + test[0]);
                if (value <= 0) return -1;
                else
                {
                    test[indexToBeFixed] = value;
                    if (ValidateTriFib(test, test.Length)) return value;
                    else return -1;
                }

            }
            //-1 is any index except first three
            if(indexToBeFixed > 2)
            {
                int value = (test[indexToBeFixed - 1] + test[indexToBeFixed - 2] + test[indexToBeFixed - 3]);
                if (value <= 0) return -1;
                test[indexToBeFixed] = value;

                if (ValidateTriFib(test, test.Length))
                {   
                    return value;
                }
                else return -1;
            }
           
            return -1;
        }

        private bool ValidateTriFib(int[] test, int length)
        {
            
            for (int i = 3; i < length; i++)
            {
                if (test[i] != (test[i-1] + test[i-2] + test[i-3])) return false;

            }
            return true;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            String input = Console.ReadLine();
            TriFibonacci triFibonacci = new TriFibonacci();
            do
            {
                string[] values = input.Split(',');
                int[] numbers = Array.ConvertAll<string, int>(values, delegate (string s) { return Int32.Parse(s); });
                int result = triFibonacci.Complete(numbers);
                Console.WriteLine(result);
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}