using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_v3.Enums;
using Tic_Tac_Toe_v3.Interfaces;

namespace Tic_Tac_Toe_v3.Game
{
    public class GameUtils
    {
        public static void DisplayHowToPlay(IConsoleService consoleService)
        {
            consoleService.Clear();
            consoleService.SetForegroundColor(ConsoleColor.Yellow);
            consoleService.WriteLine("How to Play Tic Tac Toe:");
            consoleService.ResetColor();
            consoleService.WriteLine("1. The game is played on a 3x3 grid.");
            consoleService.WriteLine("2. Players take turns to place their mark (X or O) in an empty cell.");
            consoleService.WriteLine("3. The first player to get three of their marks in a row (horizontally, vertically, or diagonally) wins.");
            consoleService.WriteLine("4. If all cells are filled and no player has three in a row, the game is a tie.");
            consoleService.WriteLine("");

            // Example Board
            consoleService.WriteLine("Example Board:");
            consoleService.WriteLine(" 1 | 2 | 3 ");
            consoleService.WriteLine("---+---+---");
            consoleService.WriteLine(" 4 | X | 6 ");
            consoleService.WriteLine("---+---+---");
            consoleService.WriteLine(" O | 8 | 9 ");
            consoleService.WriteLine("");

            // Winning Scenarios
            consoleService.WriteLine("Winning Scenarios: Get three in a row horizontally, vertically, or diagonally.");
            consoleService.WriteLine("");

            // Interaction Instructions
            consoleService.WriteLine("Game Controls:");
            consoleService.WriteLine("- Enter the number corresponding to the cell where you want to place your mark.");
            consoleService.WriteLine("");

            // Strategy Tips
            consoleService.SetForegroundColor(ConsoleColor.Cyan);
            consoleService.WriteLine("Tips:");
            consoleService.ResetColor();
            consoleService.WriteLine("- Try to control the center.");
            consoleService.WriteLine("- Watch out for and block your opponent's potential wins.");
            consoleService.WriteLine("");

            consoleService.SetForegroundColor(ConsoleColor.Green);
            consoleService.WriteLine("Press Enter to go back to the main menu or type 'menu' to return immediately.");
            consoleService.ResetColor();
            if (consoleService.ReadLine().Trim().ToLower() == "menu")
            {
                return;
            }
            consoleService.Clear();
        }
    }
}