using System;
using System.Collections.Generic;
using System.IO;


namespace PalApp
{
    internal class Program
    {
        enum SmellType {Unsmeller,OnionRinger,HorseAss,HobosFeet}
        static Dictionary<string, SmellType> nameDictionary = new Dictionary<string, SmellType>();

        static void Main(string[] args)
        {
            loadFromFile(nameDictionary);
            while (true) {
                var sum = 0;
                var name = getName();

                if (maybeExit(name)) Environment.Exit(0);
                if (maybeSave(name, nameDictionary)) continue;
                if(isDuplicate(name)) continue;

                sum = calculateSum(name, sum);
                var avg = calculateAvg(sum, name);

                SmellType smellLevel= calculateSmellLevel(avg, name); ;
                nameDictionary.Add(name, smellLevel);

                printTable(nameDictionary);
            }
        }

        private static bool isDuplicate(string name)
        {
            if (nameDictionary.ContainsKey(name)) {
                Console.WriteLine("\nThis name has already been entered");
                return true;
            }
            return false;
        }

        private static void loadFromFile(Dictionary<string, SmellType> nameDictionary)
        {
            if (File.Exists( Constants.PathToFile)) {
                var lines = File.ReadAllLines( Constants.PathToFile);
                foreach (var line in lines) {
                    if (line.Length == 0)
                        break;
                    string fileName = line.Split(Constants.Divider)[0];
                    SmellType fileSmellLevel = (SmellType)Convert.ToInt32(line.Split(Constants.Divider)[1]);
                    nameDictionary.Add(fileName, fileSmellLevel);
                }
            }
        }
        private static string getName()
        {
            string name;
            Console.WriteLine("Input a name:");
            name = Console.ReadLine();
            return name;
        }
        private static bool maybeExit(string name)
        {
            if (name == Constants.ExitKeyword)
                return true;
            return false;
        }

        private static bool maybeSave(string name, Dictionary<string, SmellType> nameDictionary)
        {
            if (name == Constants.SaveKeyword)
            {
                File.WriteAllText(Constants.PathToFile, "");
                foreach (KeyValuePair<string, SmellType> ele in nameDictionary)
                {
                    File.AppendAllText(Constants.PathToFile, $"{ele.Key},{(int) ele.Value}\n");
                }
                Console.Write("Table updated successfully");
                return true;
            }
            return false;
        }

        private static int calculateSum(string name, int sum)
        {
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == ' ')
                    continue;
                sum += name[i];
            }
            return sum;
        }
        private static double calculateAvg(int sum, string name)
        {
            double avg;
            avg = (double)sum / name.Length;
            avg = Math.Round(avg);
            return avg;
        }
        private static SmellType calculateSmellLevel(double avg, string name)
        {
            if (avg % 7 == 0 || name.ToUpper() == "HONZA RADA" || name.ToUpper() == "JAN RADA")
                return SmellType.HobosFeet;
            
            if (avg % 5 == 0)
                return SmellType.HorseAss;
            
            if (avg % 3 == 0)
                return SmellType.OnionRinger;
            
            return SmellType.Unsmeller;
        }
        private static void printTable(Dictionary<string, SmellType> nameDictionary)
        {
            Console.WriteLine($"\nThe Smell Table: \nExit:{Constants.ExitKeyword}\tSave:{Constants.SaveKeyword}\n*************************");
            foreach (KeyValuePair<string, SmellType> ele in nameDictionary)
            {
                Console.Write($"{ele.Key}\t");
                switch (ele.Value)
                {
                    case SmellType.HobosFeet:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(Constants.HobosFeet);
                        break;
                    case SmellType.HorseAss:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(Constants.HorseAss);
                        break;
                    case SmellType.OnionRinger:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(Constants.OnionRinger);
                        break;
                    case SmellType.Unsmeller:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(Constants.Unsmeller);
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.WriteLine("\n");
        }
    }
}
