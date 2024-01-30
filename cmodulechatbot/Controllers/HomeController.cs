using cmodulechatbot.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Dynamic;

namespace cmodulechatbot.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string Baseurl = "http://localhost:3000/";
        private IndexViewModel IndexViewModel;
        private string ServicesList = "[{ 'name': 'Manicure - The Royal CBD','price': 60,'description': '','image': 'manicureImage' }, { 'name': 'Pedicure - The Royal CBD', 'price': 88, 'description': '', 'image': 'pedicureImage' }, { 'name': 'Eyelash extention - Fill','price': 60, 'description': '',image:'eyeLashImage' }, { 'name': 'Waxing - Eyebrows',  'price': 10,   'description': '','image': 'eyeBrowImage' }]";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<ActionResult> Index()
        {
         
            List<WeatherModel> weathers = new List<WeatherModel>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("WeatherForecast");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var weatherResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    IndexViewModel.setListWeather(JsonConvert.DeserializeObject<List<WeatherModel>>(weatherResponse));
                }
                //returning the employee list to view
                IndexViewModel.setListService(JsonConvert.DeserializeObject<List<ServiceModel>>(ServicesList));
                //IndexViewModel.setListService();
                return View(IndexViewModel);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}