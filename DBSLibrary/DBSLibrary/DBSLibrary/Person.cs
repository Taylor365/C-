using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSLibrary
{
    //Parent Class
    public abstract class Person
    {
        //Properties
        protected int phone;
        protected string ppsn, name, address, email;
        public int items { get; set; }

        //Constructor
        public Person(string p, string n, string add, string e, int ph, int it)
        {
            ppsn = p;
            name = n;
            address = add;
            email = e;
            phone = ph;
            items = it;
        }

        //Methods
        public virtual string getName()
        {
            return name;
        }

        public abstract int getID();
    }
}
