using System;
using rock_paper_scissors.Models;
class Program
{
    static void Main(string[] args)
    {
        void PrintExample()
        {
            Console.WriteLine("Example: dotnet run rock paper scissors lizard Spock");
        }
        Console.Clear();
        if (args.Length < 3 || args.Length % 2 == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid number of arguments. Please provide an odd number >= 3 of strings.");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            PrintExample();
            Console.ResetColor(); 
            return;
        }
        else if (args.Distinct().Count() != args.Length)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid moves. Please provide non-repeating strings.");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            PrintExample();
            Console.ResetColor();
            return;
        }
        else if(args.Count() == 0)
        {
            Console.WriteLine("No moves. Please enter moves");
            PrintExample();
        }
        Game game = new Game(args);
        game.Play();
    }
}
