using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSLibrary
{
    public class College
    {
        //Instantiating the lists.
        public SortedList<int, Person> students = new SortedList<int, Person>();
        public SortedList<int, Person> lecturers = new SortedList<int, Person>();
        public List<IBorrowable> thingsThatCanBeBorrowed = new List<IBorrowable>();
        public List<IBorrowable> currentlyOut = new List<IBorrowable>();

        // Searching the student/lecturer list using name or ID.
        public string search(int d, string s, SortedList<int, Person> list, int id) 
        {
            string found = "";
            if (d == 1)
            {
                foreach (KeyValuePair<int, Person> obj in list)
                {

                    if (s == obj.Value.getName().ToLower() || id == obj.Value.getID())
                    {
                        found += obj.ToString() + "\n**********************\n";
                    }               
                }
            }
            else if (d == 2)
            {
                foreach (KeyValuePair<int, Person> obj in list)
                {
                    found += obj.ToString() + "\n**********************\n";
                }
            }
            if (found == "")
            {
                return "\nNo Person with that Name/ID Exists.\n";
            }
            else
                return found;
        }

        // Overloading to take in name to search.
        public string search(int d, string s, SortedList<int, Person> list) 
        {
            return search(d, s, list, 0);
        }

        // Overloading to take in ID to search.
        public string search(int d, SortedList<int, Person> list, int id) 
        {
            return search(d, "", list, id);
        }

        // Checking the Users ID is valid.
        public bool checkID(SortedList<int, Person> list, int id)
        {
            foreach (KeyValuePair<int, Person> obj in list)
            {

                if (id == obj.Value.getID())
                {
                    return true;
                }
            }
            return false;
        }

        // Checking the Students borrow limit.
        // Taking in a student list and searching it using the borrowerID to check if they can borrow an Item.
        public bool checkBorrowLimit(SortedList<int, Person> list, int id) 
        {
            foreach (Person obj in list.Values)
            {
                Student s = obj as Student;
                if (s.getID() == id)
                {
                    if (s.status == "Post Graduate" &&  s.items < 10)
                    {
                        s.items++;
                        return true;
                    }
                    else if (s.status == "Under Graduate" && s.items < 5)
                    {
                        s.items++;
                        return true;
                    }
                }
            }
            return false;
        }

        /*BORROW METHOD
         * Below is the method to borrow for each different borrowable object in the Library.
         * 
         * The method takes in the parameters searched item name and the borrower ID, the list of current Library items and the list of current objects out.
         * The method searches for the item and compares the searched name to find the correct item.
         * Once the correct item is found, we take a copy of the item, store it in the Out List and decrease the item's fields copiesIn and Increase copiesOut.
         * */
        public string borrowItem(string iName, int bID, List<IBorrowable> listIn, List<IBorrowable> listOut)
        {
            if (listIn != null)
            {
                if (iName.Contains("book"))
                {
                    foreach (IBorrowable obj in listIn)
                    {
                        Book b = obj as Book;
                        if (b != null)
                        {
                            if (iName == b.GetName().ToLower())
                            {
                                if (b.GetCopiesIn() == 0)
                                {
                                    return "\nThere are no more copies of " + b.title + " available.\n";
                                }
                                else
                                {
                                    b.SetCopiesIn(b.GetCopiesIn() - 1);
                                    b.SetCopiesOut(b.GetCopiesOut() + 1);
                                    listOut.Add(new Book(b.genre, b.title, b.author, b.year, b.pages, b.copiesIn, b.copiesOut, bID));
                                    return "\nBOOK BORROWED!\n";
                                }
                            }
                        }
                    }
                }
                if (iName.Contains("paper"))
                {
                    foreach (IBorrowable obj in listIn)
                    {
                        Paper p = obj as Paper;
                        if (p != null)
                        {
                            if (iName == p.GetName().ToLower())
                            {
                                if (p.GetCopiesIn() == 0)
                                {
                                    return "\nThere are no more copies of " + p.title + " available.\n";
                                }
                                else
                                {
                                    p.SetCopiesIn(p.GetCopiesIn() - 1);
                                    p.SetCopiesOut(p.GetCopiesOut() + 1);
                                    listOut.Add(new Paper(p.field, p.title, p.author, p.year, p.pages, p.copiesIn, p.copiesOut, bID));
                                    return "\nPAPER BORROWED!\n";
                                }
                            }
                        }
                    }
                }
                if (iName.Contains("dvd"))
                {
                    foreach (IBorrowable obj in listIn)
                    {
                        DVD d = obj as DVD;
                        if (d != null)
                        {
                            if (iName == d.GetName().ToLower())
                            {
                                if (d.GetCopiesIn() == 0)
                                {
                                    return "\nThere are no more copies of " + d.title + " available.\n";
                                }
                                else
                                {
                                    d.SetCopiesIn(d.GetCopiesIn() - 1);
                                    d.SetCopiesOut(d.GetCopiesOut() + 1);
                                    listOut.Add(new DVD(d.genre, d.title, d.director, d.year, d.copiesIn, d.copiesOut, bID));
                                    return "\nDVD BORROWED!\n";
                                }
                            }
                        }
                    }
                }   
            }
            return "\nCould Not find Item!";
        }


        /*RETURN METHOD
         * Below is the method to return for each different borrowable object in the Library.
         * 
         * The method takes in the parameters searched item name and the borrower ID, the list of current Library items and the list of current objects out.
         * The method searches for the item in the list of OUT objects.
         * Once the correct item is found, we remove it from the OUT List and increase the item's fields copiesIn and Decrease copiesOut in the Library.
         * */
        public void returnItem(string iName, int bID, List<IBorrowable> listIn, List<IBorrowable> listOut)
        {
            if (listOut != null)
            {
                if (iName.Contains("book"))
                {
                    foreach (IBorrowable obj in listOut)
                    {
                        Book b = obj as Book;
                        if (b != null)
                        {
                            if (iName == b.GetName().ToLower() && bID == b.borrowerID)
                            {
                                listOut.Remove(b);
                            }
                            else
                                break;
                        }
                        if (listOut.Count() == 0)
                            break;
                    }
                    foreach (IBorrowable obj in listIn)
                    {
                        Book b = obj as Book;
                        if (b != null)
                        {
                            if (iName == b.GetName().ToLower())
                            {
                                b.SetCopiesIn(b.GetCopiesIn() + 1);
                                b.SetCopiesOut(b.GetCopiesOut() - 1);
                            }
                        }
                    }
                }
                if (iName.Contains("paper"))
                {
                    foreach (IBorrowable obj in listOut)
                    {
                        Paper p = obj as Paper;
                        if (p != null)
                        {
                            if (iName == p.GetName().ToLower() && bID == p.borrowerID)
                            {
                                listOut.Remove(p);
                            }
                            else
                                break;
                        }
                        if (listOut.Count() == 0)
                            break;
                    }
                    foreach (IBorrowable obj in listIn)
                    {
                        Paper p = obj as Paper;
                        if (p != null)
                        {
                            if (iName == p.GetName().ToLower())
                            {
                                p.SetCopiesIn(p.GetCopiesIn() + 1);
                                p.SetCopiesOut(p.GetCopiesOut() - 1);
                            }
                        }
                    }
                }
                if (iName.Contains("dvd"))
                {
                    foreach (IBorrowable obj in listOut)
                    {
                        DVD d = obj as DVD;
                        if (d != null)
                        {
                            if (iName == d.GetName().ToLower() && bID == d.borrowerID)
                            {
                                listOut.Remove(d);
                            }
                            else
                                break;
                        }
                        if (listOut.Count() == 0)
                            break;
                    }
                    foreach (IBorrowable obj in listIn)
                    {
                        DVD d = obj as DVD;
                        if (d != null)
                        {
                            if (iName == d.GetName().ToLower())
                            {
                                d.SetCopiesIn(d.GetCopiesIn() + 1);
                                d.SetCopiesOut(d.GetCopiesOut() - 1);
                            }
                        }
                    }
                }
            }
        }

        // This method Lists the current Library depending on type selected.
        public string listLibrary(string type, List<IBorrowable> lib)
        {
            string list = "";
            if (type == "book")
            {
                foreach (IBorrowable obj in lib)
                {
                    Book b = obj as Book;
                    if (b != null)
                    {
                        list += b.ToString() + "\n***********************\n";
                    }
                }
                return list;
            }
            else if (type == "paper")
            {               
                foreach (IBorrowable obj in lib)
                {
                    Paper p = obj as Paper;
                    if (p != null)
                    {
                        list += p.ToString() + "\n***********************\n";
                    }
                }
                return list;
            }
            else if (type == "dvd")
            {
                foreach (IBorrowable obj in lib)
                {
                    DVD d = obj as DVD;
                    if (d != null)
                    {
                        list += d.ToString() + "\n***********************\n";
                    }
                }
                return list;
            }
            else
                return "Could not find list";
        }

        // This method Lists the current OUT List depending on type selected.
        public string listOutLibrary(string type, List<IBorrowable> lib)
        {
            string list = "";
            if (type == "book")
            {
                foreach (IBorrowable obj in lib)
                {
                    Book b = obj as Book;
                    if (b != null)
                    {
                        list += "\nTitle: " + b.title + "\nBorrower ID: " + b.borrowerID + "\n*****************\n";
                    }
                }
                return list;
            }
            else if (type == "paper")
            {               
                foreach (IBorrowable obj in lib)
                {
                    Paper p = obj as Paper;
                    if (p != null)
                    {
                        list += "\nTitle: " + p.title + "\nBorrower ID: " + p.borrowerID + "\n*****************\n";
                    }
                }
                return list;
            }
            else if (type == "dvd")
            {
                foreach (IBorrowable obj in lib)
                {
                    DVD d = obj as DVD;
                    if (d != null)
                    {
                        list += "\nTitle: " + d.title + "\nBorrower ID: " + d.borrowerID + "\n*****************\n";
                    }
                }
                return list;
            }
            else
                return "No List Available!";
        }
    }
}
