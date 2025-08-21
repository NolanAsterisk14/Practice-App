using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 2, 4, };
            int target = 6;
            int[] result = TwoSum(nums, target);
            Array.ForEach(result, i => Console.Write(i.ToString() + ", "));
        }

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
    }
}
