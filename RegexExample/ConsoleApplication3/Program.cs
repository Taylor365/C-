using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static readonly string FILE_PATH = @"P:\SoftwareDev\Advanced\PPS.txt";
        static readonly string FILE_PATH2 = @"P:\SoftwareDev\Advanced\validPPS.txt";

        static void Main(string[] args)
        {
            /*string input;
            Console.Write("Enter string: ");
            input = "1234aBC1ab-1"; //Console.ReadLine();*/
            string pattern = @" \d{4}([a-zA-Z_]{2}|[a-zA-Z_]{3})\d([a-zA-Z_]{3}|[a-zA-Z_]{2})-[0-9]$";

            using (FileStream fStream = File.OpenRead(FILE_PATH))
            using (TextReader txtReader = new StreamReader(fStream, Encoding.UTF8))
            {
                while (txtReader.Peek() > -1)
                {
                    string input = txtReader.ReadLine();
                    Console.WriteLine(input);
                    DisplayPatternMatch(pattern, input);
                }
            }
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
                using (TextWriter txtWriter = File.AppendText(FILE_PATH2))
                {
                    txtWriter.WriteLine(subject);
                }

            }
            else
            {
                Console.WriteLine("Not a valid PPS Number.");
            }
        }
    }
}

/*Take a copy of your code for the above exercise and instead of reading data entered by the user read the data from a text file.  
Ensure your text file has at least 4 entries worth of data. 
Your code should then write the just the valid PPS numbers to a text file called PPSNums.txt.
*/