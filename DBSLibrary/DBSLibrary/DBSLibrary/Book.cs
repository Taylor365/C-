using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSLibrary
{
    //Class implements Interface
    public class Book : IBorrowable
    {
        //Properties
        public string title { get;}
        public string author { get;}
        public string genre { get;}
        public int pages { get;}
        public int copiesIn { get; private set; }
        public int copiesOut { get; private set; }
        public int year { get; }
        public int borrowerID { get; set; }

        //Constructor
        public Book() : this("", "", "", 0, 0, 0, 0, 0)
        {

        }
        public Book(string g, string t, string a, int y, int p, int ci, int co, int bor)
        {
            genre = g;
            title = t;
            author = a;
            year = y;
            pages = p;
            copiesIn = ci;
            copiesOut = co;
            borrowerID = bor;

        }

        //Overriding ToString() Method
        public override string ToString()
        {
            return "\nGenre: " + this.genre + "\nTitle: " + this.title + "\nAuthor: " + this.author + "\nYear: " + this.year + "\nCopies In Stock: " + this.copiesIn + "\nCopies Out: " + this.copiesOut;
        }

        public string GetName()
        {
            return title;
        }

        public  int GetCopiesIn()
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
