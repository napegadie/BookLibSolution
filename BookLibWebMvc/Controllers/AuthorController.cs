using BookLibWebMvc.EntitiesDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace BookLibWebMvc.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthorController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            List<AuthorDto> list = new List<AuthorDto>();
            HttpClient httpClient = _httpClientFactory.CreateClient("BookLibApiClient");
            HttpResponseMessage response = await httpClient.GetAsync("/api/Authors");

            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<AuthorDto>>(str);
                return View(list);
            }
            else
                return View(list);
        }

        public async Task<IActionResult> Index(string searchString)
        {

            HttpClient httpClient = _httpClientFactory.CreateClient("BookLibApiClient");
            HttpResponseMessage response = await httpClient.GetAsync("/api/Authors/id?id=" + searchString);

            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                AuthorDto aDto = JsonConvert.DeserializeObject<AuthorDto>(str);
                return View(aDto);

            }

            return View();

        }

        public IActionResult Add()
        {
            AuthorDto aDto = new AuthorDto();
            return View(aDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AuthorDto aDto)
        {
            try
            {
                var authorJson = JsonConvert.SerializeObject(aDto);
                HttpClient httpClient = _httpClientFactory.CreateClient("BookLibApiClient");
                StringContent content = new StringContent(authorJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync("/api/Authors", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Error", "There is an API error");
                    return View(aDto);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Caught exception : " + ex);
                //return "Error：" + e.Message;
                return View(aDto);
            }
        }

        public async Task<IActionResult> Update(int Id)
        {

            HttpClient httpClient = _httpClientFactory.CreateClient("BookLibApiClient");
            HttpResponseMessage response = await httpClient.GetAsync("/api/Authors/id?id=" + Id);

            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                AuthorDto aDto = JsonConvert.DeserializeObject<AuthorDto>(str);
                return View(aDto);

            }
            else
            {
                return RedirectToAction("Add");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(AuthorDto aDto)
        {
            try
            {
                var authorJson = JsonConvert.SerializeObject(aDto);
                HttpClient httpClient = _httpClientFactory.CreateClient("BookLibApiClient");
                StringContent content = new StringContent(authorJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PutAsync("/api/Authors", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Error", "There is an API error");
                    return View(aDto);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Caught exception : " + ex);
                return View(aDto);
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
