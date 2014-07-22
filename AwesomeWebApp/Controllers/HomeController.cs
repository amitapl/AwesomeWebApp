using System;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AwesomeWebApp.Controllers
{
    public class HomeController : Controller
    {
        private static readonly Randomizer _randomizer = new Randomizer();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProduceError(int errorCode)
        {
            throw new HttpException(errorCode, "Error");
        }

        public JsonResult ProduceLogs()
        {
            string name = _randomizer.GetRandomName();
            Trace.WriteLine("This is a verbose line for " + name);
            Trace.TraceInformation("This is an information line for \"{0}\"", name);
            return null;
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private class Randomizer
        {
            private static readonly string[] Animals = { "Bear", "Lion", "Tiger", "Parrot", "Dog", "Cat", "Rabbit", "Dolphin", "Whale", "Giraffe", "Zebra" };
            private static readonly string[] Adjectives = { "Big", "Tired", "Fearsome", "Giant", "Small", "Smelly", "Cute", "Good", "Aging", "Fancy", "White" };

            private readonly Random _random = new Random();

            public string GetRandomName()
            {
                return GetRandomItem(Adjectives) + " " + GetRandomItem(Animals);
            }

            private string GetRandomItem(string[] items)
            {
                int index = _random.Next(items.Length);
                return items[index];
            }
        }
    }
}