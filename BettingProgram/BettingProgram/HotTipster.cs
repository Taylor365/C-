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
        static string pattern = @"(\s+[a-zA-Z]+|[A-Za-z]+),\s+?[a-zA-Z\d]+,(\s+)?\((19|20)\d{2},(\s+)?(\d|([01]\d)),(\s+)?(\d|[0123]\d)\),(\s+)?\d+(\.)?(\d{2})?m,(\s+)?([Tt]rue|[Ff]alse)";

        public List<Bet> listOfBets = new List<Bet>();

        public bool VerifyBet(Bet bet)
        {
            Regex reEngine = new Regex(pattern);
            Match regExMatch = null;

            regExMatch = reEngine.Match(bet.ToString());
            if (regExMatch.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

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

                        betList.Add(bet);
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

        public string ReportInOrder(List<Bet> betList)
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

            var solutionSet = (from bet in betList
                               select bet).Count();
            resultString1 = "Total Races = " + solutionSet + Environment.NewLine;

            solutionSet = (from bet in betList
                           where bet.Verdict == true
                           select bet.Amount).Count();
            resultString2 = "Total Wins = " + solutionSet + Environment.NewLine;

            return resultString1 + Environment.NewLine + resultString2;
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
