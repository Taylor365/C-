using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int numC, size;
            int[] numbers;

            Console.Write("Enter the size of the array: ");
            size = int.Parse(Console.ReadLine());
            numbers = new int[size];
            Populate(numbers);
            numC = Count(numbers);

            Console.Write("Numbers in this array: ");
            Console.WriteLine("\n______________________________\n");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine("\n______________________________\n");
            Console.WriteLine("Count of even numbers: {0}", numC);

            Console.ReadLine();
        }

        public static void Populate(int[] numArray)
        {
            Random rand = new Random();
            for (int i = 0; i < numArray.Length; i++)
            {

                numArray[i] = rand.Next(1, 21);
            }
        }

        public static int Count(int[] numArray)
        {
            int evenCount = 0;

            for (int i = 0; i < numArray.Length; i++)
            {
                if (numArray[i] % 2 == 0)
                {
                    evenCount++;
                }
            }

            return evenCount;
        }
    
    }
}
