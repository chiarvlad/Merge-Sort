using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Merge_Sort 
{
    class Program 
    {
        static int opCounter = 0; //A variable to count how many comparisons are executed
                                  //Must be declared static in Program class for this purpose
        //static int reLCounter = 0;static int reMCounter = 0;static int reRCounter = 0;

        private static List<int> MergeSort (List<int> unsorted) 
        {//reCounter++; WriteLine($"MS {reCounter}");
            if (unsorted.Count <= 1) return unsorted;

            List<int> left = new List<int> ();
            List<int> right = new List<int> ();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle; i++) //Dividing the unsorted list
            {
                left.Add (unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++) 
            {
                right.Add (unsorted[i]);
            }

            //reLCounter++;WriteLine($"L {reLCounter}");
            left = MergeSort (left);
            //reRCounter++;WriteLine($"R {reRCounter}");
            right = MergeSort (right);
            return Merge (left, right);

        }

        private static List<int> Merge (List<int> left, List<int> right) 
        {
            //reMCounter++; WriteLine($"M {reMCounter}");
            List<int> result = new List<int> ();
            
            while (left.Count > 0 || right.Count > 0) 
            { //opCounter++;
                if (left.Count > 0 && right.Count > 0) 
                {
                    opCounter++;
                    if (left.First () <= right.First ()) {
                        result.Add (left.First ());
                        left.Remove (left.First ());
                    } else {
                        result.Add (right.First ());
                        right.Remove (right.First ());
                    }
                } 
                else if (left.Count > 0) 
                {
                    result.Add (left.First ());
                    left.Remove (left.First ());
                } else 
                {
                    result.Add (right.First ());
                    right.Remove (right.First ());
                }
            }
           
            /*foreach (int number in result) 
            {
                Write ($"{number} ");
            }
            Write("\n");*/
            return result;
        }

        static void Main (string[] args) {
            Write ("How many numbers? "); //Read from console the dimension of the list to be sorted 
            int n = Convert.ToInt32 (ReadLine ()); //Feature for further comparative tests
            WriteLine ("\n");
            
            List<int> unsorted = new List<int> (); //Declare and assign the unsorted list variable
            List<int> sorted; //Declare the sorted list variable

            Random random = new Random ();
            WriteLine ("Unsorted array elements:");
            for (int i = 0; i < n; i++) 
            {
                unsorted.Add (random.Next (0, 100)); //Populate the list with random numbers within a range
                Write ($"{unsorted[i]} ");
            }
            WriteLine ("\n");
            sorted = MergeSort (unsorted); //Calling the recursive method MergeSort

            WriteLine ("Sorted array elements: ");
            foreach (int number in sorted) 
            {
                Write ($"{number} ");
            }

            WriteLine ("\n");
            WriteLine ($" Basic comparations {opCounter}");
        }
    }
}