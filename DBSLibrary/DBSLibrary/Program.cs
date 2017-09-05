using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            College college = new College();

            college.thingsThatCanBeBorrowed.Add(new Book("Educational", "Book 1", "O'Reilly Media", 2004, 694, 5, 0, 0));
            college.thingsThatCanBeBorrowed.Add(new Book("Educational", "Book 2", "O'Reilly Media", 2005, 694, 4, 0, 0));
            college.thingsThatCanBeBorrowed.Add(new Book("Educational", "Book 3", "O'Reilly Media", 2006, 694, 3, 0, 0));
            college.thingsThatCanBeBorrowed.Add(new Book("Educational", "Book 4", "O'Reilly Media", 2007, 694, 2, 0, 0));

            college.thingsThatCanBeBorrowed.Add(new Paper("Astrophysics", "Paper 1", "Edward P. Szuszczewicz", 1986, 362, 1, 0, 0));
            college.thingsThatCanBeBorrowed.Add(new Paper("Astrophysics", "Paper 2", "MNRAS", 2017, 11, 1, 0, 0));
            college.thingsThatCanBeBorrowed.Add(new Paper("Computer Science", "Paper 3", "John Johnson", 2017, 33, 2, 0, 0));

            college.thingsThatCanBeBorrowed.Add(new DVD("Educational", "DVD 1", "O'Reilly Media", 2004, 5, 0, 0));
            college.thingsThatCanBeBorrowed.Add(new DVD("Educational", "DVD 2", "O'Reilly Media", 2005, 4, 0, 0));
            college.thingsThatCanBeBorrowed.Add(new DVD("Educational", "DVD 3", "O'Reilly Media", 2006, 3, 0, 0));
            college.thingsThatCanBeBorrowed.Add(new DVD("Educational", "DVD 4", "O'Reilly Media", 2007, 2, 0, 0));



            int key = 100000;

            college.students.Add(key, new Student());
            key++;
            bool quit = false;
            int mainMenuChoice = 0;
            do
            {
                Console.WriteLine("\n\nLIBRARY MENU:");
                Console.WriteLine("____________________________________________");
                Console.WriteLine("1 - Add a member\n2 - List Members\n3 - The Library\n4 - Quit");
                Console.WriteLine("____________________________________________\n");
                int.TryParse(Console.ReadLine(), out mainMenuChoice);
                
                if (mainMenuChoice == 1)
                {
                    Console.WriteLine("\nADD MEMBER MENU\n____________________________________________");
                    Console.WriteLine("\nAdd a Member:\n1 - Student\n2 - Lecturer");
                    Console.WriteLine("____________________________________________\n");
                    int addMemberDecision = 0;
                    int.TryParse(Console.ReadLine(), out addMemberDecision);
                    if (addMemberDecision == 1 || addMemberDecision == 2)
                    {
                        Person temp = null;
                        Console.Write("Enter the Persons Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter their Address: ");
                        string address = Console.ReadLine();
                        Console.Write("Enter their Email-Address: ");
                        string emailaddress = Console.ReadLine();
                        Console.Write("Enter their PPSN: ");
                        string pps = Console.ReadLine();
                        Console.Write("Enter their Phone Number: ");
                        int phone = 0;
                        do
                        {
                            int.TryParse(Console.ReadLine(), out phone);
                            if (phone == 0)
                            {
                                Console.WriteLine("\nPlease Enter a valid Phone Number.\n");
                            }
                        } while (phone == 0);

                        switch (addMemberDecision)
                        {
                            case 1:
                                string grad = "";
                                do
                                {
                                    Console.Write("Are they a Post Graduate or Under Graduate? Enter P or U: ");
                                    grad = Console.ReadLine().ToLower();
                                    if (grad == "p")
                                    {
                                        grad = "Post Graduate";
                                    }
                                    else if (grad == "u")
                                    {
                                        grad = "Under Graduate";
                                    }

                                    if (grad != "Post Graduate" && grad != "Under Graduate")
                                    {
                                        Console.WriteLine("\nYou must enter P or U. Try Again.\n");
                                    }
                                } while (grad != "Post Graduate" && grad != "Under Graduate");

                                temp = new Student(pps, phone, name, address, emailaddress, grad, key, 0);
                                college.students.Add(key, temp);
                                Console.WriteLine("\nSTUDENT CREATED\n");
                                key++;
                                break;
                            case 2:
                                Console.Write("Enter their Salary: ");
                                int salary = 0;
                                do
                                {
                                    int.TryParse(Console.ReadLine(), out salary);
                                    if (salary <= 0)
                                    {
                                        Console.WriteLine("\nPlease Enter a valid Salary.\n");
                                    }
                                } while (salary <= 0);

                                temp = new Lecturer(pps, phone, name, address, emailaddress, key, 0, salary);
                                college.lecturers.Add(key, temp);
                                Console.WriteLine("\nLECTURER CREATED\n");
                                key++;
                                break;
                            default:
                                Console.WriteLine("\nInvalid choice.\n");
                                break;
                        }
                    }
                    else
                        Console.WriteLine("\nInvalid Choice.\n");
                }
                else if (mainMenuChoice == 2)
                {
                    Console.WriteLine("\nMEMBERS MENU\n____________________________________________");
                    Console.WriteLine("\nWhich members would you like to list?: \n1 - Students\n2 - Lecturers");
                    Console.WriteLine("____________________________________________\n");
                    int personListDecision = 0;
                    int.TryParse(Console.ReadLine(), out personListDecision);
                    int searchListDecision = 0;
                    int fieldSearchDecision = 0;
                    string searchName = "";
                    int searchID = 0;
                    if (personListDecision == 1 || personListDecision == 2)
                    {
                        Console.WriteLine("Would you like to search or list them all?: \n1 - Search\n2 - List");
                        int.TryParse(Console.ReadLine(), out searchListDecision);

                        if (searchListDecision == 1)
                        {
                            Console.WriteLine("Would you like to search by name or ID?: \n1 - Name\n2 - ID");
                            int.TryParse(Console.ReadLine(), out fieldSearchDecision);

                            if (fieldSearchDecision == 1)
                            {
                                Console.Write("Please enter the name of the person to search: ");
                                searchName = Console.ReadLine().ToLower();
                            }
                            else if(fieldSearchDecision == 2)
                            {
                                Console.Write("Please enter the ID of the person to search: ");
                                int.TryParse(Console.ReadLine(), out searchID);
                            }

                        }
                    }
                    switch (personListDecision)
                    {
                        case 1:
                            if (fieldSearchDecision == 1)
                                Console.WriteLine(college.search(searchListDecision, searchName, college.students));
                            else
                                Console.WriteLine(college.search(searchListDecision, college.students, searchID));
                            break;
                        case 2:
                            if (fieldSearchDecision == 1)
                                Console.WriteLine(college.search(searchListDecision, searchName, college.lecturers));
                            else
                                Console.WriteLine(college.search(searchListDecision, college.lecturers, searchID));
                            break;
                        default:
                            Console.WriteLine("\nInvalid choice.\n");
                            break;
                    }
                    Console.WriteLine("\n");
                }
                else if (mainMenuChoice == 3)
                {
                    int borrowerID = 0; // ID of borrower.
                    Console.WriteLine("\n\nBEFORE ENTERING THIS AREA, WE MUST VALIDATE YOUR ID:\n");
                    Console.WriteLine("What is your ID?");
                    //Showing an example of Exception Handling instead of Error Handling.
                    try
                    {
                        borrowerID = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("A FormatException was thrown due to: " + e.Message);
                    }
                    if (college.checkID(college.students, borrowerID) || college.checkID(college.lecturers, borrowerID))
                    {
                        Console.WriteLine("\nBORROWABLES MENU\n____________________________________________");
                        Console.WriteLine("\n1 - List Available Books\n2 - List Available Papers\n3 - List Available DVDs");
                        Console.WriteLine("____________________________________________\n");
                        int listItemDecision = 0;
                        int.TryParse(Console.ReadLine(), out listItemDecision);

                        string itemName = ""; // The name of the Item e.g. Book 1, Paper 2, DVD 4, etc.
                        string itemType = ""; // Book, DVD or Paper

                        switch (listItemDecision)
                        {
                            case 1:
                                itemType = "BOOK";

                                Console.WriteLine("\nList of Books Available:");
                                Console.WriteLine(college.listLibrary(itemType.ToLower(), college.thingsThatCanBeBorrowed));
                                Console.WriteLine("\nList of Books Currently Out:");
                                Console.WriteLine(college.listOutLibrary(itemType.ToLower(), college.currentlyOut));

                                Console.WriteLine("\n");
                                Console.WriteLine("Would you like to borrow a book from the Library?\n1 - Borrow\n2 - Return\n3 - Back to Main Menu");
                                int bookDecision = 0;
                                int.TryParse(Console.ReadLine(), out bookDecision);

                                if (bookDecision == 1)
                                {
                                    Console.Write("What book would you like to take out?: ");
                                    itemName = Console.ReadLine().ToLower();
                                    if (college.checkBorrowLimit(college.students, borrowerID))
                                    {
                                        Console.WriteLine(college.borrowItem(itemName, borrowerID, college.thingsThatCanBeBorrowed, college.currentlyOut));
                                    }
                                    else
                                        Console.WriteLine("\nYou have reached your Limit for borrowing.\n");
                                }
                                else if (bookDecision == 2)
                                {
                                    Console.Write("What book would you like to return?: ");
                                    itemName = Console.ReadLine().ToLower();
                                    college.returnItem(itemName, borrowerID, college.thingsThatCanBeBorrowed, college.currentlyOut);
                                    Console.WriteLine("\nBOOK RETURNED!\n");
                                }
                                else if (bookDecision == 3)
                                {
                                    break;
                                }
                                break;
                            case 2:
                                itemType = "PAPER";

                                Console.WriteLine("\nList of Papers Available:");
                                Console.WriteLine(college.listLibrary(itemType.ToLower(), college.thingsThatCanBeBorrowed));
                                Console.WriteLine("\nList of Papers Currently Out:");
                                Console.WriteLine(college.listOutLibrary(itemType.ToLower(), college.currentlyOut));

                                Console.WriteLine("\n");
                                Console.WriteLine("Would you like to borrow a paper from the Library?\n1 - Borrow\n2 - Return\n3 - Back to Main Menu");
                                int paperDecision = 0;
                                int.TryParse(Console.ReadLine(), out paperDecision);

                                if (paperDecision == 1)
                                {
                                    Console.Write("What paper would you like to take out?: ");
                                    itemName = Console.ReadLine().ToLower();
                                    if (college.checkBorrowLimit(college.students, borrowerID))
                                    {
                                        college.borrowItem(itemName, borrowerID, college.thingsThatCanBeBorrowed, college.currentlyOut);
                                    }
                                    else
                                        Console.WriteLine("\nYou have reached your Limit for borrowing.\n");
                                }
                                else if (paperDecision == 2)
                                {
                                    Console.Write("What paper would you like to return?: ");
                                    itemName = Console.ReadLine().ToLower();
                                    college.returnItem(itemName, borrowerID, college.thingsThatCanBeBorrowed, college.currentlyOut);
                                    Console.WriteLine("\nPAPER RETURNED!\n");
                                }
                                break;
                            case 3:
                                itemType = "DVD";
                                Console.WriteLine("\nList of DVDs Available:");
                                Console.WriteLine(college.listLibrary(itemType.ToLower(), college.thingsThatCanBeBorrowed));
                                Console.WriteLine("\nList of DVDs Currently Out:");
                                Console.WriteLine(college.listOutLibrary(itemType.ToLower(), college.currentlyOut));

                                Console.WriteLine("\n");
                                Console.WriteLine("Would you like to borrow a DVD from the Library?\n1 - Borrow\n2 - Return\n3 - Back to Main Menu");
                                int dvdDecision = 0;
                                int.TryParse(Console.ReadLine(), out dvdDecision);

                                if (dvdDecision == 1)
                                {
                                    Console.Write("What dvd would you like to take out?: ");
                                    itemName = Console.ReadLine().ToLower();
                                    if (college.checkBorrowLimit(college.students, borrowerID))
                                    {
                                        Console.WriteLine(college.borrowItem(itemName, borrowerID, college.thingsThatCanBeBorrowed, college.currentlyOut));
                                    }
                                    else
                                        Console.WriteLine("\nYou have reached your Limit for borrowing.\n");
                                }
                                else if (dvdDecision == 2)
                                {
                                    Console.Write("What dvd would you like to return?: ");
                                    itemName = Console.ReadLine().ToLower();

                                    college.returnItem(itemName, borrowerID, college.thingsThatCanBeBorrowed, college.currentlyOut);
                                    Console.WriteLine("\nDVD RETURNED!\n");
                                }
                                else if (dvdDecision == 3)
                                {
                                    break;
                                }
                                break;
                            default:
                                Console.WriteLine("\nInvalid choice.\n");
                                break;
                        }
                    }
                    else
                        Console.WriteLine("\nThis ID has NOT been recognised. \nPlease add this person to the system or retry again.\n");             
                }
                else if (mainMenuChoice == 4)
                    quit = true;
                else
                    Console.WriteLine("\nInvalid choice.\n");

            } while (!quit);

            Console.WriteLine("You made it to the end! :D");
            Console.ReadLine();

        }
    }
}
