using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    class Program
    {
        static Random rand = new Random();
        static void Main(string[] args)
        {
            start:
            int point = 0, rollOne, rollTwo;
            rollOne = RollDice();
            Console.WriteLine("You rolled {0}", rollOne);
            if (rollOne == 7 || rollOne == 11)
            {
               Console.WriteLine("You win!");
            }
            else if (rollOne == 2 || rollOne == 3 || rollOne == 12)
            {
                Console.WriteLine("You lose!");
            }
            else
            {
                point = rollOne;
                Console.WriteLine("Point is {0}", point);
                do {
                    rollTwo = RollDice();
                    Console.WriteLine("You rolled {0}", rollTwo);
                    if (point == rollTwo)
                    {
                        Console.WriteLine("You win!");
                        break;
                    }
                    else if (rollTwo == 7)
                        Console.WriteLine("You lose");

                   } while (rollTwo != 7);

            }


            Console.ReadLine();
            goto start;
        }

        static int RollDice()
        {
            int d1 = rand.Next(1, 7);
            int d2 = rand.Next(1, 7);

            return d1 + d2;
        }
    }
}
