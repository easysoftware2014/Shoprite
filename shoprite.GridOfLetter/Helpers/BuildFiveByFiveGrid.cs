using System.Collections.Generic;

namespace shoprite.GridOfLetter.Helpers
{
    public class BuildFiveByFiveGrid
    {
        public List<char> BuildFiveByFiveLetterGrid(int rowDimension, int columnDimension)
        {
            var random = new RandomCharacter();
            
            return random.GetRandomChar(rowDimension, columnDimension);
        }
        
    }
}