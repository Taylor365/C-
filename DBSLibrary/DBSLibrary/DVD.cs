using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSLibrary
{
    //Class implements Interface
    public class DVD : IBorrowable
    {
        //Properties
        public string title, director, genre;
        public int copiesIn, copiesOut, year;

        public int borrowerID { get; set; }

        //Constructor
        public DVD(string f, string t, string dir, int y, int ci, int co, int bID)
        {
            genre = f;
            title = t;
            director = dir;
            year = y;
            copiesIn = ci;
            copiesOut = co;
            borrowerID = bID;

        }

        //Overriding ToString() Method
        public override string ToString()
        {
            return "\nGenre: " + this.genre + "\nTitle: " + this.title + "\nDirector: " + this.director + "\nYear: " + this.year + "\nCopies In: " + this.copiesIn + "\nCopies Out: " + this.copiesOut;
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
