using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopDecorator.Coffee
{
    public class Decaf : Beverage
    {
        public Decaf()
        {
            //description = "Decaf";
        }

        public override double cost()
        {
            return .99;
        }

        public override string getDescription()
        {
            return "Decaf";
        }
    }
}
