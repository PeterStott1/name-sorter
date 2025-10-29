using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;



namespace name_sorter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Invalid args");
                    return;
                }
   
                string outputFilePath = "D:\\Source\\repos\\name-sorter\\name-sorter\\files\\sorted-names-list.txt"; 
                using StreamReader reader = new StreamReader(args[0]);
                string text =  reader.ReadToEnd();
                var orderedNames = OrderNameItems(text.Split("\r\n"));
                WriteToFile(orderedNames, outputFilePath);
                // Using StreamWriter to write each line
                foreach (var nameDict in orderedNames)
                {
                    Console.WriteLine($"{nameDict["FirstName"]} {nameDict["MiddleName"]} {nameDict["LastName"]}");
                    
                }
                Console.WriteLine("File content successfully sorted and saved!");
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred:");
                Console.WriteLine(ex.Message);
            }
        }
        static void WriteToFile(List<Dictionary<string, string>> orderedNames, string outputFilePath)
        {  // Using StreamWriter to write each line
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var line in orderedNames)
                {
                    writer.WriteLine($"{line["FirstName"]} {line["MiddleName"]} {line["LastName"]}");
                }
            }
        }
        static List<Dictionary<string, string>> OrderNameItems(string[] textArr)
        {
            // Split names into a dictionary
            List<Dictionary<string, string>> nameDictionaries = textArr.Select(name =>
            {
                var parts = name.Split(' ');
                return new Dictionary<string, string>
                    {
                        { "FirstName", parts[0] },
                        { "MiddleName", parts.Length > 2 ? parts[1] : "" },
                        { "LastName", parts.Length > 1 ? parts[^1] : "" }
                    };
            }).ToList();
            // Order the dictionaries by the "LastName" alphabetically
            return nameDictionaries.OrderBy(dict => dict["LastName"]).ToList();
        }
    }
}