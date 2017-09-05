using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSLibrary
{
    //Child class extends Parent
    public class Student : Person
    {
        //Properties
        public string status { get; }
        private int studentID;

        //Constructor
        public Student():this("", 0, "Jim", "", "","Under Graduate", 0, 4)
        {

        }
        public Student(string p, int ph, string n, string add, string e, string stat, int stuID, int it):base(p, n, add, e, ph, it)
        {
            this.status = stat;
            this.studentID = stuID;           
        }

        //Overriding ToString() Method
        public override string ToString()
        {
            return "\nStudent ID: " + this.studentID + "\nName: " + this.name + "\nPhone Number: " + this.phone + "\nAddress: " + this.address + "\nEmail: " + this.email + "\nStatus: " + this.status + "\nItems Borrowed: " + this.items;
        }

        //Overriding Method
        public override int getID()
        {
            return studentID; ;
        }

    }
}
