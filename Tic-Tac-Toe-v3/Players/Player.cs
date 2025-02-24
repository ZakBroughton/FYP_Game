using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_v3.Enums;
using TicTacToeGame_v3.Board;

namespace Tic_Tac_Toe_v3.Players
{
    public abstract class Player
    {
        public Mark Mark { get; set; }

        protected Player(Mark mark)
        {
            Mark = mark;
        }

        public abstract int GetMove(TicTacToeBoard board);
    }
}