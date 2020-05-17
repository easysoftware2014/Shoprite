using System.Linq;
using System.Web.Mvc;
using System.IO;
using System.Web.Hosting;
using shoprite.GridOfLetter.Helpers;
using shoprite.GridOfLetter.Models;

namespace shoprite.GridOfLetter.Controllers
{
    public class HomeController : Controller
    {

        private readonly string _filePath = HostingEnvironment.MapPath(@"~/words.txt");
        public HomeController()
        {
            
        }
        public ActionResult Index()
        {
            var grid = new BuildFiveByFiveGrid();
            var data = grid.BuildFiveByFiveLetterGrid(5, 5);
            var charArray = new char[5, 5];
            var count = 0;

            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    charArray[i, j] = data[count];
                    count++;
                }
            }

            TempData["Characters"] = charArray;
            var model = new FiveByFiveLetterModel(charArray);
            
            return View(model);
        }

        public ActionResult SearchWordsFromFile()
        {
            var getTempData = (char[,]) TempData["Characters"] ;
            
            if (System.IO.File.Exists(_filePath))
            {
                var text = System.IO.File.ReadAllLines(_filePath);

                foreach (var item in text)
                {
                    var check = RecursiveSearch.Search(getTempData, item);
                }
            }
            return View(" ");
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