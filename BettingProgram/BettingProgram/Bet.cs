using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingProgram
{
    [Serializable]
    public class Bet
    {
        public string RaceCourse { get; set; }
        public string Horse { get; set; }
        public string Date { get; set; }
        public decimal Amount { get; set; }
        public bool Verdict { get; set; }

        public Bet(string rc, string h, string d, decimal a, bool v)
        {
            RaceCourse = rc;
            Horse = h;
            Date = d;
            Amount = a;
            Verdict = v;
        }

        public Bet()
        {

        }

        public override string ToString()
        {
            return RaceCourse + ", " + Horse + ", " + Date + ", " + Amount + "m, " + Verdict;
        }

        public DateTime getDateTime()
        {
            string[] dateSplit = Date.TrimStart('(').TrimEnd(')').Split(',');

            return new DateTime(int.Parse(dateSplit[0]), int.Parse(dateSplit[1]), int.Parse(dateSplit[2]));

        }
    }
}
