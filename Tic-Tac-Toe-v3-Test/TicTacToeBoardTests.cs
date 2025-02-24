using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_v3.Enums;
using Tic_Tac_Toe_v3.Interfaces;
using TicTacToeGame_v3.Board;

namespace Tic_Tac_Toe_v3_Test
{
    [TestClass]
    public class TicTacToeBoardTests
    {
        [TestMethod]
        public void Test_Board_Initialization()
        {
            // Arrange
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);

            // Act & Assert
            for (int position = 0; position < 9; position++)
            {
                var mark = board.GetMarkAtPosition(position);
                Assert.AreEqual(Mark.Empty, mark, $"Board position {position} is not initialized to empty.");
            }
        }

        [TestMethod]
        public void ResetBoard_SetsAllPositionsToEmpty()
        {
            // Arrange
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);

            // Act
            board.SetMarkAtPosition(0, Mark.X);
            board.ResetBoard();

            // Assert
            for (int i = 0; i < 9; i++)
            {
                Assert.AreEqual(Mark.Empty, board.GetMarkAtPosition(i));
            }
        }

        [TestMethod]
        public void SetMarkAtPosition_MarksPositionCorrectly()
        {
            // Arrange
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);

            // Act
            board.SetMarkAtPosition(0, Mark.X);

            // Assert
            Assert.AreEqual(Mark.X, board.GetMarkAtPosition(0));
        }

        [TestMethod]
        public void CheckWin_ReturnsTrueForWinningCondition()
        {
            // Arrange
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);

            // Set up a winning condition
            board.SetMarkAtPosition(0, Mark.X);
            board.SetMarkAtPosition(1, Mark.X);
            board.SetMarkAtPosition(2, Mark.X);

            // Act
            bool isWin = board.CheckWin();

            // Assert
            Assert.IsTrue(isWin);
        }

        [TestMethod]
        public void IsBoardFull_ReturnsTrueWhenBoardIsFull()
        {
            // Arrange
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);

            // Set up a full board
            for (int i = 0; i < 9; i++)
            {
                board.SetMarkAtPosition(i, Mark.X);
            }

            // Act
            bool isFull = board.IsBoardFull();

            // Assert
            Assert.IsTrue(isFull);
        }

        [TestMethod]
        public void BoardInitializesWithEmptyMarks()
        {
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);
            foreach (var mark in board.board)
            {
                Assert.AreEqual(Mark.Empty, mark);
            }
        }

        [TestMethod]
        public void CanSetAndGetMarkAtPosition()
        {
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);
            board.SetMarkAtPosition(0, Mark.X);
            var mark = board.GetMarkAtPosition(0);
            Assert.AreEqual(Mark.X, mark);
        }

        [TestMethod]
        public void PositionAvailableReturnsCorrectValue()
        {
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);
            Assert.IsTrue(board.IsPositionAvailable(0));
            board.SetMarkAtPosition(0, Mark.X);
            Assert.IsFalse(board.IsPositionAvailable(0));
        }

        [TestMethod]
        public void CheckWinIdentifiesRowWin()
        {
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);
            board.SetMarkAtPosition(0, Mark.X);
            board.SetMarkAtPosition(1, Mark.X);
            board.SetMarkAtPosition(2, Mark.X);
            Assert.IsTrue(board.CheckWin());
        }

        [TestMethod]
        public void CheckWinIdentifiesColumnWin()
        {
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);
            board.SetMarkAtPosition(0, Mark.O);
            board.SetMarkAtPosition(3, Mark.O);
            board.SetMarkAtPosition(6, Mark.O);
            Assert.IsTrue(board.CheckWin());
        }

        [TestMethod]
        public void CheckWinIdentifiesDiagonalWin()
        {
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);
            board.SetMarkAtPosition(0, Mark.O);
            board.SetMarkAtPosition(4, Mark.O);
            board.SetMarkAtPosition(8, Mark.O);
            Assert.IsTrue(board.CheckWin());
        }

        [TestMethod]
        public void IsBoardFullReturnsCorrectValue()
        {
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);
            for (int i = 0; i < 9; i++)
            {
                board.SetMarkAtPosition(i, i % 2 == 0 ? Mark.X : Mark.O);
            }
            Assert.IsTrue(board.IsBoardFull());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetMarkAtInvalidPositionThrowsException()
        {
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);
            board.SetMarkAtPosition(-1, Mark.X); // Using an invalid position
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetMarkAtInvalidPositionThrowsException()
        {
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);
            var mark = board.GetMarkAtPosition(9); // Accessing beyond the board's limit
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CannotOverwriteExistingMark()
        {
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);
            board.SetMarkAtPosition(0, Mark.X);
            board.SetMarkAtPosition(0, Mark.O); // Attempt to overwrite should throw exception
        }

        [TestMethod]
        public void CheckWinDoesNotFalselyIdentifyWins()
        {
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);
            board.SetMarkAtPosition(0, Mark.X);
            board.SetMarkAtPosition(1, Mark.O); // Different mark to break the line
            board.SetMarkAtPosition(2, Mark.X);
            Assert.IsFalse(board.CheckWin(), "CheckWin should not identify wins with broken lines.");
        }
        [TestMethod]
        public void IdentifiesTieGameCorrectly()
        {
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);
            // Set up a tie game scenario
            board.SetMarkAtPosition(0, Mark.X);
            board.SetMarkAtPosition(1, Mark.O);
            board.SetMarkAtPosition(2, Mark.X);
            board.SetMarkAtPosition(3, Mark.O);
            board.SetMarkAtPosition(4, Mark.X);
            board.SetMarkAtPosition(5, Mark.X);
            board.SetMarkAtPosition(6, Mark.O);
            board.SetMarkAtPosition(7, Mark.X);
            board.SetMarkAtPosition(8, Mark.O);

            Assert.IsTrue(board.IsBoardFull() && !board.CheckWin(), "The game should be identified as a tie.");
        }

        [TestMethod]
        public void SequentialGameStateValidation()
        {
            var consoleServiceMock = new Mock<IConsoleService>();
            var board = new TicTacToeBoard(consoleServiceMock.Object);
            // Simulate a sequence of moves
            board.SetMarkAtPosition(0, Mark.X);
            board.SetMarkAtPosition(1, Mark.O);
            board.SetMarkAtPosition(3, Mark.O);
            board.SetMarkAtPosition(8, Mark.X);

            // Verify game state after sequence of moves
            Assert.IsTrue(board.GetMarkAtPosition(0) == Mark.X &&
                          board.GetMarkAtPosition(1) == Mark.O &&
                          board.GetMarkAtPosition(3) == Mark.O &&
                          board.GetMarkAtPosition(8) == Mark.X, "The game state should accurately reflect the sequence of moves.");

            // Check for a win or tie situation
            Assert.IsFalse(board.CheckWin(), "There should not be a win yet.");
            Assert.IsFalse(board.IsBoardFull(), "The board should not be full yet.");
        }
        

    }
}

