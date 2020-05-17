using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using shoprite.GridOfLetter.Helpers;

namespace GridOfLetters.UnitTests
{
    [TestClass]
    public class GridOfLettersUnitTests
    {
        [TestMethod]
        public void ShouldGenerateRandomCharacter()
        {
            var random = new RandomCharacter();
            var randomChar = random.GetRandomChar(5,5);

            Assert.IsInstanceOfType(randomChar, typeof(char[,]));
        }

        [TestMethod]
        public void ShouldBuildFiveByFiveLetterGrid()
        {
            var fiveByFiveGrid = new BuildFiveByFiveGrid();
            var grid = fiveByFiveGrid.BuildFiveByFiveLetterGrid(5, 5);

            Assert.AreEqual(grid.Count, 25);
        }

    }
}
