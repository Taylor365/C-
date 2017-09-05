using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSLibrary
{
    //Class implements Interface
    public class Paper : IBorrowable
    {
        //Properties
        public string title { get; }
        public string author { get; }
        public string field { get; }

        public int pages, year;
        public int copiesIn { get; private set;}
        public int copiesOut { get; private set; }

        public int borrowerID { get; set; }

        //Constructor
        public Paper(string f, string t, string a, int y, int p, int ci, int co, int bId)
        {
            field = f;
            title = t;
            author = a;
            year = y;
            pages = p;
            copiesIn = ci;
            copiesOut = co;
            borrowerID = bId;

        }


        //Overriding ToString() Method
        public override string ToString()
        {
            return "\nField: " + this.field + "\nTitle: " + this.title + "\nAuthor: " + this.author + "\nYear: " + this.year + "\nCopies In: " + this.copiesIn + "\nCopies Out: " + this.copiesOut;
        }

        public string GetName()
        {
            return title;
        }

        public int GetCopiesIn()
        {
            return copiesIn;
        }
        public void SetCopiesIn(int n)
        {
            copiesIn = n;
        }

        public void SetCopiesOut(int v)
        {
            copiesOut = v;
        }

        public int GetCopiesOut()
        {
            return copiesOut;
        }
    }
}
