using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMyServise myServise;

        public HomeController(IMyServise myServise)
        {
            this.myServise = myServise;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FirstExercise()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FirstExercise(List<string> requestItems)
        {
            Request request = new Request(ExerciseType.First, requestItems);
            Response response = myServise.ExecuteExercise(request);
            return View((object)response);
        }

        [HttpGet]
        public IActionResult SecondExercise()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SecondExercise(List<string> requestItems)
        {
            Request request = new Request(ExerciseType.Second, requestItems);
            Response response = myServise.ExecuteExercise(request);
            return View((object)response);
        }

        [HttpGet]
        public IActionResult ThirdExercise()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ThirdExercise(List<string> requestItems)
        {
            Request request = new Request(ExerciseType.Third, requestItems);
            Response response = myServise.ExecuteExercise(request);
            return View((object)response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}