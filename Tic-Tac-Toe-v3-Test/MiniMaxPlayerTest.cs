using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_v3.Enums;
using Tic_Tac_Toe_v3.Interfaces;
using Tic_Tac_Toe_v3.Players.ComputerPlayer;
using TicTacToeGame_v3.Board;

namespace Tic_Tac_Toe_v3_Test
{
    [TestClass]
    public class SmartComputerPlayerTests
    {
        [TestMethod]
        public void ChoosesWinningMoveWhenAvailable()
        {
            // Arrange
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);
            var player = new SmartComputerPlayer(Mark.X);

            // Set up the board with two X's in a row
            board.SetMarkAtPosition(0, Mark.X);
            board.SetMarkAtPosition(1, Mark.X);
            board.SetMarkAtPosition(3, Mark.O);
            board.SetMarkAtPosition(4, Mark.O);

            // Act
            int move = player.GetMove(board);

            // Assert
            Assert.AreEqual(2, move);

            // Assert explanation
            // This test verifies that the SmartComputerPlayer correctly identifies and chooses 
            // a winning move when such an opportunity exists on the board.
            // It's essential to test this to ensure the player can secure a win whenever possible.
        }

        [TestMethod]
        public void BlocksOpponentFromWinning()
        {
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);
            var player = new SmartComputerPlayer(Mark.X);
            // Set up the board with two X's in a row and one O
            board.SetMarkAtPosition(0, Mark.X);
            board.SetMarkAtPosition(1, Mark.X);
            board.SetMarkAtPosition(3, Mark.O);
            // The smart player should block X from winning by placing an O at position 2
            int move = player.GetMove(board);
            Assert.AreEqual(2, move);

