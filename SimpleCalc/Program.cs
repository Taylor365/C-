using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            int select;
            double int1, int2, sum = 0;

            Console.WriteLine("Welcome to the SimpleCalc\n" +
                "Press 1 to add two numbers\n" +
                "Press 2 to subtract two numbers\n" +
                "Press 3 to multiple two numbers\n" +
                "Press 4 to divide two numbers");
            select = int.Parse(Console.ReadLine());


            if (select < 1 && select > 4){
                Console.WriteLine("Enter number 1");
                int1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter number 2");
                int2 = int.Parse(Console.ReadLine());

                switch (select)
                {
                    case 1:
                        sum = int1 + int2;
                        Console.WriteLine("{0} + {1} = {2}", int1, int2, sum);
                        break;
                    case 2:
                        sum = int1 - int2;
                        Console.WriteLine("{0} - {1} = {2}", int1, int2, sum);
                        break;
                    case 3:
                        sum = int1 * int2;
                        Console.WriteLine("{0} * {1} = {2}", int1, int2, sum);
                        break;
                    case 4:
                        sum = int1 / int2;
                        Console.WriteLine("{0} / {1} = {2}", int1, int2, sum);
                        break;
                }
            } else {
                Console.WriteLine("Invalid number entered!");
            }

            Console.ReadLine();
        }
    }
}
