namespace shoprite.GridOfLetter.Models
{
    public class FiveByFiveLetterModel
    {
        public char[,] CharacterList { get; set; }

        public FiveByFiveLetterModel()
        {}

        public FiveByFiveLetterModel(char[,] characters)
        {
            CharacterList = characters;
        }
    }
}