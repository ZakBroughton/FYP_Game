using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tic_Tac_Toe_v3.Enums;

namespace Tic_Tac_Toe_v3_Test
{
    [TestClass]
    public class MarkEnumTests
    {
        [TestMethod]
        public void EnumValues_AreCorrect()
        {
            // Arrange
            var expectedValues = new[] { Mark.Empty, Mark.X, Mark.O };

            // Act
            var actualValues = (Mark[])Enum.GetValues(typeof(Mark));

            // Assert
            CollectionAssert.AreEqual(expectedValues, actualValues);
        }
    }
}