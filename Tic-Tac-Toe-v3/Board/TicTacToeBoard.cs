using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Tic_Tac_Toe_v3.Enums;
using Tic_Tac_Toe_v3.Interfaces;
using Tic_Tac_Toe_v3.Services;
[assembly: InternalsVisibleTo("Tic-Tac-Toe-v3-Test")]

namespace TicTacToeGame_v3.Board
{
    public class TicTacToeBoard : ITicTacToeBoard
    {
        private IConsoleService consoleService;
        private const int BoardSize = 9;
        public Mark[] board = new Mark[BoardSize];

        public TicTacToeBoard(IConsoleService consoleService)
        {
            this.consoleService = consoleService ?? throw new ArgumentNullException(nameof(consoleService));
            ResetBoard();
        }

        public void ResetBoard()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                board[i] = Mark.Empty;
            }
        }

        public Mark GetMarkAtPosition(int position)
        {
            ValidatePosition(position);
            return board[position];
        }

        public void SetMarkAtPosition(int position, Mark mark)
        {
            ValidatePosition(position);
            if (mark != Mark.Empty && !IsPositionAvailable(position))
            {
                throw new InvalidOperationException("Position is already occupied.");
            }
            board[position] = mark;
        }

        public bool IsPositionAvailable(int position)
        {
            ValidatePosition(position);
            return board[position] == Mark.Empty;
        }

        private void ValidatePosition(int position)
        {
            if (position < 0 || position >= BoardSize)
            {
                throw new ArgumentOutOfRangeException(nameof(position), "Position must be within the board boundaries.");
            }
        }

        public void DisplayBoard()
        {
            consoleService.Clear();
            consoleService.WriteLine("Tic Tac Toe");
            consoleService.WriteLine("Player X - Human, Player O - Computer");
            consoleService.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int position = i * 3 + j;
                    var mark = board[position];
                    consoleService.Write(mark == Mark.Empty ? $" {position + 1} " : mark == Mark.X ? " X " : " O ");
                    if (j < 2) consoleService.Write("|");
                }
                consoleService.WriteLine();
                if (i < 2) consoleService.WriteLine("---+---+---");
            }
            consoleService.WriteLine();
        }

        public bool CheckWin()
        {
            return CheckRows() || CheckColumns() || CheckDiagonals();
        }

        private bool CheckRows()
        {
            for (int i = 0; i < 9; i += 3)
            {
                if (board[i] != Mark.Empty && board[i] == board[i + 1] && board[i] == board[i + 2])
                    return true;
            }
            return false;
        }

        private bool CheckColumns()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i] != Mark.Empty && board[i] == board[i + 3] && board[i] == board[i + 6])
                    return true;
            }
            return false;
        }

        private bool CheckDiagonals()
        {
            return (board[0] != Mark.Empty && board[0] == board[4] && board[0] == board[8]) ||
                   (board[2] != Mark.Empty && board[2] == board[4] && board[2] == board[6]);
        }


        public bool IsBoardFull()
        {
            return board.All(mark => mark != Mark.Empty);
        }

        
    }
}