using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GuessNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Random x = new Random();
            int winningNumber = x.Next(0, 100);
            bool win = false;

            do
            {
                Console.WriteLine("Guess a number between 0  and 100");
                string guess = Console.ReadLine();
                int number = int.Parse(guess);

                if (number > winningNumber)
                {
                    Console.WriteLine("TOO HIGH! Try lower...");
                }
                else if (number < winningNumber) 
                {
                    Console.WriteLine("too low! Try HIGHER...");
                }
                else if (number == winningNumber)
                {
                    Console.WriteLine("You win!");
                    win = true;
                }
                Console.WriteLine();

            } while (win == false);

            Console.WriteLine("Thank u for playing with me!");
            Console.WriteLine("Press any key to end.");
            Console.ReadKey(true);
        }
    }
}
