using System;
using System.Collections.Generic;
using System.Linq;

namespace ArraySorting
{
    // *****************************************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // *****************************************

  
    public static class ArraySorting
    {
        //==================
        //Your Code is Here
        //==================

        /// <summary>
        /// Use the merge and the insertion sort to sort a given N array
        /// </summary>
        /// <param name="numbers">All numbers</param>
        /// <param name="N">The array size</param>
        /// <param name="MergeThreshold">The merge insertion threshold at which insertion sort starts to complete the sorting process</param>
        /// <param name="Flag">Flag = TRUE in case we need to sort using MERGE_INSERTON and Flag = FALSE in case we need to sort using MERGE sort</param>
        /// <returns>The sorted array</returns>
        /// 
       static int hold = 0;
        

        public static int[] SortArray(int[] numbers, int N, int threshold, bool flag)
        {

            //mergecount= int.Parse(Console.ReadLine());

            // mergesort(numbers, 0, N - 1,threshold,flag);

            // insertsort(numbers, 0, N);
            //insert(numbers);
         
           
            MergeSort(numbers, 0, N - 1,threshold,flag);
            return numbers;
            
            //throw new NotImplementedException();
        }

        //static void mergesort(int[] numbers, int start, int end,int threshold,bool flag)
        //{

        //    if (start >= end)
        //    {
        //        //flag = true;
        //        //insertsort(numbers, start, threshold);
        //        return;
        //    }

        //    flag = false;
        //    int mid = (start + end) / 2;

        //    mergesort(numbers, start, mid,threshold,flag);
        //    mergesort(numbers, mid + 1, end, threshold, flag);


        //    ////mergearray
        //    mergarr(numbers, start, end);



        //}


        //static void mergarr(int[] a, int s, int e)
        //{
        //    int mid = (s + e) / 2;

        //    int i = s;
        //    int j = mid + 1;
        //    int k = s;

        //    int[] temp = new int[100];

        //    while (i <= mid && j <= e)
        //    {
        //        if (a[i] < a[j])
        //        {
        //            temp[k++] = a[i++];
        //        }
        //        else
        //        {
        //            temp[k++] = a[j++];
        //        }
        //    }
        //    while (i <= mid)
        //    {
        //        temp[k++] = a[i++]; 
        //    }
        //    while (j <= e)
        //    {
        //        temp[k++] = a[j++];
        //    }

        //    //We need to copy all element to original arrays
        //    for (int zi = s; zi <= e; zi++)
        //    {
        //        a[zi] = temp[zi];
        //    }

        //}


        //static void insertsort(int[] a,int s,int e)
        //{

        //    for (int i = 0; i < e; i++)
        //    {
        //        for (int j = 1; j < e; j++)
        //        {
        //            // if elem is greater swap 
        //            if(a[i]>a[j])
        //            {
        //                int temp = a[j];
        //                 a[j]=a[i];

        //                 a[i] = temp;
        //            }
        //        }
        //    }

        //}

        public static void MergeSort(int[] input, int low, int high,int hold,bool flag)
        {
            if ((high - low) <= hold)
            {
                flag = false;
                insert(input, low, high - low);

            }

            if (low < high)
            {
                int middle = (low / 2) + (high / 2);
                MergeSort(input, low, middle,hold,flag);
                MergeSort(input, middle + 1, high,hold,flag);
                flag = true;
               
                Merge(input, low, middle, high);
            }
        }
        public static void Merge(int[] input, int low, int middle, int high)
        {

            int left = low;
            int right = middle + 1;
            int[] tmp = new int[(high - low) + 1];
            int tmpIndex = 0;

            while ((left <= middle) && (right <= high))
            {
                if (input[left] < input[right])
                {
                    tmp[tmpIndex] = input[left];
                    left = left + 1;
                }
                else
                {
                    tmp[tmpIndex] = input[right];
                    right = right + 1;
                }
                tmpIndex = tmpIndex + 1;
            }

            if (left <= middle)
            {
                while (left <= middle)
                {
                    tmp[tmpIndex] = input[left];
                    left = left + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            if (right <= high)
            {
                while (right <= high)
                {
                    tmp[tmpIndex] = input[right];
                    right = right + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            for (int i = 0; i < tmp.Length; i++)
            {
                input[low + i] = tmp[i];
            }

        }

        static void insert(int[] num,int start,int end)
        {
            for (int i = start; i < end; i++)
            {
                int key = num[i];
                int j = i - 1;
                while (j >= 0 && num[j] > key)
                {
                    //loop
                    num[j + 1] = num[j];
                    j--;
                }
                num[j + 1] = key;
            }
        }


        //public static int[] mergeSort(int[] ar)
        //{
        //    Func<int[], int[]> firstHalf = (array) =>
        //    {
        //        return array.Take((array.Length + 1) / 2).ToArray();
        //    };

        //    Func<int[], int[]> secondHalf = (array) =>
        //    {
        //        return array.Skip((array.Length + 1) / 2).ToArray();
        //    };

        //    Func<int[], int[], int[]> mergeSortedArrays = (ar1, ar2) =>
        //    {
        //        int[] mergedArray = new int[ar1.Length + ar2.Length];

        //        int i1 = 0, i2 = 0, currentMin;

        //        while (i1 < ar1.Length || i2 < ar2.Length)
        //        {
        //            if (i1 < ar1.Length && i2 < ar2.Length)
        //            {
        //                if (ar1[i1] < ar2[i2])
        //                {
        //                    currentMin = ar1[i1];
        //                    i1++;
        //                }
        //                else
        //                {
        //                    currentMin = ar2[i2];
        //                    i2++;
        //                }
        //            }
        //            else if (i1 < ar1.Length)
        //            {
        //                currentMin = ar1[i1];
        //                i1++;
        //            }
        //            else
        //            {
        //                currentMin = ar2[i2];
        //                i2++;
        //            }
        //            mergedArray[i1 + i2 - 1] = currentMin;
        //        }
        //        return mergedArray;
        //    };

        //    int[] half1 = firstHalf(ar); //always /geq than half2
        //    int[] half2 = secondHalf(ar);

        //    if (half1.Length < 2)
        //        return mergeSortedArrays(half1, half2);
        //    else
        //        return mergeSortedArrays(mergeSort(half1), mergeSort(half2));

        //}

    }
}