using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_v3.Enums;
using TicTacToeGame_v3.Board;

namespace Tic_Tac_Toe_v3.Players.ComputerPlayer
{
    public class RandomComputerPlayer : Player
    {
        private static Random random = new Random();

        public RandomComputerPlayer(Mark mark) : base(mark)
        {
            random = new Random();
        }

        public override int GetMove(TicTacToeBoard board)
        {
            var availablePositions = Enumerable.Range(0, 9).Where(pos => board.IsPositionAvailable(pos)).ToList();
            if (availablePositions.Count == 0)
            {
                throw new InvalidOperationException("No available positions.");
            }
            int position = availablePositions[random.Next(availablePositions.Count)];
            return position;
        }
    }
}