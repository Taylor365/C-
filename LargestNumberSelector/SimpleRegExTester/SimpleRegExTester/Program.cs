using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace SimpleRegExTester
{
    class Program
    {
        static readonly string FILENAME_PATTERN = @"(\w+?)\.(doc|pdf|cs|txt)$";
        static readonly string EX5_SRCFILENAME = @"C:\AdvProg\NamesAndPPSNums.txt";
        static readonly string EX5_DESTFILENAME = @"C:\AdvProg\JustValidPPSNums.txt";
        /*
         * Assume that PPS numbers have one of two 
         * formats: ddddAAdAAA-d or ddddAAAdAA-d, where d is a digit and A is a character from the alphabet.
         */
        static readonly string PPS_PATTERN = @"\d{4}(([A-Z]{2}\d[A-Z]{3}-\d)|([A-Z]{3}\d[A-Z]{2}-\d))";
        static readonly string PPS_MULTILINE_PATTERN = @"(?m)(" + PPS_PATTERN + @")";

        static void Main(string[] args)
        {
            string pattern = @"\b";
            string subject = "Heisenberg's Uncertainty Principle";

            DisplayPatternMatch(pattern, subject);

            Console.WriteLine();

            pattern = @"\B";

            DisplayPatternMatch(pattern, subject);

            RunExercises();
        }

        private static void RunExercises()
        {
            bool quitExercises = false;
            do
            {
                Console.WriteLine("Please select the exercise you wish to run (1-5): ");
                string strChoice = Console.ReadLine();
                int exChoice;
                if(int.TryParse(strChoice, out exChoice))
                {
                    if(exChoice >= 1 && exChoice <= 5)
                    {
                        switch (exChoice)
                        {
                            case 1:
                                RunExercise1();
                                break;

                            case 2:
                                RunExercise2();
                                break;

                            case 3:
                                RunExercise3();
                                break;

                            case 4:
                                RunExercise4();
                                break;

                            case 5:
                                RunExercise5();
                                break;

                            default:
                                quitExercises = true;
                                break;
                        }
                    }
                    else
                    {
                        quitExercises = true;
                    }
                }
            } while (!quitExercises);
        }

        private static void RunExercise5()
        {
            // Open source text file
            // Load file names from source file into array
            // Run through regex
            // Open destination text file
            // Copy matched file names to destination file
            string filenames = "";
            MatchCollection filenameMatches;

            using (TextReader txtReader = OpenSourceTextFile())
            {
                filenames = txtReader.ReadToEnd();
                filenameMatches = Regex.Matches(filenames, PPS_MULTILINE_PATTERN);
            }


            using (TextWriter txtWriter = OpenDestinationTextFile())
            {
                foreach (Match filenameMatch in filenameMatches)
                {
                    txtWriter.WriteLine(filenameMatch.Value);
                }
            }
        }

        private static StreamReader OpenSourceTextFile()
        {
            StreamReader txtReader = null;

            try
            {
                FileStream fStream = File.Open(EX5_SRCFILENAME, FileMode.Open);

                txtReader = new StreamReader(fStream, Encoding.UTF8);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return txtReader;
        }

        private static StreamWriter OpenDestinationTextFile()
        {
            StreamWriter txtWriter = null;

            try
            {
                FileStream fStream = File.Open(EX5_DESTFILENAME, FileMode.Create);

                txtWriter = new StreamWriter(fStream, Encoding.UTF8);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return txtWriter;
        }
        private static void RunExercise4()
        {
            bool quit = false;
            do
            {
                Console.WriteLine("Please enter your first name, surname and PPS number (e.g., Harry Potter 1234HO5XLF-6). Press enter only to quit: ");
                string inputData = Console.ReadLine();
                if (!string.IsNullOrEmpty(inputData))
                {
                    DisplayPPSNumber(PPS_PATTERN, inputData);
                }
                else
                {
                    quit = true;
                }
            } while (!quit);
        }

        private static void RunExercise3()
        {
            string[] fileNames = { "myhols.doc", "regexsrfun.pdf", "cc_pin_number.lol", "roadtrip1.jpg", "paris.bmp",
                                   "AdvProgExamSolutions.txt", "_test.dump", "trash_tmp.tmp", "project_final_28082019.doc",
                                    "snarf.cs", "txt.mine.ps" };

            foreach (var filename in fileNames)
            {
                DisplayPatternMatch(FILENAME_PATTERN, filename);
            }
        }

        private static void RunExercise2()
        {
            DisplayPatternMatch(@"\w+?ain\b", "The rain in Spain falls mainly on the plain.");
            DisplayPatternMatch(@"(rain)|(Spain)|(plain)", "The rain in Spain falls mainly on the plain.");
            DisplayPatternMatch(@"((r)|(Sp)|(pl))ain", "The rain in Spain falls mainly on the plain.");
        }

        private static void RunExercise1()
        {
            DisplayPatternMatch("cl(o|i)ck?", "click clock clack clic"); ;
            DisplayPatternMatch("(Yoda)?|Han", "Yoda is cool, Han is a cowboy");
        }

        private static void DisplayPatternMatch(string pattern, string subject)
        {
            Console.WriteLine($"Results for matching \"{pattern}\" against \"{subject}\"", pattern, subject);
            Regex reEngine = new Regex(pattern);

            Match match = reEngine.Match(subject);

            if (match.Success)
            {
                while (match.Success)
                {
                    Console.WriteLine("Match: {0} at position {1} with length of {2} and value of {3}", match.Success, match.Index, match.Length, match.Value);

                    match = match.NextMatch();
                }
            }
            else
            {
                Console.WriteLine("Match: {0}", match.Success);
            }
        }

        private static void DisplayPPSNumber(string ppsPattern, string customerData)
        {
            Regex reEngine = new Regex(ppsPattern);

            Match match = reEngine.Match(customerData);

            if (match.Success)
            {
                Console.WriteLine($"Your PPS number is: {match.Value}");
            }
            else
            {
                Console.WriteLine("Match: {0}", match.Success);
            }
        }
    }
}
