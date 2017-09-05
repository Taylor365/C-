using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBSLibrary;
using System.Collections.Generic;

namespace Testing
{

    //Testing Class

    [TestClass]
    public class UnitTest1
    {
        // Testing that the borrowBook method takes a book from the Library List and adds it to the currentlyOut List.
        [TestMethod]
        public void TestBorrow() 
        {
            College c = new College();
            Person stu1 = new Student("125747G", 0863636, "Jim", "15 Some Street", "Jim@Jimson.ie", "Post Gradute", 100001, 0);
            List<IBorrowable> testCanBeBorrowed = new List<IBorrowable>();
            List<IBorrowable> outList = new List<IBorrowable>();
            testCanBeBorrowed.Add(new Book("Educational", "Book 1", "O'Reilly Media", 2004, 694, 5, 0, 0));
            
            string actual = c.borrowItem("book 1", stu1.getID(), testCanBeBorrowed, outList);
            string expected = "\nBOOK BORROWED!\n";
            Assert.AreEqual(expected, actual);
        }

        // Testing that the borrowBook method can't take a book that does not exist.
        [TestMethod]
        public void TestBorrowWrongItem()
        {
            College c = new College();
            Person stu1 = new Student("125747G", 0863636, "Jim", "15 Some Street", "Jim@Jimson.ie", "Post Gradute", 100001, 0);
            List<IBorrowable> testCanBeBorrowed = new List<IBorrowable>();
            List<IBorrowable> outList = new List<IBorrowable>();
            testCanBeBorrowed.Add(new Book("Educational", "Book 1", "O'Reilly Media", 2004, 694, 5, 0, 0));           
            string actual = c.borrowItem("book 4", stu1.getID(), testCanBeBorrowed, outList);
            string expected = "\nCould Not find Item!";
            Assert.AreEqual(expected, actual);
        }

        // Testing that we can return a borrowed Item.
        [TestMethod]
        public void TestReturn()
        {
            College c = new College();
            Person stu1 = new Student("125747G", 0863636, "Jim", "15 Some Street", "Jim@Jimson.ie", "Post Gradute", 100001, 0);
            List<IBorrowable> testCanBeBorrowed = new List<IBorrowable>();
            List<IBorrowable> outList = new List<IBorrowable>();
            testCanBeBorrowed.Add(new Book("Educational", "Book 1", "O'Reilly Media", 2004, 694, 5, 0, 0));
            c.borrowItem("book 1", stu1.getID(), testCanBeBorrowed, outList);
            c.returnItem("book 1", stu1.getID(), testCanBeBorrowed, outList);
            int actual = outList.Count;
            int expected = 0;
            Assert.AreEqual(expected, actual);
        }

        // Testing that we can't return a borrowed Item we never took.
        [TestMethod]
        public void TestReturnWrongItem()
        {
            College c = new College();
            Person stu1 = new Student("125747G", 0863636, "Jim", "15 Some Street", "Jim@Jimson.ie", "Post Gradute", 100001, 0);
            List<IBorrowable> testCanBeBorrowed = new List<IBorrowable>();
            List<IBorrowable> outList = new List<IBorrowable>();
            testCanBeBorrowed.Add(new Book("Educational", "Book 1", "O'Reilly Media", 2004, 694, 5, 0, 0));
            c.borrowItem("book 1", stu1.getID(), testCanBeBorrowed, outList);
            c.returnItem("book 2", stu1.getID(), testCanBeBorrowed, outList);
            int actual = outList.Count;
            int expected = 1;
            Assert.AreEqual(expected, actual);
        }

        // Testing that we can add a student to our Person List.
        [TestMethod]
        public void TestAddStudent() 
        {
            SortedList<int, Person> testStudents = new SortedList<int, Person>();
            Person stu1 = new Student("1234563U", 0863636, "Jim", "15 Some Street", "Jim@Jimson.ie", "Post Gradute", 100001, 0);
            testStudents.Add(100001, stu1);
            int actual = testStudents.Count;
            int expected = 1;
            Assert.AreEqual(expected, actual);
        }

        // Testing that we can't borrow past 5 items if we are an Under Graduate.
        [TestMethod]
        public void TestUnderGradLimit() 
        {
            College c = new College();
            SortedList<int, Person> testStudents = new SortedList<int, Person>();
            Person stu1 = new Student("1234563F", 0863636, "Jim", "15 Some Street", "Jim@Jimson.ie", "Under Gradute", 100001, 5); // This Student already has thier max 5 Items.
            testStudents.Add(100001, stu1);
            bool actual = c.checkBorrowLimit(testStudents, stu1.getID());
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        // Testing that we can borrow past 5 items if we are a Post Graduate.
        [TestMethod]
        public void TestPostGradLimit() 
        {
            College c = new College();
            SortedList<int, Person> testStudents = new SortedList<int, Person>();
            Person stu2 = new Student("1234563T", 0863636, "Jim", "15 Some Street", "Jim@Jimson.ie", "Post Graduate", 100002, 5); // This Student already has 5 Items borrowed.
            testStudents.Add(100002, stu2);
            bool actual = c.checkBorrowLimit(testStudents, stu2.getID());
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

    }
}
