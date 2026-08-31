using System;

namespace DiceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int playerRandomNum;
            int enemyRandomNum;
            int playerPoints = 0;
            int enemyPoints = 0;
            Random random = new Random(); //generates random numbers

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Press Any Key To Roll The Dice");
                playerRandomNum = random.Next(1, 7);
                Console.ReadKey();
                Console.WriteLine("You Rolled A " + playerRandomNum);

                System.Threading.Thread.Sleep(1000); //1 second delay to make the game more realistic

                enemyRandomNum = random.Next(1, 7);
                Console.WriteLine("Enemy AI Rolled A " + enemyRandomNum);

                if (playerRandomNum > enemyRandomNum)
                {
                    playerPoints++;
                    Console.WriteLine("Player Wins This Round");
                }
                else if (playerRandomNum < enemyRandomNum)
                {
                    enemyPoints++;
                    Console.WriteLine("Enemy Wins This Round");
                }
                else
                {
                    Console.WriteLine("It's A Draw");
                }

                Console.WriteLine(
                    "The Current Score Is Player: " + playerPoints + " Enemy: " + enemyPoints
                );
                Console.WriteLine();
            }

            if (playerPoints > enemyPoints)
            {
                Console.WriteLine(
                    "Player Wins The Game by " + (playerPoints - enemyPoints) + " Points"
                );
            }
            else if (playerPoints < enemyPoints)
            {
                Console.WriteLine(
                    "Enemy Wins The Game by " + (enemyPoints - playerPoints) + " Points"
                );
            }
            else
            {
                Console.WriteLine("It's A Draw, both players have " + playerPoints + " Points");
            }

            Console.ReadKey();
        }
    }
}
