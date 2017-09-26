using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BettingProgram;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace TipsterUnitTesting
{
    [TestClass]
    public class TipsterTests
    {
        [TestMethod]
        public void BetGetDateTime()
        {
            DateTime actual = new DateTime(2017, 05, 12);

            Bet temp = new Bet(" Aintree", "Jimmy", "(2017, 05, 12)", 11.58m, true);
            DateTime expected = temp.getDateTime();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VerifyRaceCourse()
        {
            bool actual = false;
            bool expected = true;
            string pattern = @"[A-Za-z]+";

            string course = "Aintree";

            Regex reEngine = new Regex(pattern);
            Match regExMatch = null;

            regExMatch = reEngine.Match(course);
            if (regExMatch.Success)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VerifyRaceCourseWithSpaces()
        {
            bool actual = false;
            bool expected = true;
            string pattern = @"\s+[a-zA-Z]+";

            string course = "  Aintree";

            Regex reEngine = new Regex(pattern);
            Match regExMatch = null;

            regExMatch = reEngine.Match(course);
            if (regExMatch.Success)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VerifyNewBetAgainstBetFormatV2()
        {
            bool actual = false;
            bool expected = true;
            string pattern = @"[A-Za-z]+,\s[a-zA-Z]+,\s\(\d+,\s\d+,\s\d+\),\s\d+(\.)\d+m,\s(True|False)";

            Bet temp = new Bet(" Aintree", "Jimmy", "(2017, 05, 12)", 11.58m, true);

            Regex reEngine = new Regex(pattern);
            Match regExMatch = null;

            regExMatch = reEngine.Match(temp.ToString());
            if (regExMatch.Success)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VerifyNewBetAgainstBetFormatV3()
        {
            bool actual = false;
            bool expected = true;
            string pattern = @"(\s+[a-zA-Z]+|[A-Za-z]+),(\s+[a-zA-Z\d]+|[a-zA-Z\d]+),\s+\(\d{4},\s+\d{2},\s+\d{2}\),\s+\d+(\.)?(\d{2})?m,\s+([Tt]rue|[Ff]alse)";

            Bet temp = new Bet(" Aintree", "  Jimmy", "  (2017, 05, 12)", 11.58m, true);

            Regex reEngine = new Regex(pattern);
            Match regExMatch = null;

            regExMatch = reEngine.Match(temp.ToString());
            if (regExMatch.Success)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VerifyNewBetMethod()
        {
            HotTipster tipster = new HotTipster();
            string pattern = @"(\s+[a-zA-Z]+|[A-Za-z]+),(\s+[a-zA-Z\d]+|[a-zA-Z\d]+),\s+\(\d{4},\s+\d{2},\s+\d{2}\),\s+\d+(\.)?(\d{2})?m,\s+([Tt]rue|[Ff]alse)";

            bool actual = false;
            bool expected = true;

            Bet temp = new Bet(" Aintree", "Jimmy", "(2017, 05, 12)", 11.58m, true);

            actual = temp.VerifyBet(pattern);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MostPopularRaceCourse()
        {
            List<Bet> betList = new List<Bet>();
            Bet temp1 = new Bet(" Aintree", "Jimmy", "(2017, 05, 12)", 11.58m, true);
            Bet temp2 = new Bet("Punchestown", "Frank", "(2016, 12, 22)", 122.52m, true);
            Bet temp3 = new Bet("Punchestown", "Jimmy10", "(2017, 07, 05)", 35.00m, false);
            Bet temp4 = new Bet("Goodwood", "Sheergar2",  "(2016, 10, 05)", 34.12m, true);
            betList.Add(temp1);
            betList.Add(temp2);
            betList.Add(temp3);
            betList.Add(temp4);

            string actual = "Punchestown";
            string expected = null;

            var solutionSet = from bet in betList
                              group bet by bet.RaceCourse into result
                              orderby result.Count() descending
                              select result.First();

            foreach (var item in solutionSet.Take(1))
            {
                expected = item.RaceCourse;
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InOrderDescending()
        {
            List<Bet> betList = new List<Bet>();
            Bet temp1 = new Bet(" Aintree", "Jimmy", "(2017, 05, 12)", 11.58m, true);
            Bet temp2 = new Bet("Punchestown", "Frank", "(2016, 12, 22)", 122.52m, true);
            Bet temp3 = new Bet("Punchestown", "Jimmy10", "(2017, 07, 05)", 35.00m, false);
            Bet temp4 = new Bet("Goodwood", "Sheergar2", "(2016, 10, 05)", 34.12m, true);
            betList.Add(temp1);
            betList.Add(temp2);
            betList.Add(temp3);
            betList.Add(temp4);

            string actual = temp3 + Environment.NewLine + temp1 + Environment.NewLine + temp2 + Environment.NewLine
                 + temp4 + Environment.NewLine;

            string expected = null;

            var solutionSet = from bet in betList
                              orderby bet.getDateTime() descending
                              select bet;
            foreach (var item in solutionSet)
            {
                expected += item + Environment.NewLine;
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BiggestWinAndLoss()
        {
            List<Bet> betList = new List<Bet>();
            Bet temp1 = new Bet(" Aintree", "Jimmy", "(2017, 05, 12)", 11.58m, false);
            Bet temp2 = new Bet("Punchestown", "Frank", "(2016, 12, 22)", 122.52m, true);
            Bet temp3 = new Bet("Punchestown", "Jimmy10", "(2017, 07, 05)", 35.00m, false);
            Bet temp4 = new Bet("Goodwood", "Sheergar2", "(2016, 10, 05)", 34.12m, true);
            betList.Add(temp1);
            betList.Add(temp2);
            betList.Add(temp3);
            betList.Add(temp4);

            string actual = "Biggest Win = " + temp2 + Environment.NewLine + Environment.NewLine 
                + "Biggest Loss = " + temp3 + Environment.NewLine;

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

            string expected = resultString1 + Environment.NewLine + resultString2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TotalRacesAndTotalWins()
        {
            List<Bet> betList = new List<Bet>();
            Bet temp1 = new Bet(" Aintree", "Jimmy", "(2017, 05, 12)", 11.58m, false);
            Bet temp2 = new Bet("Punchestown", "Frank", "(2016, 12, 22)", 122.52m, true);
            Bet temp3 = new Bet("Punchestown", "Jimmy10", "(2017, 07, 05)", 35.00m, false);
            Bet temp4 = new Bet("Goodwood", "Sheergar2", "(2016, 10, 05)", 34.12m, true);
            betList.Add(temp1);
            betList.Add(temp2);
            betList.Add(temp3);
            betList.Add(temp4);

            string actual = "Total Races = " + 4 + Environment.NewLine + Environment.NewLine + "Total Wins = " + 2 + Environment.NewLine;

            string resultString1 = null;
            string resultString2 = null;

            var solutionSet = (from bet in betList
                               select bet).Count();
            resultString1 = "Total Races = " + solutionSet + Environment.NewLine;

            solutionSet = (from bet in betList
                           where bet.Verdict == true
                           select bet.Amount).Count();
            resultString2 = "Total Wins = " + solutionSet + Environment.NewLine;

            string expected = resultString1 + Environment.NewLine + resultString2;

            Assert.AreEqual(expected, actual);
        }
    }
}
