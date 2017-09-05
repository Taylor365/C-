using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSLibrary
{
    //Child class extends Parent
    public class Lecturer : Person
    {
        //Properties
        protected int staffId;
        protected decimal salary;

        //Constructors
        public Lecturer():this("", 0, "", "", "", 0, 0, 0)
        {

        }
        public Lecturer(string p, int ph, string n, string add, string e, int sId, int it, decimal sal) : base(p, n, add, e, ph, it)
        {
            this.staffId = sId;
            this.salary = sal;
        }

        //Overriding ToString() Method
        public override string ToString()
        {
            return "\nName: " + this.name + "\nItems Borrowed: " + this.items;
        }

        //Overriding Method
        public override int getID()
        {
            return staffId;
        }
    }
}
