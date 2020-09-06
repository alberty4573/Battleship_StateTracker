using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship_StateTracker
{
    class Program
    {

        private static bool[,] newBoard = new bool[10, 10]; // new board
        private static List<BattleShips> BattleShips = new List<BattleShips>();
        private static BattleShips customisedBattleship = new BattleShips();
        private static string selectedShipName = "";
        private static BattleShips selectedBattleship;
        


        // Main Function
        static void Main(string[] args)
        {
            // Add battleship and print names
            initBattleships();

            // Select Battleship with validations
            selectBattleship();

            // Put a battleship on board
            placeBattleshiponBoard();

            // hit/miss/sink
            attackBattleship();

        }


        // Initiate Battle Ships
        private static void initBattleships()
        {
            Console.WriteLine("Board Created!");


            BattleShips.Add(new BattleShips
            {
                name = "battleship 1",
                startX = 0,
                startY = 0,
                length = 11,
                direction = "h" // horizontal
            });

            BattleShips.Add(new BattleShips
            {
                name = "battleship 2",
                startX = 0,
                startY = 0,
                length = 2,
                direction = "v" // vertical
            });

            BattleShips.Add(new BattleShips
            {
                name = "battleship 3",
                startX = 0,
                startY = 0,
                length = 1,
                direction = "v" // vertical
            });

            Console.WriteLine("3 Battleships Added!");

            for (; ; )
            {
                Console.WriteLine("Would you like to add more? Y/N");
                string input = Console.ReadLine();
                if (input == "Y")
                    {
                    Console.WriteLine("Please input your ship name");
                    customisedBattleship.name = Console.ReadLine();
                    Console.WriteLine("Please input your ship start X position");
                    customisedBattleship.startX = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please input your ship start Y position");
                    customisedBattleship.startY = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please input your ship's length");
                    customisedBattleship.length = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please input your ship's direction from the start point(v/h)");
                    customisedBattleship.direction = Console.ReadLine();

                    BattleShips.Add(customisedBattleship);
                } else {
                        break;
                    }

            }

            
        }

        private static void selectBattleship()
        {
            List<string> names = BattleShips.Select(o => o.name).ToList();
            Console.WriteLine("Please select a ship to put on the board: ");
            Console.WriteLine(String.Join("\n", names));

            for (; ; )
            {
                selectedShipName = Console.ReadLine();
                selectedBattleship = BattleShips.Find(x => x.name.Contains(selectedShipName));
                if (selectedBattleship != null && selectedBattleship.direction == "v" && (selectedBattleship.startY + selectedBattleship.length) <= 9)
                {

                    Console.WriteLine("You've selected " + selectedShipName);
                    break;
                }
                else if (selectedBattleship != null && selectedBattleship.direction == "h" && (selectedBattleship.startX + selectedBattleship.length) <= 9)
                {
                    Console.WriteLine("You've selected " + selectedShipName);
                    break;
                }
                else
                {
                    Console.WriteLine("Your input is not valid(wrong ship name or battleship parcially outside the board), please select again");
                }

            }
        }

        private static void placeBattleshiponBoard()
        {
            if (selectedBattleship.direction == "v")
            {
                for (var n = 0; n < selectedBattleship.length; n++)
                {
                    newBoard[selectedBattleship.startX, selectedBattleship.startY + n] = true;
                }
                Console.WriteLine("Battleship put on the board!");


            }
            else if (selectedBattleship.direction == "h")
            {
                for (var n = 0; n < selectedBattleship.length; n++)
                {
                    newBoard[selectedBattleship.startX + n, selectedBattleship.startY] = true;
                }
                Console.WriteLine("Battleship put on the board!");
            }
        }

        private static void attackBattleship()
        {
            Console.WriteLine("Now Attack!");

            for (; ; )
            {
                Console.Write("Please put a valid X coordinate: ");
                int inputX = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please put a valid Y coordinate: ");
                int inputY = Convert.ToInt32(Console.ReadLine());

                if (newBoard[inputX, inputY])
                {
                    Console.WriteLine("You hit the target:" + "[" + inputX + "," + inputY + "]");
                    newBoard[inputX, inputY] = false;
                }
                else
                {
                    Console.WriteLine("You miss the target...");
                }

                if (newBoard.Cast<bool>().Contains(true))
                {
                    Console.WriteLine("The ship hasn't been sunk! Please try again!");
                }
                else
                {
                    Console.Write("You Win! Ship Sunk!");
                    break;
                }

            }
        }
    }
}
