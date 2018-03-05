using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopDecorator.Condiments
{
    public class Whip : CondimentDecorator
    {
        Beverage beverage;

        public Whip(Beverage bev)
        {
            beverage = bev;
        }

        public override string getDescription()
        {
            return beverage.getDescription() + ", Whip";
        }

        public override double cost()
        {
            return beverage.cost() + .10;
        }
    }
}
