using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Console.Write("Enter string: ");
            input = "1234aBC1ab-1"; //Console.ReadLine();
            string pattern = @"^\d{4}([a-zA-Z_]{2}|[a-zA-Z_]{3})\d([a-zA-Z_]{3}|[a-zA-Z_]{2})-[0-9]$";
            DisplayPatternMatch(pattern, input);

            Console.ReadLine();
        }

        private static void DisplayPatternMatch(string pattern, string subject)
        {
            Regex reEngine = new Regex(pattern);
            Match regExMatch = null;

                regExMatch = reEngine.Match(subject);
                if (regExMatch.Success)
                {
                    Console.WriteLine($"Match: { regExMatch.Success} at position { regExMatch.Index} & length of { regExMatch.Length}");
                }
                else
                {
                    Console.WriteLine("Not a valid PPS Number.");
                }
            
                
        }
    }
}
/*
Write a C# application that asks the user for an input string (see below).  Your application needs to determine if the input string contains a valid PPS number.
Assume that PPS numbers have one of two formats: ddddAAdAAA-d or ddddAAAdAA-d, where d is a digit and A is a character from the alphabet.
Ensure your code prompts the user to enter their first name, surname and then their PPS number on a single line(e.g., “Harry Potter 1234HO5XLF-6”).
*/
