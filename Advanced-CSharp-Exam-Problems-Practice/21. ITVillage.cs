using System;
using System.Linq;

class ITVillage
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] { '|', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] position = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int[] diceNumbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        string[,] board = StoreBoard(input);

        int innsCount = CountInns(input);
        int innsBought = 0;
        int diceIndex = 0;
        int coins = 50;
        bool wonGame = false;

        int startRow = position[0] - 1;
        int startCol = position[1] - 1;
        string direction = GetDirection(startRow, startCol);
        int row = startRow;
        int col = startCol;

        //game loop
        while (true)
        {
            string field = string.Empty;
            int dice = diceNumbers[diceIndex];
            for (int pos = 1; pos <= dice; pos++)
            {
                if (direction == "down")
                {
                    row++;
                }
                else if (direction == "up")
                {
                    row--;
                }
                else if (direction == "right")
                {
                    col++;
                }
                else if (direction == "left")
                {
                    col--;
                }
                direction = GetDirection(row, col);
                field = board[row, col];
                if (pos == dice)
                {
                    if (field == "P")
                    {
                        coins -= 5;
                    }
                    else if (field == "I" && coins >= 100)
                    {
                        coins -= 100;
                        innsBought++;
                        if (innsBought == innsCount)
                        {
                            wonGame = true;
                        }
                    }
                    else if (field == "I" && coins < 100)
                    {
                        coins -= 10;
                    }
                    else if (field == "F")
                    {
                        coins += 20;
                    }
                    else if (field == "S")
                    {
                        diceIndex += 2;
                    }
                    else if (field == "V")
                    {
                        coins *= 10;
                    }
                    else if (field == "N")
                    {
                        wonGame = true;
                    }
                }
            }
            diceIndex++;
            if (wonGame == true || coins < 0 || diceIndex >= diceNumbers.Length)
            {
                break;
            }
            else if (innsBought > 0 && field != "S" && diceIndex + 1 < diceNumbers.Length)
            {
                coins += innsBought * 20;
            }
        }

        //end result
        if (innsBought == innsCount)
        {
            Console.WriteLine(string.Format("<p>You won! You own the village now! You have {0} coins!<p>", coins));
        }
        else if (wonGame)
        {
            Console.WriteLine("<p>You won! Nakov's force was with you!<p>");
        }
        else if (coins < 0)
        {
            Console.WriteLine("<p>You lost! You ran out of money!<p>");
        }
        else if (diceIndex >= diceNumbers.Length)
        {
            Console.WriteLine(string.Format("<p>You lost! No more moves! You have {0} coins!<p>", coins));
        }
    }
    public static string[,] StoreBoard(string[] input)
    {
        int index = 0;
        string[,] board = new string[4, 4];
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                board[row, col] = input[index];
                index++;
            }
        }
        return board;
    }
    public static int CountInns(string[] input)
    {
        int count = 0;
        foreach (var item in input)
        {
            if (item == "I")
            {
                count++;
            }
        }
        return count;
    }
    public static string GetDirection(int row, int col)
    {
        string direction = string.Empty;
        if (row == 0 && col < 3)
        {
            direction = "right";
        }
        else if (col == 3 && row < 3)
        {
            direction = "down";
        }
        else if (row == 3 && col > 0)
        {
            direction = "left";
        }
        else if (col == 0 && row > 0)
        {
            direction = "up";
        }
        return direction;
    }
}