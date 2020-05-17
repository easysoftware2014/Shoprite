using System;
using System.Collections.Generic;
using System.IO;

namespace shoprite.GridOfLetter.Helpers
{
    /// <summary>
    /// I have researched the code below to do the recursive search
    /// and tweaked it to meet the requirements
    /// https://thedeveloperblog.com/word-search
    /// </summary>
    public class RecursiveSearch
    {
        static Dictionary<string, WordType> _words = new Dictionary<string, WordType>(400000, StringComparer.Ordinal);
        static Dictionary<string, string> _found = new Dictionary<string, string>(StringComparer.Ordinal);
        const int _minLength = 2; // Minimum length of matching words.

        public RecursiveSearch()
        {
            _words = new Dictionary<string, WordType>(400000, StringComparer.Ordinal);
            _found = new Dictionary<string, string>(StringComparer.Ordinal);
        }

        public Dictionary<string, string> ReadFile(string path, char[,] array, int rowDimension, int columnDimension)
        {
            using (var reader = new StreamReader(path))
            {
                while (true)
                {
                    var line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    if (line.Length >= _minLength)
                    {
                        for (var i = 1; i <= line.Length; i++)
                        {
                            var substring = line.Substring(0, i);
                            WordType value;

                            if (_words.TryGetValue(substring, out value))
                            {
                                // If this is a full word.
                                if (i == line.Length)
                                {
                                    // If only partial word is stored.
                                    if (value == WordType.PartialWord)
                                    {
                                        // Upgrade type.
                                        _words[substring] = WordType.FullWordAndPartialWord;
                                    }
                                }
                                else
                                {
                                    // If not a full word and only partial word is stored.
                                    if (value == WordType.FullWord)
                                    {
                                        _words[substring] = WordType.FullWordAndPartialWord;
                                    }
                                }
                            }
                            else
                            {
                                // If this is a full word.
                                if (i == line.Length)
                                {
                                    _words.Add(substring, WordType.FullWord);
                                }
                                else
                                {
                                    _words.Add(substring, WordType.PartialWord);
                                }
                            }
                        }
                    }
                }
            }
           
            for (var i = 0; i < rowDimension; i++)
            {
                for (var a = 0; a < columnDimension; a++)
                {
                    // Search all directions.
                    for (var d = 0; d < 8; d++)
                    {
                        SearchAt(array, i, a, columnDimension, rowDimension, "", d);
                    }
                }
            }

            return _found;
        }

        public void SearchAt(char[,] array, int i, int a, int columnDimension, int rowDimension, string build, int direction)
        {
            // Don't go past around array bounds.
            if (i >= columnDimension || i < 0 || a >= rowDimension || a < 0)
                return;
            
            // Get letter.
            var letter = array[a, i];
            // Append.
            var pass = build + letter;
            // See if full word.
            WordType value;
            if (_words.TryGetValue(pass, out value))
            {
                // Handle all full words.
                if (value == WordType.FullWord || value == WordType.FullWordAndPartialWord)
                {
                    // Don't display same word twice.
                    if (!_found.ContainsKey(pass))
                        _found.Add(pass, a + "" + i);
                }
                // Handle all partial words.
                if (value == WordType.PartialWord || value == WordType.FullWordAndPartialWord)
                {
                    // Continue in one direction.
                    switch (direction)
                    {
                        case 0:
                            SearchAt(array, i + 1, a, columnDimension, rowDimension, pass, direction);
                            break;
                        case 1:
                            SearchAt(array, i, a + 1, columnDimension, rowDimension, pass, direction);
                            break;
                        case 2:
                            SearchAt(array, i + 1, a + 1, columnDimension, rowDimension, pass, direction);
                            break;
                        case 3:
                            SearchAt(array, i - 1, a, columnDimension, rowDimension, pass, direction);
                            break;
                        case 4:
                            SearchAt(array, i, a - 1, columnDimension, rowDimension, pass, direction);
                            break;
                        case 5:
                            SearchAt(array, i - 1, a - 1, columnDimension, rowDimension, pass, direction);
                            break;
                        case 6:
                            SearchAt(array, i - 1, a + 1, columnDimension, rowDimension, pass, direction);
                            break;
                        case 7:
                            SearchAt(array, i + 1, a - 1, columnDimension, rowDimension, pass, direction);
                            break;
                    }
                }
            }
        }
    }
}