using System;
using System.Collections.Generic;
using System.Text;

namespace Codejam
{
   public class temp
    {
        public string Intersection(int[] seg1, int[] seg2)
        {
            seg1 = Modify(seg1);
            seg2 = Modify(seg2);
            

           
        }

       

        private int[] Modify(int[] seg1)
        {
            if (IsParallelToXAxis(seg1))
            {
                int temp1 = seg1[0];
                int temp2 = seg1[2];
                if (temp1 > temp2)
                {
                    seg1[0] = temp2;
                    seg1[2] = temp1;
                }
            }
            else
            {
                int temp1 = seg1[1];
                int temp2 = seg1[3];
                if(temp1> temp2)
                {
                    seg1[1] = temp2;
                    seg1[3] = temp1;
                }
            }
            return seg1;
        }

        private bool IsParallelToXAxis(int[] seg1)
        {
            if (seg1[1] == seg1[3]) return true;
            return false;
        }

        #region Testing code Do not change
        public static void Main(String[] args)
        {
            string input = Console.ReadLine();
            NoPointSegment solver = new NoPointSegment();
            do
            {
                var segments = input.Split('|');
                var segParts = segments[0].Split(',');
                var seg1 = new int[4] { int.Parse(segParts[0]), int.Parse(segParts[1]), int.Parse(segParts[2]), int.Parse(segParts[3]) };
                segParts = segments[1].Split(',');
                var seg2 = new int[4] { int.Parse(segParts[0]), int.Parse(segParts[1]), int.Parse(segParts[2]), int.Parse(segParts[3]) };
                Console.WriteLine(solver.Intersection(seg1, seg2));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}