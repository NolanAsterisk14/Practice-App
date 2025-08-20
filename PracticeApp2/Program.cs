using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApp2
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<float> inputNums = new List<float>();                              //All numbers of input

            Console.WriteLine("Please enter each number you want to average, press enter after each number.");
            Console.WriteLine("When you are done, enter \'done\' to calculate the average.");

            while (true)
            {
                float temp;
                Console.Write("Next number: ");
                string input = Console.ReadLine();                                  //Get input from user

                if (input.ToLower() == "done")                                      //Check for break condition
                {
                    break;
                }

                if (float.TryParse(input, out temp))                                //Check for float type
                {
                    inputNums.Add(temp);
                }
                else                                                                //Handle error conditions
                {
                    Console.WriteLine("Error: please enter numeric values only.");
                }
            }

            if (inputNums.Count > 0)
            {
                Console.Write($"The modal values of the inputted values are: {String.Join(", ", Mode(inputNums))}");
                //Console.Write($"The median of the inputted values is: {Median(inputNums)}");
                //Console.Write($"The average of the inputted values is: {Average(inputNums)}");
                //Console.WriteLine("The list before removing outliers: ");
                //foreach (float num in inputNums)
                //{
                //    Console.WriteLine(num);
                //}
                //Console.WriteLine("The list after removing the outliers: ");
                //foreach (float num in ExcludeOutliers(inputNums))
                //{
                //    Console.WriteLine(num);
                //}
                //Console.WriteLine($"The average of the inputted values is: {inputNums.Average()}");
            }
            else                                                                    //Handle empty list
            {
                Console.WriteLine("No values inputted, no average to caclulate.");
            }
        }

        public static float Average(List<float> allNums)
        {
            float sum = 0;

            foreach (float num in allNums)                                          //Add all floats together
            {
                sum += num;
            }

            float average = sum / allNums.Count;                                    //Calculate the average

            return average;
        }

        public static List<float> ExcludeOutliers(List<float> allNums)
        {
            allNums.Sort();
            allNums.Remove(allNums[0]);
            allNums.Remove(allNums[allNums.Count - 1]);

            return allNums;
        }

        public static float Median(List<float> allNums)
        {
            float median = 0;

            if (allNums.Count % 2 == 0)                                             //Median case for an even number of values
            {
                median += allNums[allNums.Count / 2];                               //Get upper middle value
                median += allNums[(allNums.Count / 2) - 1];                         //Get lower middle value
                median = median / 2f;
            }
            else                                                                    //Median case for an odd number of values
            {
                int index = allNums.Count / 2;                                      //Get the middle index of the values (accounting for 0 based index)
                median = allNums[index];
            }
            return median;
        }

        public static List<float> Mode(List<float> allNums)
        {
            Dictionary<float, int> numOccurrence = new Dictionary<float, int>();

            foreach (float num in allNums)
            {
                if (numOccurrence.ContainsKey(num))                                 //Check dictionary for number occurrence, if so increment
                {
                    numOccurrence[num]++;
                }
                else                                                                //If no occurrence, add key with value of 1
                {
                    numOccurrence[num] = 1;
                }
            }

            float popularCount = 0;
            foreach (var pair in numOccurrence)
            {
                if (pair.Value > popularCount)                                      //If the count of the number is higher than has yet been seen, set it as highest
                {
                    popularCount = pair.Value;
                }
            }

            List<float> modalValues = new List<float>();
            foreach (var pair in numOccurrence)                                     //Add all modal key values from dictionary that match the popular count
            {
                if (pair.Value == popularCount)
                {
                    modalValues.Add(pair.Key);
                }
            }

            return modalValues;
        }
    }
}
