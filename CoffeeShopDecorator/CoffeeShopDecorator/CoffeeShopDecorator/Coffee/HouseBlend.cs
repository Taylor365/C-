using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopDecorator
{
    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            //description = "House Blend Coffee";
        }

        public override double cost()
        {
            return .89;
        }

        public override string getDescription()
        {
            return "House Blend Coffee";
        }
    }
}
