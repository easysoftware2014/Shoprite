using System;
using System.Collections.Generic;
using System.Text;

namespace GridOfLetters.Domain.Entities
{
    public class GridLettersSearchResultsEntity
    {
        public char[,] CharacterList { get; set; }
        public List<string> WordsFound { get; set; }
        public string NoMatchFound { get; set; }

        public GridLettersSearchResultsEntity()
        {}
    }
}
