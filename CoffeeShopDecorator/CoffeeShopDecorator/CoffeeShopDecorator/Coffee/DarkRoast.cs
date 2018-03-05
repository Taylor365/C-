using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopDecorator.Coffee
{
    public class DarkRoast : Beverage
    {
        public DarkRoast()
        {
            //description = "Darkest of Roast";
        }

        public override double cost()
        {
            return .99;
        }

        public override string getDescription()
        {
            return "Darkest of Roast";
        }
    }
}
