using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingComputers
{
    class Program
    {
     

        static  int[] loads = new int[] { 1, 2, 3, 5 };
        static  int[] price = new int[] { 20, 10, 15, 25 };
        static int[,] memo = new int[100, 100];
      static  List<int> car1 = new List<int>();
      static  List<int> car2 = new List<int>();

        static int car1load = 5;
        static int car2load = 2;
        static int n = 4;
       

      
       
        
        static void Main(string[] args)
        {
            int max1 = 0;
            int max2 = 0;
            int ind = 2;

            if (loads[ind] == car1load)
                max1 = price[ind];
            else
             max1 = knapSack(0, loads[ind], car1load);

            if (loads[ind] == car2load)
                max2 = price[ind];
            else
                max2 = knapSack(0, loads[ind], car2load);


           

          

            Console.WriteLine(max1);
            Console.WriteLine(max2);

            //for (int i = 0; i < n; i++)
            //{
            //    int take1 = knapSack(i, loads[i], car1load);
            //    int take2 = knapSack(i, loads[i], car2load);
            //    int let1 = knapSack(i, 0, car1load);
            //    int let2 = knapSack(i,0, car1load);
            //    int max = Math.Max(take1, take2);
            //    if (take1 >= take2)
            //    {
            //        car1.Add(1 + 1);
            //    }
            //    else
            //        car2.Add(i + 1);
            //}

            //Console.WriteLine("List1 Items");
            //for (int i = 0; i < car1.Count; i++)
            //{
            //    Console.Write(car1.ElementAt(i) + " ");
            //}
            //Console.WriteLine();
            //Console.WriteLine("List2 Items");
            //for (int i = 0; i < car2.Count; i++)
            //{
            //    Console.Write(car2.ElementAt(i) + " ");
            //}





        }


        static int knapSack(int index, int w,int W)
        {
            if (index == n)
                return 0;
            else if (w + loads[index]<= W)
            {
                int let = knapSack(index + 1, w,W);
                int take = knapSack(index + 1, w + loads[index],W) + price[index];
                memo[index,w] = Math.Max(take, let);
                return memo[index,w];
            }
            else
            {
                memo[index,w] = knapSack(index + 1, w,W); // must let
                return memo[index,w];
            }
        }

        static bool isexist(List<int>list,int value)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if(list.ElementAt(i)==value)
                {
                    return true;
                }
            }
            return false;
        }

        static int knapsack(int index,int weight)
        {
            for (int i = 0; i < index; i++)
            {
                for (int j = 0; j <= weight; j++)
                {
                    if (i == 0)
                    {
                        memo[i, j] = 0;
                        //Console.Write("0 ");
                    }

                    else if (j - loads[i - 1] >= 0)
                    {
                        int let = memo[i - 1, j];
                        int take = memo[i - 1, j - loads[i-1]]+price[i-1];
                        memo[i, j] = Math.Max(let, take);


                        //Console.Write(memo[i, j]+" ");
                    }

                    else
                    {
                        memo[i, j] = memo[i - 1, j];
                        //Console.Write(memo[i, j]+" ");
                    }
                }
                //Console.WriteLine();
            }

            return 0;
        }
    }
}
