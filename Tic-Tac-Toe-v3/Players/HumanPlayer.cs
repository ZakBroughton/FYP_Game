using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_v3.Enums;
using Tic_Tac_Toe_v3.Interfaces;
using Tic_Tac_Toe_v3.Services;
using TicTacToeGame_v3.Board;

namespace Tic_Tac_Toe_v3.Players
{
    public class HumanPlayer : Player
    {
        private readonly IConsoleService consoleService;

        public HumanPlayer(Mark mark, IConsoleService consoleService) : base(mark)
        {
            this.consoleService = consoleService;
        }

        public override int GetMove(TicTacToeBoard board)
        {
            int position = -1;
            bool isValidInput = false;

            while (!isValidInput)
            {
                consoleService.WriteLine($"Player {Mark}, enter your move (1-9): ");
                string userInput = consoleService.ReadLine(); 
                isValidInput = int.TryParse(userInput, out position) && position >= 1 && position <= 9 && board.IsPositionAvailable(position - 1);

                if (!isValidInput)
                {
                    consoleService.WriteLine("Invalid move, please try again.");
                }
            }

            return position - 1;
        }
    }
}