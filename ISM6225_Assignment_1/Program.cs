using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1_Fall20
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            PrintTriangle(n);

            int n2 = 5;
            PrintSeriesSum(n2);

            int[] A = new int[] { 1, 2, 2, 6 };
            bool check = MonotonicCheck(A);
            Console.WriteLine(check);

            int[] nums = new int[] { 3, 1, 4, 1, 5 };
            int k = 2;
            int pairs = DiffPairs(nums, k);
            Console.WriteLine(pairs);

            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "dis";
            int time = BullsKeyboard(keyboard, word);
            Console.WriteLine(time);

            string str1 = "goulls";
            string str2 = "gobulls";
            int minEdits = StringEdit(str1, str2);
            Console.WriteLine(minEdits);

        }

        /*n – number of rows for the pattern, integer (int)
        * summary   : This method prints a triangle pattern using *.
        * For example n = 5 will display the output as: 
        *
        *      *
        *     ***
        *    *****   
        *   *******
        *  *********
        *
        * returns      : N/A
        * return type  : void
        */
        public static void PrintTriangle(int x)
        {
            Console.WriteLine("1. Print Triangle Method:");
            //constant values can be changed in case we want to change how to triangle gets printed out 
            string symbol = "*"; //star symbol (default) - triangle shape
            string space = " "; // spaces around the triangle
            string leftMargin = " "; //left margins for better visibility
            try
            {
                if (x > 0) // print is only possible for positive numbers
                {
                    int maxRowLength = x * 2 - 1; //row length of the bottom row
                    for (int i = 1; i <= x; i++) // i is row number (starts at 1 convenience)
                    {
                        int numSymbolsInRow = i * 2 - 1; //calculate how many symbols there are in a row 
                        int symbolStartPositionInRow = (maxRowLength - numSymbolsInRow) / 2 + 1; // start position of the symbol in a row cannot be negative
                        int symbolEndPositionInRow = symbolStartPositionInRow + numSymbolsInRow - 1;
                        string row = leftMargin;
                        for (int j = 1; j <= maxRowLength; j++) //j is each character's position number in a row (string - starts at 1 convenience)
                        {
                            if (j >= symbolStartPositionInRow && j <= symbolEndPositionInRow) // decision structure to select space or symbol
                            {
                                row += symbol;
                            } else
                            {
                                row += space;
                            }
                        }
                        Console.WriteLine(row);
                    }
                } else
                {
                    Console.WriteLine("Please provide a positive number greater than 0. Current input: " + x);
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing PrintTriangle()");
            }
        }

        /* n2 – number of terms of the series, integer (int)
        * This method prints the following series(Odd numbers) till n terms: 1, 3, 5, 7, 9,      
        * 11… and their sum.
        * For example, if n2 = 5, output will be
        *
        * The odd numbers are : 1, 3, 5, 7, 9
        * The sum is : 25
        *
        * Returns : N/A
        * Return type: void
        * 
        */
        public static void PrintSeriesSum(int n)
        {
            Console.WriteLine("2. Series Sum Method:");
            try
            {
                if (n > 0)
                {
                    int currentNum = 1; // series start number
                    int sum = 0; // running sum
                    Console.Write("The odd numbers are : ");
                    // in case we decide later to change the seed (series start) 
                    //number to an even number eg. (currentNum = 6)
                    //we can still print the next series of odd numbers
                    if (currentNum % 2 == 0) 
                    {
                        currentNum++;
                    }
                    for (int i = 0; i < n; i++)
                    {   
                        //use write methods to not hold values in memory after each iteration as we have a running sum 
                        Console.Write(currentNum);
                        if (i != (n - 1))
                        {
                            Console.Write(", ");
                        }
                        sum += currentNum;
                        currentNum += 2;
                    }
                    Console.WriteLine("\nThe sum is : " + sum);
                }
                else
                {
                    Console.WriteLine("Please provide a positive number greater than 0. Current input: " + n);
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing PrintSeriesSum()");
            }
        }

        /* An array is monotonic if it is either monotone increasing or monotone decreasing.
        * An array A is monotone increasing if for all i <= j, A[i] <= A[j].  An array A is              
         * monotone decreasing if for all i <= j, A[i] >= A[j].
        * Return true if and only if the given array A is monotonic

        * For example:
        * Input: A = [1,2,2,6] will return the output: true
        * Input: A = [3,3,2,1] will return the output : true
        * Input: A = [4,5,2,3] will return the output: false
        * Input: A = [1,1,1,1] will return the output : true
 
        * returns      : Boolean Value
        * return type  : bool
        */
        public static bool MonotonicCheck(int[] n)
        {
            Console.WriteLine("3. Monotonic Check Method:");
            bool result = false;
            try
            {
                if (n != null && n.Length > 1)
                {
                    bool monotonicIncreasing = true;
                    bool monotonicDescreasing = true;
                    int curNum = n[0];
                    for (int i = 1; (i < n.Length && (monotonicIncreasing || monotonicDescreasing)); i ++)
                    {
                        //determine if array is increasing or decreasing
                        //elements are equal is a special case when array 
                        //is still monotonic but we cannot say that it is decreasing or increasing
                        if (curNum > n[i])
                        {
                            monotonicDescreasing = false;
                        } else if (curNum < n[i])
                        {
                            monotonicIncreasing = false;
                        }           

                    }

                    result = monotonicIncreasing || monotonicDescreasing;
                    Console.WriteLine("Array is monotonic? " + result);
                }
                else
                {
                    Console.WriteLine("Please provide a non-null array of more than 1 element");
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing MonotonicCheck()");
            }

            return result;
        }

        /* Given an array of integers and an integer n, you need to find the number of unique
        * n-diff pairs in the array. Here a n-diff pair is defined as an integer pair (i, j),    
        * where i and j are both numbers in the array and their absolute difference is n.
        * Example 1:
        * Input: [3, 1, 4, 1, 5], k = 2
        * Output: 2
        * Explanation: There are two 2-diff pairs in the array, (1, 3) and (3, 5).
        * Although we have two 1s in the input, we should only return the number of unique   
        * pairs.
        * Example 2:
        * Input:[1, 2, 3, 4, 5], k = 1
        * Output: 4
        * Explanation: There are four 1-diff pairs in the array, (1, 2), (2, 3), (3, 4) and  
        * (4, 5).
        * Example 3:
        * Input: [1, 3, 1, 5, 4], k = 0
        * Output: 1
        * Explanation: There is one 0-diff pair in the array, (1, 1).
        * Note : The pairs (i,j) and (j,i) count as same.*/

        public static int DiffPairs(int[] J, int k)
        {
            int result = 0;
            Console.WriteLine("Diff Pairs Method:");
            try
            {
                if (J != null && J.Length > 1 && k >= 0)
                {
                    //int pairs are stored in a dictionary where key <= value (for convenience) 
                    Dictionary<int, int> uniquePairs = new Dictionary<int, int>(); 
                    //nested loops: take first value from the array and compare to all others sequentially,
                    //then proceed to take next value and repeat same comparison
                    //no need to compare to previous values in the array as we want unique combinations
                    for (int i = 0; i < J.Length; i++)
                    {
                        for (int j = (i + 1); j < J.Length; j++) //loop 2 always starts and the next element from the one we are comparing
                        {
                            int diff = J[i] - J[j]; //find difference between 2 numbers
                            //sign of diff allows us to determine which number is greater (if 0 -> execute first if to check if pair was already processed)
                            //since (3,5) and (5,3) are the same pair we shoud only store it once which here only (3,5) (smaller or equivalent key) form is selected
                            //add pair to dictionary only if it wasn't already added
                            if (diff == k)
                            {
                                if (! (uniquePairs.ContainsKey(J[j]) && uniquePairs[J[j]] == J[i]))
                                {
                                    uniquePairs.Add(J[j], J[i]);
                                }
                            } else if (diff == k*-1)
                            {
                                if (!(uniquePairs.ContainsKey(J[i]) && uniquePairs[J[i]] == J[j]))
                                {
                                    uniquePairs.Add(J[i], J[j]);
                                }
                            }
                        }
                    }
                    //uncomment line below to see print out of unique pairs found (uses Linq methods)
                    //uniquePairs.Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Console.WriteLine);
                    result = uniquePairs.Count(); // get count of pairs
                    Console.WriteLine("Number of diff pairs found within the array: " + result);

                }
                else
                {
                    Console.WriteLine("Please provide a non-null array of more than 1 element and pair difference number k >= 0");
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing DiffPairs()");
            }

            return result;
        }

        /* Imagine a special bulls keyboard with all keys in a single row. 
        * Given a string keyboard of length 26 indicating the layout of the keyboard(indexed 
        * from 0 to 25), initially your finger is at index 0. To type a character, you have 
        * to move your finger to the index of the desired character.
        * The time taken to move your finger from index i to index j is |i – j|
        * You want to type a single word. Complete the function to calculate 
        * how much time it takes to type it with one finger.
        * Example 1:
        * Input: keyboard = “abcdefghijklmnopqrstuvwxyz” word = “dis”
        * Output:  18
        * Explanation: Initial index 0 at a . The moves from 0 to 3 , then 3 to 8 and finally 
        * from 8 to 18. Therefore total time = 3 + 5 + 10 = 18
        *
        * Example 2:
        * Input: keyboard = “hijklmnopqrstuvwxyzabcdefg” word = “gobulls”
        * Output:  79
     
        * returns      : Integer
        * return type  : int
        */
        public static int BullsKeyboard(string keyboard, string word)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing BullsKeyboard()");
            }

            return 0;
        }

        /* Given two strings str1 and str2 and below operations that can performed on str1.
        * Find minimum number of edits (operations) required to convert ‘str1’ into ‘str2’
        * 1.Insert
        * 2.Remove
        * 3.Replace
        * 
        * All of the above operations are of equal cost.
        * 
        * Example 1:
        * Input: str1 = “goulls” str2 = “gobulls”
        * Output: 1
        * Explanation: We can convert str1 to str2 by inserting ‘b’
        *
        * Example 2:
        * Input: str1 = “robky” str2 = “rocky”
        * Output: 1
        * Explanation: We can convert str1 to str2 by replacing ‘b’ with ‘u’
        *
        * Example 3:
        * Input: str1 = “sunday” str2= “saturday”
        * Output: 3
        * Explanation: We can convert by replacing ‘n’ with ‘r’ and inserting ‘t’ and ‘a’
        * returns      : Integer
        * return type  : int
        */
        public static int StringEdit(string str1, string str2)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing StringEdit()");
            }

            return 0;
        }
    }

}


