namespace rock_paper_scissors.Models;
    class HelpTableGenerator
    {
        static int DetermineWinner(int numMoves, int userMove, int computerMove)
        {
            if (userMove == computerMove)
                return 0; // Draw

            int half = numMoves / 2;

            if (userMove <= half)
            {
                if (computerMove > userMove && computerMove <= userMove + half)
                    return -1; // Computer wins
                else
                    return 1; // User wins
            }
            else
            {
                if (computerMove < userMove - half || computerMove >= userMove)
                    return -1; // Computer wins
                else
                    return 1; // User wins
            }
        }

    public static void DisplayHelp(string[] moves)
    {
        Console.WriteLine("Help:\n");

        int numMoves = moves.Length;
        string[,] table = new string[numMoves + 1, numMoves + 1];

        for (int i = 0; i < numMoves; i++)
        {
            table[0, i + 1] = moves[i];
            table[i + 1, 0] = moves[i];
        }

        for (int i = 1; i <= numMoves; i++)
        {
            for (int j = 1; j <= numMoves; j++)
            {
                int result = DetermineWinner(numMoves, i, j);
                if (result == 1)
                    table[i, j] = "Win";
                else if (result == -1)
                    table[i, j] = "Lose";
                else
                    table[i, j] = "Draw";
            }
        }
        for (int i = 0; i <= numMoves; i++)
        {
            for (int j = 0; j <= numMoves; j++)
            {
                if (i == 0 && j == 0)
                    Console.Write("PC moves ");
                else if (i == 0)
                    Console.Write(table[i, j].PadRight(9));
                else if (j == 0)
                    Console.Write(table[i, j].PadRight(9));
                else
                    Console.Write(table[i, j].PadRight(9));
            }
            Console.WriteLine();
        }
    }
    }