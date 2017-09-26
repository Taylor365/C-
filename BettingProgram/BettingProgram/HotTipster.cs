using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BettingProgram
{
    public class HotTipster
    {
        static readonly string FILE_PATH = @"C:\Users\User\Documents\Visual Studio 2017\Projects\BettingProgram\Bets.txt";
        public readonly string FILE_PATH2 = @"C:\Users\User\Documents\Visual Studio 2017\Projects\BettingProgram\Bets.bin";
        //static string ver1 = @"[A-Za-z]+,[a-zA-Z]+,\(\d+,\d+,\d+\),\d+(\.)\d+m,(true|false)";
        //static string ver2 = @"[A-Za-z]+,\s[a-zA-Z]+,\s\(\d+,\s\d+,\s\d+\),\s\d+(\.)\d+m,\s(True|False)";
        //static string ver3 = @"(\s+[a-zA-Z]+|[A-Za-z]+),(\s+[a-zA-Z\d]+|[a-zA-Z\d]+),\s+\(\d{4},\s+\d{2},\s+\d{2}\),\s+\d+(\.)?(\d{2})?m,\s+([Tt]rue|[Ff]alse)";
        //static string ver4 = @"(\s+[a-zA-Z]+|[A-Za-z]+),\s+?[a-zA-Z\d]+,(\s+)?\(\d{4},(\s+)?(\d{2}),(\s+)?\d{2}\),(\s+)?\d+(\.)?(\d{2})?m,(\s+)?([Tt]rue|[Ff]alse)";
        //static string ver5 = @"(\s+[a-zA-Z]+|[A-Za-z]+),\s+?[a-zA-Z\d]+,(\s+)?\((19|20)\d{2},(\s+)?(\d|([01]\d)),(\s+)?(\d|[0123]\d)\),(\s+)?\d+(\.)?(\d{2})?m,(\s+)?([Tt]rue|[Ff]alse)";

        public string pattern = @"((\s+)?[a-zA-Z\d]+),\s+?[a-zA-Z\d]+,(\s+)?\((19|20)\d{2},(\s+)?(\d|([01]\d)),(\s+)?(\d|[0123]\d)\),(\s+)?\d+(\.)?(\d{2})?m,(\s+)?([Tt]rue|[Ff]alse)";

        public List<Bet> listOfBets = new List<Bet>();

        public void WriteBetsToBinFile(List<Bet> betList)
        {
            using (Stream fs = new FileStream(FILE_PATH2, FileMode.OpenOrCreate))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fs, betList);
            }
        }

        public List<Bet> ReadBetsFromBinFile()
        {
            List<Bet> bList;
            using (Stream fileStream = new FileStream(FILE_PATH2, FileMode.Open))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                bList = (List<Bet>)(binaryFormatter.Deserialize(fileStream));
            }
            return bList;
        }

        public void PopulateBetList(string[] list, List<Bet> betList)
        {
            using (FileStream fStream = File.OpenRead(FILE_PATH))
            using (TextReader txtReader = new StreamReader(fStream, Encoding.UTF8))
            {
                while (txtReader.Peek() > -1)
                {
                    string input = txtReader.ReadLine();
                    if (input != null)
                    {
                        Bet bet = new Bet();
                        list = input.Split(',');
                        bet.RaceCourse = list[0].Trim(' ');
                        bet.Horse = list[1].Trim(' ');
                        bet.Date = (list[2].Trim(' ') + ", " + list[3].Trim(' ') + ", " + list[4].Trim(' '));
                        bet.Amount = decimal.Parse(list[5].Trim(' ', 'm'));
                        bet.Verdict = bool.Parse(list[6].TrimStart(' '));
                        if (bet.VerifyBet(pattern))
                        {
                            betList.Add(bet);
                        }                       
                    }
                }
            }
        }

        public string PrintBetList(List<Bet> betList)
        {
            string result = null;
            foreach (Bet bet in betList)
            {
                result += bet.ToString() + Environment.NewLine;
            }

            return result;
        }

        public string ReportPopularRaceCourse(List<Bet> betList)
        {
            string resultString = null;

            var solutionSet = from bet in betList
                              group bet by bet.RaceCourse into result
                              orderby result.Count() descending
                              select result.First();

            foreach (var item in solutionSet.Take(1))
            {
                resultString += "Most Popular Racecourse = " + item.RaceCourse + Environment.NewLine;
            }

            return resultString;
        }

        public string ReportInOrderRecentFirst(List<Bet> betList)
        {
            string resultString = null;

            var solutionSet = from bet in betList
                              orderby bet.getDateTime() descending
                              select bet;
            foreach (var item in solutionSet)
            {
                resultString += item + Environment.NewLine;
            }

            return resultString;
        }
        public string ReportInOrderRecentLast(List<Bet> betList)
        {
            string resultString = null;

            var solutionSet = from bet in betList
                              orderby bet.getDateTime() ascending
                              select bet;
            foreach (var item in solutionSet)
            {
                resultString += item + Environment.NewLine;
            }

            return resultString;
        }


        public string ReportBiggestWinAndLoss(List<Bet> betList)
        {
            string resultString1 = null;
            string resultString2 = null;

            var solutionSet = from bet in betList
                              orderby bet.Amount descending
                              where bet.Verdict == true
                              select bet;
            foreach (var item in solutionSet.Take(1))
            {
                resultString1 += "Biggest Win = " + item + Environment.NewLine;
            }

            solutionSet = from bet in betList
                          orderby bet.Amount descending
                          where bet.Verdict == false
                          select bet;
            foreach (var item in solutionSet.Take(1))
            {
                resultString2 += "Biggest Loss = " + item + Environment.NewLine;
            }

            return resultString1 + Environment.NewLine + resultString2;
        }

        public string ReportTotalRacesAndTotalWon(List<Bet> betList)
        {
            string resultString1 = null;
            string resultString2 = null;
            int races = 0;
            int wins = 0;
            double success = 0;

            var solutionSet = (from bet in betList
                               select bet).Count();
            resultString1 = "Total Races = " + solutionSet + Environment.NewLine;
            races = solutionSet;

            solutionSet = (from bet in betList
                           where bet.Verdict == true
                           select bet.Amount).Count();
            resultString2 = "Total Wins = " + solutionSet + Environment.NewLine;
            wins = solutionSet;

            success = Math.Round(((double)wins / (double)races) * 100, 2);

            return resultString1 + Environment.NewLine + resultString2 + Environment.NewLine + "Success Rate: " + success + "%";
        }

        public string ReportYearlyStats(List<Bet> betList)
        {
            string resultString1 = null;
            string resultString2 = null;

            var solutionSet = from bet in betList
                              where bet.Verdict == true
                              group bet.Amount by bet.getDateTime().Year into result
                              select new { Year = result.Key, Sum = result.Sum() };
            resultString1 = "Year\tTotal Won";

            foreach (var item in solutionSet)
            {
                resultString1 += Environment.NewLine + item.Year + "\t" + item.Sum;
            }

            var solutionSet2 = from bet in betList
                               where bet.Verdict == false
                               group bet.Amount by bet.getDateTime().Year into result
                               select new { Year = result.Key, Sum = result.Sum() };

            resultString2 = "Year\tTotal Lost";

            foreach (var item in solutionSet2)
            {
                resultString2 += Environment.NewLine + item.Year + "\t" + item.Sum;
            }
            

            return resultString1 + Environment.NewLine + resultString2;
        }
    }
}
