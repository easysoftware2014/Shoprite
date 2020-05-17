using System;
using System.Collections.Generic;

namespace shoprite.GridOfLetter.Helpers
{
    public class RandomCharacters
    {
        public List<char> GetRandomChar(int rowDimension, int columnDimension)
        {
            var randomNumber = new Random();
            var list = new List<char>();

            for (var i = 0; i < rowDimension; i++)
            {
                for (var j = 0; j < columnDimension; j++)
                {
                    var random = randomNumber.Next('a', 'z');
                    list.Add((char)random);
                }
                
            }
            return list;
        }
    }
}