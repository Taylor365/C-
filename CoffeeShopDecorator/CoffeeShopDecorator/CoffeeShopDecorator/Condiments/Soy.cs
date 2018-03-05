using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopDecorator.Condiments
{
    public class Soy : CondimentDecorator
    {
        Beverage beverage;

        public Soy(Beverage bev)
        {
            beverage = bev;
        }

        public override string getDescription()
        {
            return beverage.getDescription() + ", Soy";
        }

        public override double cost()
        {
            return beverage.cost() + .15;
        }
    }
}
