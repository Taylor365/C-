using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopDecorator.Condiments
{
    public class SteamedMilk : CondimentDecorator
    {
        Beverage beverage;

        public SteamedMilk(Beverage bev)
        {
            beverage = bev;
        }

        public override string getDescription()
        {
            return beverage.getDescription() + ", SteamedMilk";
        }

        public override double cost()
        {
            return beverage.cost() + .10;
        }
    }
}