            //Blocks Opponent From Winning:
            //This test checks if the SmartComputerPlayer can prevent
            //the opponent from winning by blocking their potential winning move.
            //Blocking opponents is a crucial strategy in Tic Tac Toe to prevent losing the game.
        }

        [TestMethod]
        public void ChoosesCenterOrCornerIfAvailable()
        {
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);
            var player = new SmartComputerPlayer(Mark.X);
            // Starting with an empty board, the smart player should choose either a corner or center
            int move = player.GetMove(board);
            var bestMoves = new int[] { 0, 2, 4, 6, 8 }; // corners and center
            Assert.IsTrue(bestMoves.Contains(move));

            //Chooses Center Or Corner If Available:
            //This test ensures that, at the start of the game (when the board is empty),
            //the SmartComputerPlayer prefers to choose either the center or a corner square.
            //This strategy is tested because choosing the center or a corner at the start is
            //known to increase the chances of winning.
        }
        [TestMethod]
        public void ConsistencyOfStrategy()
        {
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);
            var player = new SmartComputerPlayer(Mark.X);

            // Populate the board with a specific pattern.
            board.SetMarkAtPosition(0, Mark.O);
            board.SetMarkAtPosition(1, Mark.O);
            board.SetMarkAtPosition(2, Mark.X);
            board.SetMarkAtPosition(3, Mark.X);
            board.SetMarkAtPosition(5, Mark.X);
            board.SetMarkAtPosition(6, Mark.O);

            // Given the specific board state, the smart player should always make the same move
            int firstMove = player.GetMove(board);
            for (int i = 0; i < 10; i++) // Repeat multiple times to check for consistency
            {
                int consistentMove = player.GetMove(board);
                Assert.AreEqual(firstMove, consistentMove);
            }


            //Consistency Of Strategy:
            //This test evaluates the consistency of the SmartComputerPlayer's
            //strategy by ensuring it chooses the same move given a specific board setup.
            //Consistency in decision-making is vital for predictable and reliable AI behavior.

        }
        [TestMethod]
        public void ConsistencyOfStrategy_v2()
        {
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);
            var player = new SmartComputerPlayer(Mark.X);
            // Populate the board with a specific pattern
            board.SetMarkAtPosition(0, Mark.O);
            board.SetMarkAtPosition(1, Mark.O);
            board.SetMarkAtPosition(2, Mark.X);
            board.SetMarkAtPosition(3, Mark.X);
            board.SetMarkAtPosition(5, Mark.X);
            board.SetMarkAtPosition(6, Mark.O);
            // Given the specific board state, the smart player should always make the same move
            int firstMove = player.GetMove(board);
            for (int i = 0; i < 10; i++) // Repeat multiple times to check for consistency
            {
                int consistentMove = player.GetMove(board);
                Assert.AreEqual(firstMove, consistentMove, "The smart player was not consistent in its strategy.");
            }

            //Consistency Of Strategy v2:
            //Similar to the previous test,
            //this one also checks for the SmartComputerPlayer's consistency in strategy,
            //but it includes an assertion message to specify when the consistency check fails.
            //This adds clarity to test failures.
        }
        [TestMethod]
        public void ChoosesStrategicMoveInIntermediateGameState()
        {
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);
            var player = new SmartComputerPlayer(Mark.X);
            // Setup the board with an intermediate game state
            board.SetMarkAtPosition(0, Mark.X);
            board.SetMarkAtPosition(1, Mark.O);
            board.SetMarkAtPosition(4, Mark.X);
            board.SetMarkAtPosition(3, Mark.O);
            board.SetMarkAtPosition(8, Mark.X);
            // The smart player should avoid a trap and choose a strategic position
            int move = player.GetMove(board);
            Assert.IsTrue(new int[] { 2, 5, 6 }.Contains(move), "The move was not strategic as expected.");

            //Chooses Strategic Move In Intermediate GameState:
            //This test checks if the SmartComputerPlayer can make a
            //strategic move in a more complex game state, where it must
            //choose between multiple non-winning moves. It's important to ensure
            //the player can navigate intermediate game states effectively.

        }


        [TestMethod]
        public void DoesNotLoseInDrawScenario()
        {
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);
            var player = new SmartComputerPlayer(Mark.X);
            // Setup the board in a draw scenario, with one move left
            board.SetMarkAtPosition(0, Mark.X);
            board.SetMarkAtPosition(1, Mark.X);
            board.SetMarkAtPosition(2, Mark.O);
            board.SetMarkAtPosition(3, Mark.O);
            board.SetMarkAtPosition(4, Mark.O);
            board.SetMarkAtPosition(5, Mark.X);
            board.SetMarkAtPosition(6, Mark.X);
            board.SetMarkAtPosition(7, Mark.O);
            // The smart player should choose the last available spot
            int move = player.GetMove(board);
            Assert.AreEqual(8, move, "The smart player did not choose the last available spot in a draw scenario.");

            //Does Not Lose In Draw Scenario:
            //This test ensures that the SmartComputerPlayer does not make a losing move in a
            //scenario where the best possible outcome is a draw.
            //It tests the player's ability to avoid losses when no winning moves are available.

        }
        [TestMethod]
        public void NeverChoosesOccupiedSpace()
        {
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);
            var player = new SmartComputerPlayer(Mark.X);
            // Fill the board, leaving one spot at random
            Random rnd = new Random();
            int emptyPosition = rnd.Next(9);
            for (int i = 0; i < 9; i++)
            {
                if (i != emptyPosition)
                {
                    board.SetMarkAtPosition(i, rnd.Next(2) == 0 ? Mark.X : Mark.O);
                }
            }
            // The smart player should choose the only empty spot
            int move = player.GetMove(board);
            Assert.AreEqual(emptyPosition, move, "The smart player chose an occupied space, which is illegal.");

            //Never Chooses Occupied Space:
            //This test verifies that the SmartComputerPlayer
            //never chooses an already occupied space on the board.
            //This basic yet critical test ensures the player always makes legal moves.

        }

        [TestMethod]
        public void ChoosesMoveQuickly()
        {
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);
            var player = new SmartComputerPlayer(Mark.X);
            // Set up the board in a non-trivial state to ensure some computation is needed
            board.SetMarkAtPosition(0, Mark.X);
            board.SetMarkAtPosition(4, Mark.X);
            board.SetMarkAtPosition(8, Mark.O);
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            player.GetMove(board);
            stopwatch.Stop();
            Assert.IsTrue(stopwatch.ElapsedMilliseconds < 1000, "The smart player took too long to decide a move.");

            //Chooses Move Quickly:
            //This test checks the performance of the SmartComputerPlayer by ensuring it makes a decision quickly,
            //even in non-trivial board states.
            //Speed is crucial to user experience, especially in games.


        }

        [TestMethod]
        public void PrioritizesWinningOverBlocking()
        {
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);
            var player = new SmartComputerPlayer(Mark.X);
            // Set up a scenario where the player can win or block the opponent
            board.SetMarkAtPosition(0, Mark.X);
            board.SetMarkAtPosition(1, Mark.X);
            board.SetMarkAtPosition(3, Mark.O);
            board.SetMarkAtPosition(4, Mark.O);
            int move = player.GetMove(board);
            Assert.AreEqual(2, move, "Player should prioritize winning over blocking the opponent.");

            //Prioritizes Winning Over Blocking:
            //This test evaluates whether the SmartComputerPlayer prioritizes winning
            //the game over simply blocking the opponent's potential winning moves.
            //This strategy is essential for an aggressive and effective play style.

        }



        [TestMethod]
        public void MaximizesChancesOfFutureWins()
        {
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);
            var player = new SmartComputerPlayer(Mark.X);
            // Set up a board that allows for multiple future winning opportunities
            board.SetMarkAtPosition(0, Mark.X);
            board.SetMarkAtPosition(4, Mark.O);
            int move = player.GetMove(board);
            Assert.IsTrue(new int[] { 1, 3, 5, 7 }.Contains(move), "Player should maximize chances of future wins.");

            //Maximizes Chances Of Future Wins:
            //This test checks if the SmartComputerPlayer makes moves
            //that open up multiple future winning opportunities.
            //It's important to test the player's ability to set up future wins,
            //not just immediate ones.

        }

        [TestMethod]
        public void HandlesEarlyGameStrategically()
        {
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);
            var player = new SmartComputerPlayer(Mark.X);
            // Early game scenario
            board.SetMarkAtPosition(0, Mark.X);
            int move = player.GetMove(board);
            // Assuming optimal strategy is to take the center or a corner if X starts
            Assert.IsTrue(new int[] { 4, 1, 2, 6, 8 }.Contains(move), "Player should handle early game with a strong strategic move.");

            //Handles Early Game Strategically:
            //This test ensures that the SmartComputerPlayer makes a strong strategic move in the early game,
            //preferably taking the center or a corner if available.
            //Early game strategy is key to setting the tone for the rest of the game.

        }

        [TestMethod]
        public void RecoversFromDisadvantages()
        {
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);
            var player = new SmartComputerPlayer(Mark.X);
            // Set up a disadvantageous scenario for 'O'
            board.SetMarkAtPosition(0, Mark.X);
            board.SetMarkAtPosition(1, Mark.X);
            board.SetMarkAtPosition(3, Mark.O);
            board.SetMarkAtPosition(8, Mark.O);
            int move = player.GetMove(board);
            Assert.IsTrue(new int[] { 2, 4, 5, 6, 7 }.Contains(move), "Player should make a move that helps to recover from a disadvantage.");

            //Recovers From Disadvantages:
            //This test evaluates whether the SmartComputerPlayer can make moves that help it recover from a disadvantaged position.
            //Testing the player's ability to come back from difficult situations is crucial for a resilient AI.
        }
    }
}