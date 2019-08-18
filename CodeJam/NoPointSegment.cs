using System;

namespace Codejam
{

     class NoPointSegment
    {
        
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
                if (temp1 > temp2)
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

        public string Intersection(int[] seg1, int[] seg2)
        {
            seg1 = Modify(seg1);
            seg2 = Modify(seg2);

            //if both are points
            //if (BothArePoints(seg1, seg2)) return "SEGMENT";

            if (CheckIfBothOnSameAxis(seg1, seg2))
            {
                if (CheckPointSegment(seg1, seg2)) return "POINT";
                else if (CheckSegmentIntersection(seg1, seg2)) return "SEGMENT";
                else return "NO";
            }
            else if(CheckIfBothAreIntersecting(seg1, seg2))
            {
                return "POINT";
            }
            else
            {
                return "NO";
            }
        }

        private bool BothArePoints(int[] seg1, int[] seg2)
        {
            if (seg1[0] == seg2[0] && seg1[1] == seg2[1] && seg1[2] == seg2[2] && seg1[3] == seg2[3]) return true;
            return false;
        }

        private bool CheckSegmentIntersection(int[] seg1, int[] seg2)
        {
            
            if(AreOnXAxis(seg1, seg2)){
                if(seg1[0] < seg2[0])//segment1 will start first
                {
                    if (seg1[2] > seg2[0]) return true;
                    return false;
                }
                else
                {
                    if (seg2[2] > seg1[0]) return true;
                    return false;
                }  
            }
            else
            {
                //means they are perallel to y axis
                if(seg1[1]< seg2[1]) //means segment1 will start first in the timeline
                {
                    //cheking the condition of overlapping
                    if (seg1[3] > seg2[1]) return true;
                    return false;
                }
                else
                {
                    if (seg2[3] > seg1[1]) return true;
                    return false;
                }
                
            }
        }

        private bool AreOnXAxis(int[] seg1, int[] seg2)
        {
            if ((seg1[1] == seg1[3])&& (seg1[3] == seg2[1]) && (seg2[1] == seg2[3]) )return true;
            return false;
        }

        private bool CheckPointSegment(int[] seg1, int[] seg2)
        {
            
            if(AreOnXAxis(seg1, seg2)){
                //check whether a point
                if (CheckPoint(seg1))
                {
                    if (seg1[0] <= seg2[2] && seg1[0] >= seg2[0]) return true;
                    return false;
                }
                if (CheckPoint(seg2))
                {
                    if (seg2[0] <= seg1[2] && seg2[0] >= seg1[0]) return true;
                    return false;
                }
                if (seg1[0] <= seg2[0])//seg1 starts first
                {
                    if (seg1[2] == seg2[0]) return true;
                    return false;
                }
                else//seg2 starts first
                {
                    if (seg2[2] == seg1[0]) return true;
                    return false;
                }
            }
            else//both lines are on y axis
            {
                if (CheckPoint(seg1))
                {
                    if (seg1[1] <= seg2[3] && seg1[1] >= seg2[1]) return true;
                    return false;
                }
                if (CheckPoint(seg2))
                {
                    if (seg2[1] <= seg1[3] && seg2[1] >= seg1[1]) return true;
                    return false;
                }
                if (seg1[1] < seg2[1])//seg1 starts first
                {
                    if (seg1[3] == seg2[1]) return true;
                    return false;
                }
                else//seg2 starts first
                {
                    if (seg2[3] == seg1[1]) return true;
                    return false;
                }
            }
        }

        private bool CheckPoint(int[] seg1)
        {
            if (CheckTwoCoordinatesAreSame(seg1[0], seg1[1], seg1[2], seg1[3])) return true;
            return false;
        }

        private bool CheckTwoCoordinatesAreSame(int v1, int v2, int v3, int v4)
        {
            if ((v1 == v3) && (v2 == v4)) return true;
            return false;
        }

        private bool CheckIfBothAreIntersecting(int[] seg1, int[] seg2)
        {           

            if (IsParallelToXAxis(seg1))
            {
                if (
                    ((seg1[0] <= seg2[0]) && (seg2[0] <= seg1[2])) &&
                    ((seg1[1] <= seg2[3]) && (seg1[1] >= seg2[1]))
                  ) return true;
                return false;

            }
            else
            {
                if (
                    ((seg2[1] <= seg1[3]) && (seg2[1] >= seg1[1])) &&
                    ((seg1[0] >= seg2[0]) && (seg1[0] <= seg2[2]))
                  ) return true;
                return false;
            }

            
        }        

        public bool CheckIfBothOnSameAxis(int[] seg1, int[] seg2)
        {
            //checking whether they are on x axis
            //if both lines are on x axis then their y value must be same
            if (
                (seg1[1] == seg1[3]) &&
                (seg1[3] == seg2[1]) &&
                (seg2[1] == seg2[3]))
            {
                return true;
            }
            // both are parallel to y axis
            else if ((seg1[0] == seg1[2]) &&
                    (seg1[2] == seg2[0]) &&
                    (seg2[0] == seg2[2]))
            {
                return true;
            }

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