using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filenames = {"myhols.doc", "regexsrfun.pdf", "cc_pin_number.lol", "roadtrip1.jpg", "paris.bmp", "AdvProgExamSolutions.txt", "test.dump", "trash_tmp.tmp", "project_final_28082019.doc"};
            string pattern = @"\.doc$";

            DisplayPatternMatch(pattern, filenames);

            Console.ReadLine();
        }

        private static void DisplayPatternMatch(string pattern, string[] subjects)
        {
            Regex reEngine = new Regex(pattern);
            Match regExMatch = null;
            foreach (string item in subjects)
            {
                regExMatch = reEngine.Match(item);
                if (regExMatch.Success)
                {
                    Console.WriteLine($"Match: { regExMatch.Success} at position { regExMatch.Index} & length of { regExMatch.Length}");
                }
                else
                {
                    Console.WriteLine("No match");
                }
            }
       
        }
    }
}
