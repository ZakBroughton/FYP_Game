using Tic_Tac_Toe_v3.Players;
using TicTacToeGame_v3.Enums;
using Tic_Tac_Toe_v3.Enums;
using Tic_Tac_Toe_v3.Game;
using Tic_Tac_Toe_v3.Interfaces;
using Tic_Tac_Toe_v3.Services;
using Tic_Tac_Toe_v3.Players.ComputerPlayer;
using TicTacToeGame_v3.Board;

class Program
{
    static void Main(string[] args)
    {
        IConsoleService consoleService = new ConsoleService();

        consoleService.WriteLine("Welcome to Tic Tac Toe!");
        consoleService.WriteLine();

        while (true)
        {
            DisplayMainMenu(consoleService);

            if (int.TryParse(consoleService.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        StartNewGame(consoleService);
                        break;
                    case 2:
                        GameUtils.DisplayHowToPlay(consoleService);
                        break;
                    case 3:
                        return;
                    default:
                        consoleService.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                consoleService.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }

    static void DisplayMainMenu(IConsoleService consoleService)
    {
        consoleService.WriteLine("Choose an option:");
        consoleService.WriteLine("1. Start a New Game");
        consoleService.WriteLine("2. How to Play");
        consoleService.WriteLine("3. Exit");
        consoleService.Write("Enter your choice: ");
    }

    static void StartNewGame(IConsoleService consoleService)
    {
        Player playerX = new HumanPlayer(Mark.X, consoleService);
        Player playerO;

        consoleService.WriteLine("Select opponent:");
        consoleService.WriteLine("1. Human");
        consoleService.WriteLine("2. Computer (Random)");
        consoleService.WriteLine("3. Computer (Smart)");
        consoleService.Write("Enter your choice: ");

        if (int.TryParse(consoleService.ReadLine(), out int choice))
        {
            switch (choice)
            {
                case 1:
                    playerO = new HumanPlayer(Mark.O, consoleService);
                    break;
                case 2:
                    playerO = new RandomComputerPlayer(Mark.O);
                    break;
                case 3:
                    playerO = new SmartComputerPlayer(Mark.O);
                    break;
                default:
                    consoleService.WriteLine("Invalid choice. Defaulting to Random Computer Player.");
                    playerO = new RandomComputerPlayer(Mark.O);
                    break;
            }

            var game = new TicTacToeGame(playerX, playerO, consoleService, new TicTacToeBoard(consoleService));
            game.StartGame();
        }
        else
        {
            consoleService.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}