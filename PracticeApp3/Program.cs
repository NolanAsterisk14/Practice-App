using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PracticeApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] nums = { 3, 2, 4, };
            //int target = 6;
            //int[] result = TwoSum(nums, target);
            //Array.ForEach(result, i => Console.Write(i.ToString() + ", "));
            //char[][] board = new char[][]
            //{
            //    new char[] { '5','3','.','.','7','.','.','.','.' },
            //    new char[] { '6','.','.','1','9','5','.','.','.' },
            //    new char[] { '.','9','8','.','.','.','.','6','.' },
            //    new char[] { '8','.','.','.','6','.','.','.','3' },
            //    new char[] { '4','.','.','8','.','3','.','.','1' },
            //    new char[] { '7','.','.','.','2','.','.','.','6' },
            //    new char[] { '.','6','.','.','.','.','2','8','.' },
            //    new char[] { '.','.','.','4','1','9','.','.','5' },
            //    new char[] { '.','.','.','.','8','.','.','7','9' }
            //};
            //Console.WriteLine(IsValidSudoku(board));
            //char[] str = new char[] { 'h', 'e', 'l', 'l', 'o' };
            //ReverseString(str);
            //Array.ForEach(str, i => Console.Write(i.ToString() + ", "));

            // Clean up and get initial memory
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            long memoryBefore = GC.GetTotalMemory(true);

            // Start timing
            var stopwatch = Stopwatch.StartNew();

            // Code to measure
            Console.WriteLine(MyAtoi("042"));

            // Stop timing
            stopwatch.Stop();

            // Clean up and get final memory
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            long memoryAfter = GC.GetTotalMemory(true);

            // Output results (these allocations are outside the measured block)
            Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Memory used: {memoryAfter - memoryBefore} bytes");
        }

        //************************
        //*****Arrays Section*****
        //************************

        //Check if a ransomnote can be constructed using magazine characters
        public bool CanConstruct(string ransomNote, string magazine)
        {
            List<char> ransomList = ransomNote.ToList();
            List<char> magazineList = magazine.ToList();
            bool canConstruct = true;

            foreach (char letter in ransomList)
            {
                if (magazineList.Contains(letter))
                {
                    magazineList.Remove(letter);
                }
                else
                {
                    canConstruct = false;
                    break;
                }
            }

            return canConstruct;
        }

        //Remove any duplicate values and decrement length for each value removed. Return new length as k.
        //The code below is TRASH. Terrible runtime complexity and memory use
        public static int RemoveDuplicates(int[] nums)
        {
            int k = nums.Length;                                        //Set initial length and decrement for each removed element

            for (int i = 0; i < nums.Length; i++)                       //Loop whole array once
            {
                Recheck:
                if (i < nums.Length - 1 && i < k - 1 && nums[i] == nums[i + 1])    //Check if there is a duplicate next to item in the sequence unless at end
                {
                    k--;                                        //Decrement length of 'new' array

                    for (int j = i; j < nums.Length; j++)       //Loop through rest of array from where duplicate was found
                    {
                        if (j < k)                              //If total length not reached, slide each element left by one index
                        {
                            nums[j] = nums[j + 1];
                        }
                    }
                    goto Recheck;                               //Check from same index again to ensure duplicates aren't skipped
                }
            }

            return k;
        }

        //Much better solution for the above code
        //public int RemoveDuplicates(int[] nums)
        //{
        //    var uniq = 0;

        //    if (nums.Length < 2) return nums.Length;

        //    var lastVal = nums[0];
        //    for (var i = 1; i < nums.Length; ++i)
        //    {
        //        if (nums[i] != lastVal)
        //        {
        //            uniq = uniq + 1;
        //            lastVal = nums[i];
        //            nums[uniq] = lastVal;
        //        }
        //    }

        //    return uniq + 1;
        //}

        //Rotate index position of values in an array by k steps.
        //This solution doesn't work if the array length and k are both even. I tried ¯\_(ツ)_/¯
        public static void Rotate(int[] nums, int k)
        {
            int lastReplaced = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                {
                    lastReplaced = nums[(i + k) % (nums.Length)];
                    nums[(i + k) % (nums.Length)] = nums[i];
                }
                else
                {
                    int temp = lastReplaced;
                    lastReplaced = nums[((i + 1) * k) % (nums.Length)];
                    nums[((i + 1) * k) % (nums.Length)] = temp;
                }
            }
        }

        //Better solution for the above code
        //public static void Rotate(int[] nums, int k)
        //{
        //    int n = nums.Length;
        //    k = k % n; // In case k > n

        //    // Helper to reverse a portion of the array
        //    void Reverse(int left, int right)
        //    {
        //        while (left < right)
        //        {
        //            int temp = nums[left];
        //            nums[left] = nums[right];
        //            nums[right] = temp;
        //            left++;
        //            right--;
        //        }
        //    }

        //    Reverse(0, n - 1);
        //    Reverse(0, k - 1);
        //    Reverse(k, n - 1);
        //}

        //Check if a set of ints contains any duplicate values
        //Good memory use, terrible runtime complexity
        public static bool ContainsDuplicate(int[] nums)
        {
            List<int> occurrences = new List<int>();

            foreach (int num in nums)
            {
                if (occurrences.Contains(num))
                {
                    return true;
                }
                else
                {
                    occurrences.Add(num);
                }
            }

            return false;
        }

        //Better solution for the above code, but worse memory usage
        //public static bool ContainsDuplicate(int[] nums)
        //{
        //    HashSet<int> occurrences = new HashSet<int>();

        //    foreach (int num in nums)
        //    {
        //        if (!occurrences.Add(num))
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}

        //Find the one non-paired value in an array of other paired values
        //I did not come up with this bitwise magic, this is very interesting
        public static int SingleNumber(int[] nums)
        {
            int result = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                result ^= nums[i];
            }

            return result;
        }

        //Find the intersecting integers between two arrays.
        //Must return same number of intersections for each value, but can be in any order.
        //This solution is pretty good, using a dictionary for counting occurences is slightly better runtime 
        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);
            List<int> intersections = new List<int>();

            int pointerA = 0;
            int pointerB = 0;

            while (pointerA < nums1.Length && pointerB < nums2.Length)
            {
                if (nums1[pointerA] == nums2[pointerB])
                {
                    intersections.Add(nums1[pointerA]);
                    pointerA++;
                    pointerB++;
                }
                else if (nums1[pointerA] < nums2[pointerB])
                {
                    pointerA++;
                }
                else
                {
                    pointerB++;
                }
            }

            return intersections.ToArray();
        }

        //Example of the dictionary method
        //public int[] Intersect(int[] nums1, int[] nums2)
        //{
        //    Dictionary<int, int> countMap = new Dictionary<int, int>();
        //    List<int> result = new List<int>();

        //    foreach (int num in nums1)
        //    {
        //        if (countMap.ContainsKey(num))
        //        {
        //            countMap[num]++;
        //        }
        //        else
        //        {
        //            countMap[num] = 1;
        //        }
        //    }

        //    foreach (int num in nums2)
        //    {
        //        if (countMap.ContainsKey(num) && countMap[num] > 0)
        //        {
        //            result.Add(num);
        //            countMap[num]--;
        //        }
        //    }

        //    return result.ToArray();
        //}

        //Given an array of ints that represent one large int, increment it by one
        //Almost perfect method here. Linear runtime, memory usage could be a little better
        public static int[] PlusOne(int[] digits)
        {
            int target = digits.Length - 1;
            int[] newArray = (int[])digits.Clone();

            while (true)
            {
                if (target != 0 && newArray[target] != 9)
                {
                    newArray[target]++;
                    break;
                }
                else if (target != 0 && newArray[target] == 9)
                {
                    newArray[target] = 0;
                    target--;
                }
                else if (target == 0 && newArray[target] != 9)
                {
                    newArray[target]++;
                    break;
                }
                else
                {
                    int[] newNewArray = new int[newArray.Length + 1];
                    newNewArray[0] = 1;
                    return newNewArray;
                }
            }

            return newArray;
        }

        //Move all zeroes in an array to the end while keeping the non-zero elements in order
        //Both of my solution attempts sucked in terms of time complexity
        public static void MoveZeroes(int[] nums)
        {
            //My first solution attempt, hint steered me to different solution
            //Lol, this doesn't even work and I don't care to fix it because it's bad
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (nums[i] == 0)
            //    {
            //        for (int j = i; j < nums.Length - 1; j++)
            //        {
            //            int temp = nums[j + 1];
            //            nums[j + 1] = nums[j];
            //            nums[j] = temp;
            //        }
            //    }
            //}

            int p1 = 0;
            int p2 = 0;

            while (true)
            {
                if (nums[p1] == 0 && p1 < nums.Length - 1)
                {
                    p2 = p1 + 1;

                    while (p2 < nums.Length)
                    {
                        if (nums[p2] != 0)
                        {
                            nums[p1] = nums[p2];
                            nums[p2] = 0;
                            break;
                        }
                        p2++;
                    }

                    p1++;
                }
                else if (p1 < nums.Length - 1)
                {
                    p1++;
                }
                else
                {
                    break;
                }
            }
        }

        //Ideal solution for the above code
        //public void MoveZeroes(int[] nums)
        //{
        //    if (nums.Length == 1) return;

        //    int wPtr = 0;
        //    for (int rPtr = 0; rPtr < nums.Length; rPtr++)
        //    {
        //        if (nums[rPtr] != 0)
        //        {
        //            int temp = nums[wPtr];
        //            nums[wPtr] = nums[rPtr];
        //            nums[rPtr] = temp;
        //            wPtr++;
        //        }
        //    }
        //}

        //For an array of ints, return two indices of the array that add up to target
        //Assume there is only one valid solution in the set. Same index can't be used twice
        //This solution is pretty ideal for runtime and memory. (I got help with figuring it out though)
        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (numbers.ContainsKey(target - nums[i]))
                {
                    return new int[] { numbers[target - nums[i]], i };
                }
                if (!numbers.ContainsKey(nums[i]))
                {
                    numbers.Add(nums[i], i);
                }
            }

            return null;
        }

        //Determine if a 9x9 jagged array of chars follows the rules of sudoku
        //This solution is pretty good, beat 72% for memory but 45% for runtime. Was only 4ms though so I'll take it.
        public static bool IsValidSudoku(char[][] board)
        {
            HashSet<char> uniqueA = new HashSet<char>();                //Used to accumulate values in 3x3 cells
            HashSet<char> uniqueB = new HashSet<char>();
            HashSet<char> uniqueC = new HashSet<char>();
            for (int i = 0; i < board.Length; i++)
            {
                if (i == 3 || i == 6)                                   //Reset the accumulated values every 3 rows
                {
                    uniqueA.Clear();
                    uniqueB.Clear();
                    uniqueC.Clear();
                }
                HashSet<char> unique = new HashSet<char>();             //Used to check rows and columns
                for (int j = 0; j < board[i].Length; j++)            
                {
                    if (!unique.Add(board[i][j]) && board[i][j] != '.') //Check that the current row is unique
                    {
                        Console.WriteLine("Row not unique");
                        return false;
                    }
                    if (j < 3)                                          //Check that each 3x3 cell is unique
                    {
                        if (!uniqueA.Add(board[i][j]) && board[i][j] != '.')
                        {
                            Console.WriteLine($"Cell A not unique on pass {i}");
                            return false;
                        }
                    }
                    else if (j < 6)
                    {
                        if (!uniqueB.Add(board[i][j]) && board[i][j] != '.')
                        {
                            Console.WriteLine($"Cell B not unique on pass {i}");
                            return false;
                        }
                    }
                    else if (j < 9)
                    {
                        if (!uniqueC.Add(board[i][j]) && board[i][j] != '.')
                        {
                            Console.WriteLine($"Cell C not unique on pass {i}");
                            return false;
                        }
                    }
                }
                unique.Clear();                                         //Clear unique storage before checking columns
                for (int j = 0; j < board.Length; j++)            
                {
                    if (!unique.Add(board[j][i]) && board[j][i] != '.') //Check that the current column is unique
                    {
                        Console.WriteLine("Column not unique");
                        return false;
                    }
                }
            }
            return true;
        }

        //This solution is a little better runtime - 2ms
        //public bool IsValidSudoku(char[][] board)
        //{
        //    HashSet<Char>[] rows = new HashSet<Char>[9];
        //    HashSet<Char>[] cols = new HashSet<Char>[9];
        //    HashSet<Char>[] index = new HashSet<Char>[9];

        //    for (var i = 0; i < 9; i++)
        //    {
        //        rows[i] = new HashSet<char>();
        //        cols[i] = new HashSet<char>();
        //        index[i] = new HashSet<char>();
        //    }

        //    for (var i = 0; i < 9; i++)
        //    {
        //        for (var j = 0; j < 9; j++)
        //        {
        //            if (board[i][j] == '.')
        //                continue;

        //            if (rows[i].Contains(board[i][j]))
        //            {
        //                return false;
        //            }
        //            rows[i].Add(board[i][j]);

        //            if (cols[j].Contains(board[i][j]))
        //            {
        //                return false;
        //            }
        //            cols[j].Add(board[i][j]);

        //            int boxIndex = (i / 3) * 3 + (j / 3);
        //            if (index[boxIndex].Contains(board[i][j]))
        //            {
        //                return false;
        //            }
        //            index[boxIndex].Add(board[i][j]);
        //        }
        //    }

        //    return true;
        //}

        //Given a 2D matrix of ints representing an image, rotate the image by 90 degrees clockwise. (in place)
        //I wasn't able to figure this one out, got help with the solution
        public static void Rotate(int[][] matrix)
        {
            int n = matrix.Length;
            // Process layers from outermost to innermost
            for (int layer = 0; layer < n / 2; layer++)
            {
                int first = layer;
                int last = n - 1 - layer;
                for (int i = first; i < last; i++)
                {
                    int offset = i - first;
                    // Save top
                    int top = matrix[first][i];
                    // left -> top
                    matrix[first][i] = matrix[last - offset][first];
                    // bottom -> left
                    matrix[last - offset][first] = matrix[last][last - offset];
                    // right -> bottom
                    matrix[last][last - offset] = matrix[i][last];
                    // top -> right
                    matrix[i][last] = top;
                }
            }
        }

        //*************************
        //*****Strings Section*****
        //*************************

        //Given a string represented as a char array, reverse the string in-place with O(1) extra memory
        //Pretty good solution, 100% on runtime and 89% on memory usage
        public static void ReverseString(char[] s)
        {
            int end = s.Length - 1;
            //For readability, I could use n for length like above example
            //I won't to save memory use

            for (int start = 0; start < s.Length / 2; start++)
            {
                char temp = s[start];                   
                s[start] = s[end];                      
                s[end] = temp;                          
                end--;                                  
            }
        }

        //*************************************************************************************************************************
        //***********It was at this point I discovered the LeetCode runtime/memory usage graphs were wildly inconsistent***********
        //***********************I will be measuring my own runtime and memory usage in code from henceforth***********************
        //*************************************************************************************************************************


        //Given a signed 32-bit int x, return x with its digits reversed. If reversing x causes
        //The value to go outside the signed 32-bit integer range [-2^31, 2^31 - 1], return 0
        //Assume the environment doesn't allow you to store 64-bit ints.
        //This method works, but could have better runtime (~6 ms). Memory use: (7496 bytes)
        public static int Reverse(int x)
        {
            try
            {
                int num = Math.Abs(x);
                string strNum = new string(num.ToString().Reverse().ToArray());
                num = int.Parse(strNum);
                num = x < 0 ? -num : num;
                return num;
            }
            catch (OverflowException e)
            {
                return 0;
            }
        }

        //This method works much better for runtime(~0-1 ms) memory use: (7496 bytes)
        //public static int Reverse(int x)
        //{
        //    int rem = 0;
        //    int temp = 0;
        //    int res = 0;
        //    while (x != 0)
        //    {
        //        rem = x % 10;
        //        temp = res * 10 + rem;

        //        if ((temp - rem) / 10 == res)
        //            res = temp;
        //        else
        //            return 0;

        //        x /= 10;
        //    }

        //    return res;
        //}

        //Given a string, find the first non-repeating character in it and return its index. If it does not exist, return -1.
        //Method works, but could have better runtime (~4 ms) memory use: (7564 bytes)
        public static int FirstUniqChar(string s)
        {
            Dictionary<char, int> counts = new Dictionary<char, int>();

            foreach (char letter in s)
            {
                if (!counts.ContainsKey(letter))
                {
                    counts.Add(letter, 1);
                }
                else
                {
                    counts[letter]++;
                }
            }

            foreach (char key in counts.Keys)
            {
                if (counts[key] == 1)
                {
                    return s.IndexOf(key);
                }
            }
            return -1;
        }

        //Better solution for above. Runtime (~0-1 ms) Memory use: (7496 bytes)
        //public static int FirstUniqChar(string s)
        //{
        //    if (s.Length == 1)
        //        return 0;

        //    //uint* arr = stackalloc uint[26]; 
        //    int[] arr = new int[26];
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        arr[s[i] - 'a']++;
        //    }
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        if (arr[s[i] - 'a'] == 1)
        //            return i;
        //    }

        //    return -1;
        //}

        //Given two strings s and t, return true if t is an anagram of s, and false otherwise.
        //Works, but could have better runtime (~6 ms) Memory (7052 bytes)
        public static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            int[] counts1 = new int[26];
            int[] counts2 = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                counts1[s[i] - 'a']++;
            }
            for (int i = 0; i < t.Length; i++)
            {
                counts2[t[i] - 'a']++;
            }

            return counts1.SequenceEqual(counts2);
        }

        //Better solution for above. Runtime (~0-1 ms) Memory (6984 bytes)
        //public static bool IsAnagram(string s, string t)
        //{
        //    if (s.Length != t.Length) return false;

        //    var freq = new int[26];
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        freq[s[i] - 'a']++;
        //        freq[t[i] - 'a']--;
        //    }
        //    for (int i = 0; i < 26; i++)
        //    {
        //        if (freq[i] != 0) return false;
        //    }
        //    return true;
        //}

        //Given a string s, return true if it is a palindrome, or false otherwise (after removing all non-alphanumeric chars)
        //Decent solution, Runtime (~6 ms) Memory (7300 bytes)
        public static bool IsPalindrome(string s)
        {
            string sLow = s.ToLower();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < sLow.Length; i++)
            {
                if (char.IsLetterOrDigit(sLow[i]))
                {
                    sb.Append(sLow[i]);
                }
            }
            if (sb.ToString() == new string(sb.ToString().Reverse().ToArray()))
            {
                return true;
            }
            return false;
        }

        //Better solution for above, Runtime (~0-1 ms) Memory (6984 bytes)
        //public static bool IsPalindrome(string s)
        //{
        //    int len = s.Length;
        //    StringBuilder sb = new StringBuilder();
        //    for (int i = 0; i < len; i++)
        //    {
        //        if (('0' <= s[i] && s[i] <= '9') || ('a' <= s[i] && s[i] <= 'z')) sb.Append(s[i]);
        //        if ('A' <= s[i] && s[i] <= 'Z') sb.Append((char)(s[i] + 32));
        //    }

        //    for (int i = 0; i < sb.Length / 2; i++)
        //    {
        //        if (sb[i] != sb[sb.Length - 1 - i]) return false;
        //    }
        //    return true;
        //}

        //Convert a string to a 32-bit signed integer. Ignore leading whitespace, determine sign by presence of '-' or '+' at start, defaulting to positive
        //Skip leading zeros and read all following digits, stopping if a non-digit character is encountered or end of string. If no digits read, default to 0.
        //If out of 32-bit range, round to nearest valid signed value
        //Decent solution, Runtime (~1ms) Memory (7512 bytes)
        public static int MyAtoi(string s)
        {
            StringBuilder sb = new StringBuilder("0");
            int parsedInt = 0;
            bool isNegative = false;
            bool signChecked = false;
            bool nonZeroSeen = false;

            bool isNumber(char c)
            {
                return (c >= '0' && c <= '9');
            }
            bool isNonZero(char c)
            {
                return (c > '0' && c <= '9');
            }
            try
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (!signChecked)               //First step of parsing if sign hasn't been seen (or a digit)
                    {                               //Ignore white space, check for sign (set flag if found), stop if other symbols are encountered
                        if (s[i] == ' ')
                        {
                            continue;
                        }
                        if (s[i] == '-')
                        {
                            isNegative = true;
                            signChecked = true;
                            continue;
                        }
                        if (s[i] == '+')
                        {
                            signChecked = true;
                            continue;
                        }
                        if (!isNumber(s[i]))
                        {
                            break;
                        }
                    }
                    if (!nonZeroSeen)               //Second step of parsing if non-zero digit hasn't been seen 
                    {                               //Check for digit, if non-zero, set sb to s[i] and flag nonZeroSeen / signChecked
                        if (isNumber(s[i]))         //If it is number, but is zero, flag signChecked
                        {                           //Stop if other symbols are encountered
                            if (isNonZero(s[i]))
                            {
                                sb[0] = s[i];
                                signChecked = true;
                                nonZeroSeen = true;
                                continue;
                            }
                            else
                            {
                                signChecked = true;
                                continue;
                            }
                        }
                        if (signChecked && !isNumber(s[i]))
                        {
                            break;
                        }
                    }
                    else                            //Last step of parsing if non-zero digits have already been seen
                    {                               //Check for digit, and add to sb
                        if (isNumber(s[i]))         //Stop if other symbols are encountered
                        {
                            sb.Append(s[i]);
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                //Assign value from stringbuilder and sign it if negative
                parsedInt = isNegative ? -int.Parse(sb.ToString()) : int.Parse(sb.ToString());
            }
            catch (OverflowException e)             //Handle overflows
            {
                if (isNegative)
                {
                    parsedInt = int.MinValue;
                }
                else
                {
                    parsedInt = int.MaxValue;
                }
            }

            return parsedInt;
        }

        //Comparable, but less verbose solution than above Runtime (~0-1 ms) Memory (7496 bytes)
        //public static int MyAtoi(string s)
        //{
        //    if (string.IsNullOrEmpty(s)) return 0;

        //    int i = 0, n = s.Length;
        //    long result = 0; // use long to detect overflow
        //    int sign = 1;

        //    // 1. Ignore leading whitespaces
        //    while (i < n && s[i] == ' ')
        //    {
        //        i++;
        //    }

        //    // If string only had spaces
        //    if (i >= n) return 0;

        //    // 2. Handle sign
        //    if (s[i] == '+' || s[i] == '-')
        //    {
        //        sign = (s[i] == '-') ? -1 : 1;
        //        i++;
        //    }

        //    // 3. Convert digits
        //    while (i < n && char.IsDigit(s[i]))
        //    {
        //        int digit = s[i] - '0';
        //        result = result * 10 + digit;

        //        // 4. Handle overflow immediately
        //        if (sign == 1 && result > Int32.MaxValue)
        //        {
        //            return Int32.MaxValue;
        //        }
        //        if (sign == -1 && -result < Int32.MinValue)
        //        {
        //            return Int32.MinValue;
        //        }

        //        i++;
        //    }

        //    return (int)(sign * result);
        //}
    }
}
