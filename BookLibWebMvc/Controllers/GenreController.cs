using BookLibWebMvc.EntitiesDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace BookLibWebMvc.Controllers
{
    public class GenreController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public GenreController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            List<GenreDto> list = new List<GenreDto>();
            HttpClient httpClient = _httpClientFactory.CreateClient("BookLibApiClient");
            HttpResponseMessage response = await httpClient.GetAsync("/api/Genres");

            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<GenreDto>>(str);
                return View(list);
            }
            else
                return View(list);
        }

        public IActionResult Add()
        {
            GenreDto gDto = new GenreDto();
            return View(gDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GenreDto gDto)
        {
            try
            {
                var genreJson = JsonConvert.SerializeObject(gDto);
                HttpClient httpClient = _httpClientFactory.CreateClient("BookLibApiClient");
                StringContent content = new StringContent(genreJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync("/api/Genres", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Error", "There is an API error");
                    return View(gDto);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Caught exception : " + ex);
                //return "Error：" + e.Message;
                return View(gDto);
            }
        }

        public async Task<IActionResult> Update(int Id)
        {

            HttpClient httpClient = _httpClientFactory.CreateClient("BookLibApiClient");
            HttpResponseMessage response = await httpClient.GetAsync("/api/Genres/id?id=" + Id);

            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                GenreDto gDto = JsonConvert.DeserializeObject<GenreDto>(str);
                return View(gDto);

            }
            else
            {
                return RedirectToAction("Add");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(GenreDto gDto)
        {
            try 
            {
                var genreJson = JsonConvert.SerializeObject(gDto);
                HttpClient httpClient = _httpClientFactory.CreateClient("BookLibApiClient");
                StringContent content = new StringContent(genreJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PutAsync("/api/Genres", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Error", "There is an API error");
                    return View(gDto);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Caught exception : " + ex);
                //return "Error：" + e.Message;
                return View(gDto);
            }
        }

        public async Task<IActionResult> Delete(int Id)
        {

            HttpClient httpClient = _httpClientFactory.CreateClient("BookLibApiClient");
            HttpResponseMessage response = await httpClient.DeleteAsync("/api/Genres/" + Id);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
                

            }
            else
            {
                return View();
            }
        }

    }
}
