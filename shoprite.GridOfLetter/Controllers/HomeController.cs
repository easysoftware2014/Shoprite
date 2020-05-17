using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Hosting;
using GridOfLetters.Domain.Entities;
using shoprite.GridOfLetter.Helpers;
using shoprite.GridOfLetter.Models;

namespace shoprite.GridOfLetter.Controllers
{
    public class HomeController : Controller
    {

        private readonly string _filePath = HostingEnvironment.MapPath(@"~/words.txt");
        private const int RowDimension = 5;
        private const int ColumnDimension = 5;

        public HomeController()
        {}
        public ActionResult Index()
        {

            var charArray = GetCharacterArray();
            TempData["Characters"] = charArray;
            var model = new FiveByFiveLetterModel(charArray) { WordsFound = new List<string>() };

            return View(model);
        }

        private char[,] GetCharacterArray()
        {
            var grid = new RandomCharacters();
            var data = grid.GetRandomChar(RowDimension, ColumnDimension);
            var charArray = new char[5, 5];
            var count = 0;

            for (var i = 0; i < RowDimension; i++)
            {
                for (var j = 0; j < ColumnDimension; j++)
                {
                    charArray[i, j] = data[count];
                    count++;
                }
            }

            return charArray;
        }
        public ActionResult SearchWordsFromFile()
        {
            var getTempData = (char[,]) TempData["Characters"] ?? GetCharacterArray() ;
            var searchClass = new RecursiveSearch();
            var wordsFound = searchClass.ReadFile(_filePath, getTempData, RowDimension, ColumnDimension);

            var entity = new GridLettersSearchResultsEntity
            {
                WordsFound = new List<string>()
            };

            if (wordsFound.Count > 0)
            {
                foreach (var word in wordsFound)
                {
                    var wordFound = word.Key;
                    var position = word.Value;

                    entity.WordsFound.Add($"{wordFound} found position {position}");
                }

                entity.CharacterList = getTempData;
            }
            
            var model = new FiveByFiveLetterModel(entity);

            if (wordsFound.Count == 0)
                model.NoMatchFound = "No Match found";

            return View("Index", model);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}