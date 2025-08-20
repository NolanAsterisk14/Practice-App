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
            int[] nums = new int[] {1, 2, 3, 4, 5, 6, 7, 8};
            int k = 2;

            Rotate(nums, k);
            Array.ForEach(nums, i => Console.Write(i.ToString() + ", "));
        }

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


    }
}
