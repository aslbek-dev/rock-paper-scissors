using System;
using System.Linq;

namespace rock_paper_scissors.Models
{
    public class Game
    {
        private string[] moves;
        private Random random;
        public Game(string[] moves)
        {
            this.moves = moves;
            this.random = new Random();
        }
        private void PrintMovesMenu()
        {
            Console.WriteLine("Available moves:");
            for (int i = 0; i < moves.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {moves[i]}");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0 - exit");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("? - help");
            Console.ResetColor();
        }
        public void Play()
        {
            byte[] key = KeyGenerator.GenerateKey();
            string hmac = HmacCalculator.CalculateHMAC(string.Join(" ", moves), key);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("HMAC: " + hmac);
            Console.ResetColor();
            PrintMovesMenu();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter your move: ");
                Console.ResetColor();
                string userInput = Console.ReadLine().Trim();

                if (userInput == "0")
                {
                    Console.WriteLine("Exiting the game...");
                    return;
                }
                else if (userInput == "?")
                {
                    Console.Clear();
                    HelpTableGenerator.DisplayHelp(moves);
                    Console.WriteLine();
                    PrintMovesMenu();
                    continue;
                }
                if (!int.TryParse(userInput, out int moveIndex) || moveIndex < 1 || moveIndex > moves.Length)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid move. Please enter a valid move number.");
                    Console.ResetColor();
                    continue;
                }
                string userMove = moves[moveIndex - 1];
                string computerMove = moves[random.Next(moves.Length)];

                Console.WriteLine("Your move: " + userMove);
                Console.WriteLine("Computer move: " + computerMove);

                int diff = (moveIndex - 1 - Array.IndexOf(moves, computerMove) + moves.Length) % moves.Length;
                if (diff == 0)
                Console.WriteLine("It's a draw!");
                else if (diff <= moves.Length / 2)
                    Console.WriteLine("You win!");
                else
                    Console.WriteLine("You lose!");
                
                Console.WriteLine("HMAC key: " + BitConverter.ToString(key).Replace("-", ""));
                Console.WriteLine();
                return;
            }
        }        
    }
}