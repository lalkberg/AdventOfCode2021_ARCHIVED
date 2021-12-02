using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    class Program
    {
        private static string dataPath = @"C:\Users\leoal\source\repos\AdventOfCode\Data\";
        private static int currentDate = 0;

        static void Main()
        {
            //Day1();
            Day2();
        }

        private static string[] GetInputs(int date)
        {
            currentDate = date;
            return System.IO.File.ReadAllLines($"{dataPath}input 12-{currentDate}.txt");
        }

        private static void Day1()
        {
            string[] inputStrings = GetInputs(1);
            Console.WriteLine($"There are a total {inputStrings.Length} entries.");

            int[] inputInts = new int[inputStrings.Length];

            int biggerCount = 0;

            for (int i = 0; i < inputStrings.Length; i++)
            {
                inputInts[i] = Int32.Parse(inputStrings[i]);

                if (i != 0)
                {
                    if (inputInts[i] > inputInts[i - 1]) biggerCount++;
                }
            }

            Console.WriteLine($"The number of measurments larger than the last one is {biggerCount}.");

            biggerCount = 0;

            List<int> measurementWindows = new List<int>();

            for (int i = 0; i < inputInts.Length - 2; i++)
            {
                int measurementWindow = inputInts[i] + inputInts[i + 1] + inputInts[i + 2];

                measurementWindows.Add(measurementWindow);
            }

            for (int i = 0; i < measurementWindows.Count; i++)
            {
                if (i != 0)
                {
                    if (measurementWindows[i] > measurementWindows[i - 1]) biggerCount++;
                }
            }

            Console.WriteLine($"The number of measurement windows (stacks of three measurements) larger than the last one is {biggerCount}.");
            Console.ReadKey();
        }

        private static void Day2()
        {
            string[] inputStrings = GetInputs(2);

            int horizontal = 0;
            int depth = 0;

            for (int i = 0; i < inputStrings.Length; i++)
            {
                string[] splitString = inputStrings[i].Split(' ');
                int distance = int.Parse(splitString[1]);

                switch (splitString[0])
                {
                    case "forward":
                        horizontal += distance;
                        break;
                    case "down":
                        depth += distance;
                        break;
                    case "up":
                        depth -= distance;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"The submarine has traveled {horizontal} units forward and {depth} units down. \nThe answer to Part 1 is {horizontal * depth}.");

            horizontal = 0;
            depth = 0;
            int aim = 0;

            for (int i = 0; i < inputStrings.Length; i++)
            {
                string[] splitString = inputStrings[i].Split(' ');
                int distance = int.Parse(splitString[1]);

                switch (splitString[0])
                {
                    case "forward":
                        horizontal += distance;
                        if (aim != 0)
                        {
                            depth += distance * aim;
                        }
                        break;
                    case "down":
                        aim += distance;
                        break;
                    case "up":
                        aim -= distance;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"The submarine has traveled {horizontal} units forward and {depth} units down. \nThe answer to Part 2 is {horizontal * depth}.");
            Console.ReadKey();
        }
    }
}