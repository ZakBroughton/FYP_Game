using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_v3.Enums;
using Tic_Tac_Toe_v3.Players;
using TicTacToeGame_v3.Board;

namespace Tic_Tac_Toe_v3.Players.ComputerPlayer
{
    public class SmartComputerPlayer : Player
    {
        public SmartComputerPlayer(Mark mark) : base(mark) { }

        public override int GetMove(TicTacToeBoard board)
        {
            int bestMove = -1;
            int bestValue = int.MinValue;
            int alpha = int.MinValue;
            int beta = int.MaxValue;

            for (int i = 0; i < board.board.Length; i++)
            {
                if (board.IsPositionAvailable(i))
                {
                    board.SetMarkAtPosition(i, Mark);
                    int moveValue = MiniMax(board, 0, false, alpha, beta);
                    board.SetMarkAtPosition(i, Mark.Empty);

                    if (moveValue > bestValue)
                    {
                        bestMove = i;
                        bestValue = moveValue;
                    }

                   
                    alpha = Math.Max(alpha, bestValue);
                    if (beta <= alpha)
                    {
                        break; 
                    }
                }
            }
            return bestMove;
        }

        private int MiniMax(TicTacToeBoard board, int depth, bool isMax, int alpha, int beta)
        {
            if (board.CheckWin()) return isMax ? -10 : 10;
            if (board.IsBoardFull()) return 0;

            if (isMax)
            {
                int best = int.MinValue;
                for (int i = 0; i < board.board.Length; i++)
                {
                    if (board.IsPositionAvailable(i))
                    {
                        board.SetMarkAtPosition(i, Mark);
                        int val = MiniMax(board, depth + 1, false, alpha, beta);
                        board.SetMarkAtPosition(i, Mark.Empty);
                        best = Math.Max(best, val);

                   
                        alpha = Math.Max(alpha, best);
                        if (beta <= alpha)
                        {
                            break; 
                        }
                    }
                }
                return best;
            }
            else
            {
                int best = int.MaxValue;
                for (int i = 0; i < board.board.Length; i++)
                {
                    if (board.IsPositionAvailable(i))
                    {
                        board.SetMarkAtPosition(i, Mark == Mark.X ? Mark.O : Mark.X);
                        int val = MiniMax(board, depth + 1, true, alpha, beta);
                        board.SetMarkAtPosition(i, Mark.Empty);
                        best = Math.Min(best, val);

                      
                        beta = Math.Min(beta, best);
                        if (beta <= alpha)
                        {
                            break; 
                        }
                    }
                }
                return best;
            }
        }
    }
}



//namespace Tic_Tac_Toe_v3.Players.ComputerPlayer
//{
//public class SmartComputerPlayer : Player
//{
//public SmartComputerPlayer(Mark mark) : base(mark) { }

//public override int GetMove(TicTacToeBoard board)
//{
//int bestMove = -1;
//int bestValue = int.MinValue;
//for (int i = 0; i < board.board.Length; i++)
//{
//if (board.IsPositionAvailable(i))
//{
//board.SetMarkAtPosition(i, Mark);
//int moveValue = MiniMax(board, 0, false);
//board.SetMarkAtPosition(i, Mark.Empty);
//if (moveValue > bestValue)
//{
//bestMove = i;
//bestValue = moveValue;
//                }
//            }
//        }
//return bestMove;
//    }

//private int MiniMax(TicTacToeBoard board, int depth, bool isMax)
//{
//if (board.CheckWin()) return isMax ? -10 : 10;
//if (board.IsBoardFull()) return 0;
//
//if (isMax)
//{
//int best = int.MinValue;
//for (int i = 0; i < board.board.Length; i++)
//{
//if (board.IsPositionAvailable(i))
//{
//board.SetMarkAtPosition(i, Mark);
//int val = MiniMax(board, depth + 1, false);
//board.SetMarkAtPosition(i, Mark.Empty);
//best = Math.Max(best, val);
//                }
//            }
//return best;
//        }
//        else
//{
//int best = int.MaxValue;
//for (int i = 0; i < board.board.Length; i++)
//{
//if (board.IsPositionAvailable(i))
//{
//board.SetMarkAtPosition(i, Mark == Mark.X ? Mark.O : Mark.X);
//int val = MiniMax(board, depth + 1, true);
//board.SetMarkAtPosition(i, Mark.Empty);
//best = Math.Min(best, val);
//            }
//return best;
//        }
//    }
//}
//}




//namespace Tic_Tac_Toe_v3.Players.ComputerPlayer
//{
//    public class SmartComputerPlayer : Player
//{
//    public SmartComputerPlayer(Mark mark) : base(mark) { }

//    public override int GetMove(TicTacToeBoard board)
//   {
// Winning move
//        int? winningMove = FindWinningMove(board, Mark);
//        if (winningMove.HasValue) return winningMove.Value;

// Block opponent's winning move
//        Mark opponentMark = Mark == Mark.X ? Mark.O : Mark.X;
//        int? blockingMove = FindWinningMove(board, opponentMark);
//        if (blockingMove.HasValue) return blockingMove.Value;

// Take center if available
//        if (board.IsPositionAvailable(4)) return 4;

// Take any corner if available
//        int[] corners = { 0, 2, 6, 8 };
//        foreach (var corner in corners)
//        {
//            if (board.IsPositionAvailable(corner)) return corner;
//        }

// Default to any available position
//        return Enumerable.Range(0, 9).First(pos => board.IsPositionAvailable(pos));
//    }//

//    private int? FindWinningMove(TicTacToeBoard board, Mark mark)
//    {
//        for (int i = 0; i < 9; i++)
//        {
//            if (board.IsPositionAvailable(i))
//            {
//                board.SetMarkAtPosition(i, mark);
//                bool wins = board.CheckWin();
//                board.SetMarkAtPosition(i, Mark.Empty); // Reset
//                if (wins) return i;
//            }
//        }
//
//        return null;
//}
//}
//}

//
//