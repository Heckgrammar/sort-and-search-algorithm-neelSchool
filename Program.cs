using System.Diagnostics;

namespace compare_algorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            menu();
        }
        static int[] CreateArray(int size, int min, int max)
        {
         Random r = new Random();
         int[] a = new int[size];
         for (int i = 0; i < a.Length; ++i)
         {
          a[i] = r.Next(min, max);
         }
        }
        static void menu()
        {
         Console.WriteLine("Enter 1 for linear search");
         Console.WriteLine("Enter 2 for binary search");
         Console.WriteLine("Enter 3 for bubble sort");
         Console.WriteLine("Enter 4 for merge sort");
         Console.WriteLine("Enter 9 for quit");
         int opt = Convert.ToInt32(Console.ReadLine());
         Console.WriteLine("Enter size of the array");
         int size = Convert.ToInt32(Console.ReadLine());
         Console.WriteLine("Enter minimum value for array");
         int min = Convert.ToInt32(Console.ReadLine());
         Console.WriteLine("Enter maximum value for array");
         int max = Convert.ToInt32(Console.ReadLine());
         int[] b = CreateArray(size, min, max);
         if (opt == 1)
         {
          Console.WriteLine("Enter value to find");
          int val = Convert.ToInt32(Console.ReadLine());
          LinearSearch(b, val);
         }
         else if (opt == 2)
         {
          Console.WriteLine("Enter value to find");
          int val = Convert.ToInt32(Console.ReadLine());
          BinarySearch(b, val);
         }
         else if (opt == 3)
         {
          BubbleSort(b);
         }
         else if (opt == 4)
         {
          MergeSort(b);
         }
         else 
         {
          System.Environment.Exit(1);
         }
        }
        static void BubbleSort(int[] a)
        {
        int temp;
        bool swaps;
        do 
        {
            swaps = false;
            for (int i = 0; i <= a.Length - 2; ++i)
            {
                if (a[i] > a[i+1])
                {
                    temp = a[i+1];
                    a[i+1] = a[i];
                    a[i] = temp;
                    swaps = true;
                }
            }
        } while (swaps);
        
        }
        static void Merge(int[] a, int low, int mid, int high)
        {
            int i, j, k;
            int num1 = mid - low + 1;
            int num2 = high - mid;
            int[] L = new int[num1];
            int[] R = new int[num2];
            for (i = 0; i < num1; i++)
            {
                L[i] = a[low + i];
            }
            for (j = 0; j < num2; j++)
            {
                R[j] = a[mid + j + 1];
            }
            i = 0;
            j = 0;
            k = low;
            while (i < num1 && j < num2)
            {
                if (L[i] <= R[j])
                {
                    a[k] = L[i];
                    i++;
                }
                else
                {
                    a[k] = R[j];
                    j++;
                }
                k++;
            }
            while (i < num1)
            {
                a[k] = L[i];
                i++;
                k++;
            }
            while (j < num2)
            {
                a[k] = R[j];
                j++; k++;
            }
        }
        static void MergeSortRecursive(int[] a, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;
                MergeSortRecursive(a, low, mid);
                MergeSortRecursive(a, mid + 1, high);
                Merge(a, low, mid, high);
            }
        }
        static bool LinearSearch(int[] a, int numToFind)
        {
         bool found = false;
         for (int i = 0; i < a.Length; ++i)
         {
            if (a[i] == numToFind)
            {
                found = true;
                Console.WriteLine($"Your number was found at index {i}");
                break;
            }
         }
         if (found == false)
         {
            Console.WriteLine("Your item was not found.");
         }
        }
        static bool BinarySearch(int[] a, int numToFind)
        {
            bool found = false;
            int ub = a.Length - 1;
            int lb = 0;
            while (lb < ub)
            {
             int mp = (lb+ub)/2;
             if (a[mp] == numToFind)
             {
                Console.WriteLine($"Item found at {mp}.");
                found = true;
             }
             else if (a[mp] < numToFind)
             {
                lb = mp+1;
                mp = (lb+ub)/2;;
             }
             else if (a[mp] > numToFind)
             {
                ub = mp-1;
                mp = (lb+ub)/2;;
             }
             else
             {
                Console.WriteLine($"Item not found.");
             }
            }
        }
            
    }
}
