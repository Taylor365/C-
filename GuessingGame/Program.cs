using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int guess;
            Random r = new Random();
            int secret = r.Next(1, 21);
            do
            {
                Console.Write("Guess the number: ");
                guess = int.Parse(Console.ReadLine());

                if (guess > secret)
                {
                    Console.WriteLine("Too high my friend. Try Again");
                }
                else if (guess < secret)
                {
                    Console.WriteLine("Too low my friend. Try Again");
                }

            } while (secret != guess);
            Console.WriteLine("Congrats! You guessed the secret number {0}.", secret);
            Console.ReadLine();
        }
    }
}
