using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_v3.Enums;

namespace Tic_Tac_Toe_v3.Interfaces
{
    public interface ITicTacToeBoard
    {
        bool CheckWin();
        bool IsBoardFull();
        void DisplayBoard();
        void SetMarkAtPosition(int position, Mark mark);
        Mark GetMarkAtPosition(int position);
    }
}
