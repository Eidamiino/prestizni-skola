using System;
using System.Collections.Generic;
using System.IO;

namespace PalApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> nameDictionary = new Dictionary<string, string>();
            int i, sum = 0;
            string name, smellLevel;
            double avg;

            uploadTable(nameDictionary);

            while (true)
            {
                sum = 0;
                name = getName();

                if (maybeExit(name)) return;

                if (maybeSave(name, nameDictionary)) continue;

                sum = getSum(name, sum);

                avg = getAvg(sum, name);

                smellLevel = getSmellLevel(avg, name);

                nameDictionary.Add(name, smellLevel);

                printTable(nameDictionary);


            }

        }

        private static void uploadTable(Dictionary<string, string> nameDictionary)
        {
            if (File.Exists("C://tmp/SmellyBoys.txt"))
            {
                var lines = File.ReadAllLines("C://tmp/SmellyBoys.txt");
                foreach (var line in lines)
                {
                    if (line.Length == 0)
                    {
                        break;
                    }

                    int dividerPos = line.IndexOf(',');
                    string fileName = line.Substring(0, dividerPos);
                    string fileSmellLevel = line.Substring(dividerPos + 1);
                    nameDictionary.Add(fileName, fileSmellLevel);
                }
            }
        }

        private static bool maybeSave(string name, Dictionary<string, string> nameDictionary)
        {
            if (name == Constants.SaveKeyword)
            {
                foreach (KeyValuePair<string, string> ele in nameDictionary)
                {
                    File.AppendAllText("C://tmp/SmellyBoys.txt", $"{ele.Key},{ele.Value}\n");
                }

                Console.Write("Table updated successfully");
                return true;
            }

            return false;
        }

        private static bool maybeExit(string name)
        {
            if (name == Constants.ExitKeyword)
            {
                return true;
            }

            return false;
        }

        private static void printTable(Dictionary<string, string> nameDictionary)
        {
            Console.WriteLine("\nThe Smell Table: \n*************************");
            foreach (KeyValuePair<string, string> ele in nameDictionary)
            {
                Console.Write($"{ele.Key}\t");
                switch (ele.Value)
                {
                    case Constants.HobosFeet:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case Constants.HorseAss:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case Constants.OnionRinger:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case Constants.Unsmeller:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                }

                Console.WriteLine(ele.Value);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        private static double getAvg(int sum, string name)
        {
            double avg;
            avg = (double) sum / name.Length;
            avg = Math.Round(avg);
            return avg;
        }

        private static int getSum(string name, int sum)
        {
            int i;
            for (i = 0; i < name.Length; i++)
            {
                if (name[i] == ' ')
                {
                    continue;
                }
                sum += name[i];
            }

            return sum;
        }

        private static string getName()
        {
            string name;
            Console.WriteLine("\nInput a name:");
            name = Console.ReadLine();
            return name;
        }

        private static string getSmellLevel(double avg, string name)
        {
            string smellLevel;
            if (avg % 7 == 0 || name.ToUpper() == "HONZA RADA" || name.ToUpper()== "JAN RADA")
            {
                smellLevel = Constants.HobosFeet;
            }
            else if (avg % 5 == 0)
            {
                smellLevel = Constants.HorseAss;
            }
            else if (avg % 3 == 0)
            {
                smellLevel = Constants.OnionRinger;
            }
            else
            {
                smellLevel = Constants.Unsmeller;
            }

            return smellLevel;
        }
    }
}
