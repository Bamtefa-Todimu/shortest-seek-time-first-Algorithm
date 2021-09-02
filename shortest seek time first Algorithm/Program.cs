using System;
using System.Globalization;
using System.Collections.Generic;

namespace shortest_seek_time_first_Algoritm
{
    class program
    {

        static int leftCheck(List<List<int>> llist , int currIndex)
        {
            int leftdiff = 0;
            for(int i = currIndex - 1;i>=0;i--)
            {
                if(llist[1][i] != 0)
                {
                    continue;
                }
                else
                {
                    leftdiff = llist[0][currIndex] - llist[0][i];
                    i = -1;
                }
                
            }

            return leftdiff;

        }

        static int rightCheck(List<List<int>> llist, int currIndex)
        {
            int rightdiff = 0;
            for (int i = currIndex + 1; i < llist[0].Count ; i++)
            {
                if (llist[1][i] != 0)
                {
                    continue;
                }
                else
                {
                    rightdiff = Math.Abs(llist[0][currIndex] - llist[0][i]) ;
                    break;
                }
            }

            return rightdiff;
        }
        
        
        static int sstf(List<List<int>> llist , int len , int sPos)
        {
            int currIndex = llist[0].IndexOf(sPos);
            int sTime = 0;

            while(llist[1].Contains(0))
            {
   
                int left = leftCheck(llist, currIndex);
                int right = rightCheck(llist, currIndex);
                
                if ((left!=0) && left < right )
                {
                    sTime += left;
                    llist[1][currIndex] = 1;
                    currIndex = llist[0].IndexOf(llist[0][currIndex] - left);
                    //currIndex = 0;
                    
                }
                else if((right != 0) && (right < left) )
                {
                    sTime += right;
                    llist[1][currIndex] = 1;
                    currIndex = llist[0].IndexOf(llist[0][currIndex] + right);
                    
                }
                else if (right == 0 && right < left)
                {
                    sTime += left;
                    llist[1][currIndex] = 1;
                    currIndex = llist[0].IndexOf(llist[0][currIndex] - left);
                }
                else if (left == 0 && left < right)
                {
                    sTime += right;
                    llist[1][currIndex] = 1;
                    currIndex = llist[0].IndexOf(llist[0][currIndex] + right);
                }
                else if(right == left)
                {
                    llist[1][currIndex] = 1;
                    currIndex = llist[0].IndexOf(llist[0][currIndex] - left);
                }

                Console.WriteLine(string.Join(",", llist[1]));
  
            }
            return sTime;
        }

        static void Main(string[] args)
        {
            List<List<int>> sList = new List<List<int>>();
            int length;

            Console.Write("enter sequence : ");
            string sequence = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("enter start position: ");
            int sPosition = int.Parse(Console.ReadLine());
            length = sequence.Split(',').Length;

            sList.Add(sequence.Trim(' ').Split(',').ToList().Select(sTemp => int.Parse(sTemp)).ToList());
            string sTemp = "0";
            for(int i = 0; i < length - 1;i++)
            {
                sTemp += ",0";  
            }
            sList.Add(sTemp.Trim(' ').Split(',').ToList().Select(sTemp => int.Parse(sTemp)).ToList());
            sList[0].Sort();

            int seekTime = sstf(sList, length, sPosition);
            Console.WriteLine($"the seek time is : {seekTime}ms");




        }
    }
}
