using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_v3.Enums;
using Tic_Tac_Toe_v3.Game;
using Tic_Tac_Toe_v3.Interfaces;
using Tic_Tac_Toe_v3.Players;
using Tic_Tac_Toe_v3.Players.ComputerPlayer;
using TicTacToeGame_v3.Board;

namespace Tic_Tac_Toe_v3_Test
{
    [TestClass]
    public class TicTacToeGameTests
    {
        [TestMethod]
        public void TestGameInitialization()
        {
            // Arrange
            var consoleServiceMock = new Mock<IConsoleService>();
            var boardMock = new Mock<ITicTacToeBoard>();

            // Create actual instances of Player instead of mocking
            var playerX = new HumanPlayer(Mark.X, consoleServiceMock.Object);
            var playerO = new SmartComputerPlayer(Mark.O);

            // Act
            var game = new TicTacToeGame(playerX, playerO, consoleServiceMock.Object, boardMock.Object);

            // Assert
            Assert.IsNotNull(game);
            Assert.IsNotNull(game.board);
            Assert.IsNotNull(game.playerX);
            Assert.IsNotNull(game.playerO);
            Assert.IsNotNull(game.consoleService);
            Assert.IsNotNull(game.currentPlayer);
        }

        [TestMethod]
        public void TestDetermineFirstPlayer()
        {
            // Arrange
            var consoleServiceMock = new Mock<IConsoleService>();
            var boardMock = new Mock<ITicTacToeBoard>();

            // Create actual instances of Player instead of mocking
            var playerX = new HumanPlayer(Mark.X, consoleServiceMock.Object);
            var playerO = new SmartComputerPlayer(Mark.O);

            // Act
            var game = new TicTacToeGame(playerX, playerO, consoleServiceMock.Object, boardMock.Object);

            // Assert
            Assert.IsTrue(game.currentPlayer == game.playerX || game.currentPlayer == game.playerO);
        }


       

        [TestMethod]
        public void TestIsWin_PlayerWins()
        {
            // Arrange
            var consoleServiceMock = new Mock<IConsoleService>();
            var boardMock = new Mock<ITicTacToeBoard>();
            boardMock.Setup(b => b.CheckWin()).Returns(true);
            // Arrange
           
            // Create actual instances of Player instead of mocking
            var playerX = new HumanPlayer(Mark.X, consoleServiceMock.Object);
            var playerO = new SmartComputerPlayer(Mark.O);

            var game = new TicTacToeGame(playerX, playerO, consoleServiceMock.Object, boardMock.Object);


            // Act
            var result = game.IsWin();

            // Assert
            Assert.IsTrue(result);
        }

   

     

        [TestMethod]
        public void TestIsTie_BoardIsNotFull()
        {
            var consoleServiceMock = new Mock<IConsoleService>();
            var boardMock = new Mock<ITicTacToeBoard>();
            boardMock.Setup(b => b.CheckWin()).Returns(true);
            // Arrange

            // Create actual instances of Player instead of mocking
            var playerX = new HumanPlayer(Mark.X, consoleServiceMock.Object);
            var playerO = new SmartComputerPlayer(Mark.O);

            var game = new TicTacToeGame(playerX, playerO, consoleServiceMock.Object, boardMock.Object);


            // Act
            var result = game.IsTie();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestIsTie_BoardIsFullAndNoWin()
        {
            // Arrange
            var consoleServiceMock = new Mock<IConsoleService>();
            var boardMock = new Mock<ITicTacToeBoard>();
            boardMock.Setup(b => b.CheckWin()).Returns(false);
            boardMock.Setup(b => b.IsBoardFull()).Returns(true);

            var playerX = new HumanPlayer(Mark.X, consoleServiceMock.Object);
            var playerO = new SmartComputerPlayer(Mark.O);
            var game = new TicTacToeGame(playerX, playerO, consoleServiceMock.Object, boardMock.Object);

            // Act
            var result = game.IsTie();

            // Assert
            Assert.IsTrue(result, "The game should be identified as a tie when the board is full and there is no win.");
        }



       


    }
}