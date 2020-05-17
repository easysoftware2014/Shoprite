using System;
using System.Collections.Generic;

namespace shoprite.GridOfLetter.Helpers
{
    public class RandomCharacter
    {
        public List<char> GetRandomChar(int rowDimension, int columnDimension)
        {
            var randomNumber = new Random();
            var charArray = new char[5, 5];
            var list = new List<char>();

            for (var i = 0; i < rowDimension; i++)
            {
                for (var j = 0; j < columnDimension; j++)
                {
                    var random = randomNumber.Next('a', 'z');
                    charArray[i, j] = (char) random;
                    list.Add((char)random);
                }
                
            }
            return list;
        }
    }
}