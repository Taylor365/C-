using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace BettingProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            HotTipster tipster = new HotTipster();
            Boolean quit = false;
            string[] blist = null;
            do
            {
                Console.WriteLine("*** Welcome to Hot-Tipster ***");
                Console.WriteLine("******************************");

                if (!File.Exists(tipster.FILE_PATH2))
                {
                    Console.WriteLine("Hot-Tipster is setting up for the first time......");
                    Thread.Sleep(2000);
                    tipster.PopulateBetList(blist, tipster.listOfBets);
                    Console.WriteLine("Reading historical data......");
                    Thread.Sleep(5000);
                    Console.WriteLine(tipster.PrintBetList(tipster.listOfBets));
                    Console.WriteLine("Writing bets to bin file...");
                    tipster.WriteBetsToBinFile(tipster.listOfBets);
                    Thread.Sleep(5000);
                    Console.WriteLine("\n\n***Bets.bin has been created!***\n\n");
                }

                tipster.listOfBets = tipster.ReadBetsFromBinFile();

                Console.WriteLine("\n****** Main Menu ******");
                Console.WriteLine("1 - Bets");
                Console.WriteLine("2 - Reports");
                Console.WriteLine("3 - Quit");
                int menuOption;
                int.TryParse(Console.ReadLine(), out menuOption);
                if (menuOption == 1)
                {
                    Console.WriteLine("\n****** Bet Menu ******");
                    Console.WriteLine("1 - Add a Bet");
                    Console.WriteLine("2 - View Bets");
                    Console.WriteLine("3 - Quit");
                    int betOption;
                    int.TryParse(Console.ReadLine(), out betOption);
                    switch (betOption)
                    {
                        case 1:
                            Console.WriteLine(Environment.NewLine + "*** Please enter the Bet Details below ***" + Environment.NewLine);

                            Console.Write("Name of the Race Course: ");
                            string raceCourse = Console.ReadLine();

                            Console.Write("Name of the Race Horse: ");
                            string horse = Console.ReadLine();

                            int yearCheck = 0;
                            do
                            {
                                Console.Write("The Year: ");
                                int.TryParse(Console.ReadLine(), out yearCheck);
                                if (yearCheck == 0 || yearCheck > DateTime.Today.Year)
                                {
                                    Console.WriteLine("\nPlease Enter a valid Year.\n");
                                }
                            } while (yearCheck == 0 || yearCheck > DateTime.Today.Year);

                            string year = yearCheck.ToString();

                            int monthCheck = 0;
                            do
                            {
                                Console.Write("The Month: ");
                                int.TryParse(Console.ReadLine(), out monthCheck);
                                if (monthCheck == 0 || monthCheck > 12)
                                {
                                    Console.WriteLine("\nPlease Enter a valid Month.\n");
                                }
                                else if (monthCheck > DateTime.Now.Month && yearCheck == DateTime.Now.Year)
                                {
                                    Console.WriteLine("\nYou cannot enter a bet from the future.\n"
                                        + "It must be on or before month " + DateTime.Now.Month + " of the year " + DateTime.Now.Year);
                                }
                            } while ((monthCheck == 0 || monthCheck > 12) || (monthCheck > DateTime.Now.Month && yearCheck == DateTime.Now.Year));

                            if (monthCheck <= 9)
                            {
                                monthCheck = 0 + monthCheck;
                            }

                            string month = monthCheck.ToString();

                            int dayCheck = 0;
                            do
                            {
                                Console.Write("The Day: ");
                                int.TryParse(Console.ReadLine(), out dayCheck);
                                if (dayCheck == 0 || dayCheck > 31)
                                {
                                    Console.WriteLine("\nPlease Enter a valid Day.\n");
                                }
                                else if (dayCheck > DateTime.Now.Day && monthCheck == DateTime.Now.Month)
                                {
                                    Console.WriteLine("\nYou cannot enter a bet from the future.\n"
                                        + "It must be on or before day " + DateTime.Now.Day + " of month " + DateTime.Now.Month);
                                }
                            } while ((dayCheck == 0 || dayCheck > 31) || (dayCheck > DateTime.Now.Day && monthCheck == DateTime.Now.Month));

                            if (dayCheck <= 9)
                            {
                                dayCheck = 0 + dayCheck;
                            }
                            string day = dayCheck.ToString();

                            decimal amount;
                            do
                            {
                                Console.Write("The Amount of the Bet: ");
                                decimal.TryParse(Console.ReadLine(), out amount);
                                if (amount == 0)
                                {
                                    Console.WriteLine("\nPlease Enter a valid Amount.\n");
                                }
                            } while (amount == 0);

                            string initVer = null;
                            do
                            {
                                Console.Write("The Verdict (please enter win or loss): ");
                                initVer = Console.ReadLine();
                                if (initVer != "win" && initVer != "loss")
                                {
                                    Console.WriteLine("\nPlease Enter a valid verdict.\nVerdict must be 'win' or 'loss'.\n");
                                }
                            } while (initVer != "win" && initVer != "loss");

                            bool verdict = false;
                            if (initVer == "win")
                            {
                                verdict = true;
                            }
                            else if (initVer == "loss")
                            {
                                verdict = false;
                            }

                            string betDate = "(" + year + ", " + month + ", " + day + ")";

                            Bet temp = new Bet(raceCourse, horse, betDate, amount, verdict);

                            if (tipster.VerifyBet(temp))
                            {
                                Console.WriteLine("\nSUCESSFUL MATCH\n");
                                tipster.listOfBets.Add(temp);
                                tipster.WriteBetsToBinFile(tipster.listOfBets);
                                Console.WriteLine($"Bet ({temp.ToString()}) has been added to the file.");
                            }
                            else
                            {
                                Console.WriteLine("\n*****The Above is NOT a valid Bet*****\n");
                                Console.WriteLine("\n You Must Enter a Bet in a Valid Format, e.g. Ayr, Jimmy, 2017, 05, 22, 11.50m, win/loss\n");
                            }
                            break;

                        case 2:
                            Console.WriteLine(tipster.PrintBetList(tipster.listOfBets));
                            break;
                        case 3:
                            Console.WriteLine("Would you like to go back to the Main Menu or Quit?\n1 - Main Menu\n2 - Quit");
                            int choice = 0;
                            int.TryParse(Console.ReadLine(), out choice);
                            if (choice == 1)
                            {
                                break;
                            }
                            else
                                quit = true;
                            break;
                        default:
                            Console.WriteLine("\nInvalid Choice.\n");
                            break;
                    }
                }
                else if (menuOption == 2)
                {
                    bool escape = false;
                    do
                    {
                        Console.WriteLine("\n****** Reports Menu ******");
                        Console.WriteLine("1 - View Yearly Stats");
                        Console.WriteLine("2 - View Most Popular Race Course");
                        Console.WriteLine("3 - View In Order of Date");
                        Console.WriteLine("4 - View Biggest Win + Biggest Loss");
                        Console.WriteLine("5 - View Total Races + Total Amount Won");
                        Console.WriteLine("6 - Quit");
                        int reportOption;
                        int.TryParse(Console.ReadLine(), out reportOption);
                        switch (reportOption)
                        {
                            case 1:
                                Console.WriteLine(tipster.ReportYearlyStats(tipster.listOfBets));
                                break;
                            case 2:
                                Console.WriteLine(tipster.ReportPopularRaceCourse(tipster.listOfBets));
                                break;
                            case 3:
                                Console.WriteLine(tipster.ReportInOrder(tipster.listOfBets));
                                break;
                            case 4:
                                Console.WriteLine(tipster.ReportBiggestWinAndLoss(tipster.listOfBets));
                                break;
                            case 5:
                                Console.WriteLine(tipster.ReportTotalRacesAndTotalWon(tipster.listOfBets));
                                break;
                            case 6:
                                Console.WriteLine("Would you like to go back to the Main Menu or Quit?\n1 - Main Menu\n2 - Quit");
                                int choice = 0;
                                int.TryParse(Console.ReadLine(), out choice);
                                if (choice == 1)
                                {
                                    escape = true;
                                }
                                else
                                {
                                    escape = true;
                                    quit = true;
                                }
                                break;
                            default:
                                Console.WriteLine("\nInvalid Choice.\n");
                                break;
                        }
                    } while (escape != true);
                }
                else if (menuOption == 3)
                    quit = true;
                else
                    Console.WriteLine("\nInvalid Choice.\n");

            } while (!quit);
        }
    }
}
