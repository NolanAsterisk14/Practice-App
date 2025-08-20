using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PracticeApp
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            List<float> inputNums = new List<float>();
            bool isDone = false;
            
            Console.WriteLine("Please enter the numbers you would like to average.");
            Console.WriteLine("Press enter after each number, and type \"done\" when you are finished.");
            
            while (!isDone)
            {
                Console.Write("Next number:");
                var inputVal = Console.ReadLine();                  //Prompt for input
                float inputNum = 0;

                if (inputVal != "done")                             //Check for break condition
                {
                    if (float.TryParse(inputVal, out inputNum))     //Check input for float, if so, add to list
                    {
                        inputNums.Add(inputNum);
                    }
                    else                                            //Handle incorrectly formatted inputs
                    {
                        Console.WriteLine("Error: Please input numeric values only.");
                    }
                }
                else
                {
                    isDone = true;
                }
            }

            Console.Write("The average of the values is:");
            Console.Write(Average(inputNums));                      //Output the value
            
        }

        public static float Average(List<float> inputList)
        {
            float avg = 0;

            foreach (float num in inputList)                        //Add all items from the input list to the average value
            {
                avg += num;
            }

            avg = avg / inputList.Count;                            //Divide by the number of items in the list to get the average

            return avg;
        }
    }
}
