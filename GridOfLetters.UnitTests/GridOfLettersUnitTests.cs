using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using shoprite.GridOfLetter.Helpers;

namespace GridOfLetters.UnitTests
{
    [TestClass]
    public class GridOfLettersUnitTests
    {
       
        [TestMethod]
        public void Should_BuildFiveByFiveLetterGrid_success()
        {
            var fiveByFiveGrid = new RandomCharacters();
            var grid = fiveByFiveGrid.GetRandomChar(5, 5);

            Assert.AreEqual(25, grid.Count);
            Assert.IsInstanceOfType(grid, typeof(List<char>));
        }
        [TestMethod]
        public void Should_NotBuildFiveByFiveLetterGrid()
        {
            var fiveByFiveGrid = new RandomCharacters();
            var grid = fiveByFiveGrid.GetRandomChar(2, 5);

            Assert.AreNotEqual(grid.Count, 25);
        }

    }
}
