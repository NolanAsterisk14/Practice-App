using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PracticeAppIO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileString = String.Empty;                               //Create storage string for file contents
            //Set project path to where the program.cs file is located
            string projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            string inputPath = Path.Combine(projectPath, "input.txt");      //Create input path
            string outputPath = Path.Combine(projectPath, "output.txt");    //Create output path
            try
            {
                using (StreamReader sr = new StreamReader(inputPath))
                {
                    fileString = sr.ReadToEnd();                            //Try to read the file's contents at the path
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: The file could not be read.");    //Catch errors
                Console.WriteLine(e.Message);
            }

            string[] values = null;                                         //Create array for input values
            List<float> nums = new List<float>();                           //Create list for converted floats
            float number = 0f;                                              //Create container float for storing tryparse result

            if (fileString != String.Empty)
            {
                values = fileString.Split(',');                             //Separate the input string using commas
            }

            foreach (string value in values)                                //Add all values that can be floats to nums list
            {
                if (float.TryParse(value, out number))
                {
                    nums.Add(number);                                       
                }
            }

            try                                                             //Try to output the average to a file
            {
                using (StreamWriter sw = new StreamWriter(outputPath))
                {
                    sw.WriteLine($"The caluclated average from input.txt is: {Average(nums)}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: The file could not be written.");    //Catch errors
                Console.WriteLine(e.Message);
            }

        }

        static float Average(List<float> numsToAverage)
        {
            float average = 0f;                                             
            
            foreach (float num in numsToAverage)                            //Add all nums together
            {
                average += num;
            }

            average = average / numsToAverage.Count;

            return average;
        }
    }
}
