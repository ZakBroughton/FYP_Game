using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_v3.Players.ComputerPlayer;
using Tic_Tac_Toe_v3.Players;
using TicTacToeGame_v3.Board;
using TicTacToeGame_v3.Enums;
using Tic_Tac_Toe_v3.Enums;
using Tic_Tac_Toe_v3.Interfaces;

namespace Tic_Tac_Toe_v3.Game
{
    public class TicTacToeGame
    {
        public ITicTacToeBoard board;
        public Player playerX;
        public Player playerO;
        public Player currentPlayer;
        public IConsoleService consoleService;

        public TicTacToeGame(Player playerX, Player playerO, IConsoleService consoleService, ITicTacToeBoard board)
        {
            this.consoleService = consoleService ?? throw new ArgumentNullException(nameof(consoleService));
            this.board = board ?? throw new ArgumentNullException(nameof(board));
            this.playerX = playerX;
            this.playerO = playerO;
            DetermineFirstPlayer();
        }
        public void DetermineFirstPlayer()
        {
            var random = new Random();
            currentPlayer = random.Next(2) == 0 ? playerX : playerO;
        }

        public void StartGame()
        {
            consoleService.Clear();
            DisplayGameStartMessage();

            while (!IsGameOver())
            {
                DisplayBoard();
                MakeMove();
                SwitchPlayer();
            }

            DisplayGameOverMessage();
        }

        public void DisplayGameStartMessage()
        {
            consoleService.WriteLine("Tic Tac Toe");
            consoleService.WriteLine($"{playerX.Mark} is Player X, {playerO.Mark} is Player O.");
            consoleService.WriteLine("");
        }

        public bool IsGameOver()
        {
            if (IsWin())
            {
                DisplayWinningMessage();
                return true;
            }

            if (IsTie())
            {
                DisplayTieMessage();
                return true;
            }

            return false;
        }

        public bool IsWin()
        {
            if (board.CheckWin())
            {
                DisplayBoard();
                return true;
            }
            return false;
        }

        public bool IsTie()
        {
            if (board.IsBoardFull())
            {
                DisplayBoard();
                return true;
            }
            return false;
        }

        public void DisplayBoard()
        {
            board.DisplayBoard();
        }

        private void DisplayWinningMessage()
        {
            var winningPlayer = (currentPlayer == playerX) ? playerO : playerX;
            consoleService.WriteLine($"Player {winningPlayer.Mark} wins!");
        }

        private void DisplayTieMessage()
        {
            consoleService.WriteLine("It's a tie!");
        }

        public void MakeMove()
        {
            int move = currentPlayer.GetMove((TicTacToeBoard)board);
            board.SetMarkAtPosition(move, currentPlayer.Mark);
        }

        public void SwitchPlayer()
        {
            currentPlayer = currentPlayer == playerX ? playerO : playerX;
        }

        public void DisplayGameOverMessage()
        {
            consoleService.WriteLine("\nGame Over. Press any key to exit.");
            consoleService.ReadKey();
        }
    }
}