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
            Console.WriteLine();

            int n2 = 5;
            PrintSeriesSum(n2);
            Console.WriteLine();

            int[] A = new int[] { 1, 2, 2, 6 };
            bool check = MonotonicCheck(A);
            Console.WriteLine("MonotonicCheck Output: " + check);
            Console.WriteLine();

            int[] nums = new int[] { 3, 1, 4, 1, 5 };
            int k = 2;
            int pairs = DiffPairs(nums, k);
            Console.WriteLine("DiffPairs Output: " + pairs);
            Console.WriteLine();

            string keyboard = "hijklmnopqrstuvwxyzabcdefg";
            string word = "gobulls";
            int time = BullsKeyboard(keyboard, word);
            Console.WriteLine("BullsKeyboard Output: " + time);
            Console.WriteLine();

            string str1 = "sunday";
            string str2 = "saturday";
            int minEdits = StringEdit(str1, str2);
            Console.WriteLine("StringEdit Output: " + minEdits);

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
                    Console.WriteLine("X lines is " + x);
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
                    Console.Write("Series number n is : " + n);
                    Console.WriteLine();
                    int currentNum = 1; // series start number
                    int sum = 0; // running sum                    
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
                    Console.WriteLine("Array elements are: [" + string.Join(',', n.ToList()) + "]");
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
            Console.WriteLine("4. Diff Pairs Method:");
            int result = 0;           
            try
            {
                if (J != null && J.Length > 1 && k >= 0)
                {
                    Console.WriteLine("Array J elements are: [" + string.Join(',', J.ToList()) + "]");
                    Console.WriteLine("Difference k is: " + k);
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
            Console.WriteLine("5. Bulls Keyboard Method:");
            int numMoves = 0;
            try
            {
                //basic validations for input data - never trust caller
                if (keyboard != null && word != null)
                {
                    Console.WriteLine("Keyboard: " + keyboard + "; Word: " + word);
                    //for quicker search map our keyboard into a dictionary
                    Dictionary<char, int> keyboardDict = new Dictionary<char, int>();
                    for (int i = 0; i < keyboard.Length; i ++)
                    {
                        keyboardDict.Add(keyboard.ElementAt(i), i);
                    }

                    int curPosition = 0;
                    foreach (char charInWord in word)
                    {
                        int newPosition = keyboardDict[charInWord]; //find position where we moved
                        numMoves += Math.Abs(curPosition - newPosition); // add absolute value of the difference between current and new positions   
                        curPosition = newPosition; //after we move from one position to another flip current position to the new position
                    }
                }
                else
                {
                    Console.WriteLine("Please provide a non-null keyboard and word values");
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing BullsKeyboard()");
            }

            return numMoves;
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

        //method performs a series of loops (rounds) to edit the word (str1)
        //each round produces 3 words generated from performing 1 of each operations on the character in each string produced as a result of previous round
        //after each round the results of previous round get discarded
        //method handles edge cases when string are not of equal length
        //uncomment lines 386, 428 and 429 to see all words generated after each round
        public static int StringEdit(string str1, string str2)
        {
            Console.WriteLine("6. Edit String Method:");
            int result = 0;
            try
            {                
                if (str1 != null && str2 != null) //validate strings passed
                {
                    Console.WriteLine("String to edit (str1): " + str1 + "; Template string (str2): " + str2);
                    bool control = true; //control variable for the mail loop 
                    Dictionary<string, int> ops = new Dictionary<string, int>(); //main dictionary containing all words
                    ops.Add(str1, 0); //add str1 param as first word into the main dictionary
                    int ans = 0;
                    //int fullRound = 1; //uncomment this line and lines 417 and 418 to see the information about each round
                    int len = str1.Length > str2.Length ? str1.Length : str2.Length; //find longer string to iterate over it's characters
                    while (control) //loops until final word is constructed
                    {
                        Dictionary<string, int> loopDict = new Dictionary<string, int>(); //in each loop create a new dictionary

                        //iterate through all the words constructed in the previous round (or only inital str1 in case of round 1)
                        for (int i = 0; i < ops.Count; i++)
                        {
                            //get word constructed so far and how many rounds it already went through
                            string str = ops.ElementAt(i).Key;
                            int opNum = ops.ElementAt(i).Value;

                            //iterate over each letter of the longer word (str1 or str2) computed earlier
                            for (int j = 0; j < len; j++) 
                            {
                                char chartAtStr2 = str2.Length - 1 >= j ? str2[j] : char.MinValue; //in case str2 in shorter than str1

                                //when letters at the same index between 2 words don't match perform all 3 operations and store in the temp
                                //dictionary variable loopDict
                                //replace and remove operations only possible when length of the word we are operating on has the given index j
                                if (str.Length - 1 >= j && str[j] != chartAtStr2) 
                                {
                                    AddToDict(loopDict, PerformOperationOnWord(str, chartAtStr2, j, "insert"), (opNum + 1));
                                    AddToDict(loopDict, PerformOperationOnWord(str, chartAtStr2, j, "replace"), (opNum + 1));
                                    AddToDict(loopDict, PerformOperationOnWord(str, chartAtStr2, j, "remove"), (opNum + 1));
                                    break; //perform operations only once to accurately keep track of the number of operations it takes to edit the word
                                } else if (str.Length == j) //handle edge case for insert operation
                                {
                                    AddToDict(loopDict, PerformOperationOnWord(str, chartAtStr2, j, "insert"), (opNum + 1));
                                }
                            }


                        }

                        ops = loopDict; //store current round dictionary and discard all words constructed in the previous round
                        if (ops.ContainsKey(str2)) //exit loop and return the answer when the word we are looking for (str2) is constructed
                        {
                            ans = ops[str2];
                            control = false;
                        }
                        //Console.WriteLine("ROUND " + fullRound + ": " + string.Join(',', ops.Select(kvp => "(" + kvp.Key + "-" + kvp.Value.ToString() + ")")));
                        //fullRound++;

                    }
                    result = ans;
                } else
                {
                    Console.WriteLine("Please provide non-null string1 and string2 values");
                }
            
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured while computing StringEdit()" + e.Message + e.StackTrace);
                
            }

            return result;
        }

        //Method performs one of 3 operations (insert, remove, replace) on the string (word)
        //position - postion of the character within a string to perform an operation on
        //letter (insert and replace operations only) - character to insert or replace
        //operation type of operation to perform (insert, remove, replace)
        public static string PerformOperationOnWord(string word, char letter, int position, string operation)
        {
            
            if ("replace".Equals(operation, StringComparison.InvariantCultureIgnoreCase))
            {
                word = word.Remove(position, 1);
                word = word.Insert(position, letter.ToString());
            } else if ("remove".Equals(operation, StringComparison.InvariantCultureIgnoreCase))
            {
                word = word.Remove(position, 1);                
            } else {                
                word = word.Insert(position, letter.ToString());
            }

            return word;
        }

        //Method accet a dictionary and key-value pair and adds the value to the dictionary or 
        //replaces the value for that key with the one from the pair
        public static void AddToDict(Dictionary<string, int> dict, string str, int num)
        {
            if (dict.ContainsKey(str))
            {
                dict[str] = num;
            } else
            {
                dict.Add(str, num);
            }
        }
    }

}


