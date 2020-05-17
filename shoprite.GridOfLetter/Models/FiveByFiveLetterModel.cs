using System.Collections.Generic;
using GridOfLetters.Domain.Entities;

namespace shoprite.GridOfLetter.Models
{
    public class FiveByFiveLetterModel
    {
        public char[,] CharacterList { get; set; }
        public List<string> WordsFound { get; set; }

        public string NoMatchFound { get; set; }
        public FiveByFiveLetterModel()
        {}
        public FiveByFiveLetterModel(char[,] character)
        {
            CharacterList = character;
        }

        public FiveByFiveLetterModel(GridLettersSearchResultsEntity entity)
        {
            CharacterList = entity.CharacterList;
            WordsFound = entity.WordsFound;
            NoMatchFound = entity.NoMatchFound;
        }
    }
}