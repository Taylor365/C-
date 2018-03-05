using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopDecorator
{
    public abstract class Beverage
    {
        //public String description = "Unknown Beverage";

        /*public String getDescription()
        {
            return description;
        }*/

        public abstract string getDescription();
        public abstract double cost();
    }
}
