using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeGame_v3.Enums;

namespace Tic_Tac_Toe_v3_Test
{
    [TestClass]
    public class ComputerPlayerTypeTests
    {
        [TestMethod]
        public void EnumValues_AreCorrect()
        {
            // Arrange
            var expectedValues = new[] { ComputerPlayerType.Random, ComputerPlayerType.Smart };

            // Act
            var actualValues = (ComputerPlayerType[])Enum.GetValues(typeof(ComputerPlayerType));

            // Assert
            CollectionAssert.AreEqual(expectedValues, actualValues);
        }
    }
}