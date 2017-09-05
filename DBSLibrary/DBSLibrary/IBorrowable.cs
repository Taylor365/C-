using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSLibrary
{
    //Interface for Borrowable Items
    public interface IBorrowable
    {
        int borrowerID { get; set; }
        int GetCopiesOut();
        string GetName();
        int GetCopiesIn();
        void SetCopiesIn(int n);
        void SetCopiesOut(int v);
    }
}
