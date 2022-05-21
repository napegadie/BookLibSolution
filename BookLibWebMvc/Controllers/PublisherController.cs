using BookLibWebMvc.EntitiesDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace BookLibWebMvc.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public PublisherController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            List<PublisherDto> list = new List<PublisherDto>();
            HttpClient httpClient = _httpClientFactory.CreateClient("BookLibApiClient");
            HttpResponseMessage response = await httpClient.GetAsync("/api/Publishers");

            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<PublisherDto>>(str);
                return View(list);
            }
            else
                return View(list);
        }

        public IActionResult Add()
        {
            PublisherDto pDto = new PublisherDto();
            return View(pDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PublisherDto pDto)
        {
            try
            {
                var publisherJson = JsonConvert.SerializeObject(pDto);
                HttpClient httpClient = _httpClientFactory.CreateClient("BookLibApiClient");
                StringContent content = new StringContent(publisherJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync("/api/Publishers", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Error", "There is an API error");
                    return View(pDto);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Caught exception : " + ex);
                //return "Error：" + e.Message;
                return View(pDto);
            }
        }

        public async Task<IActionResult> Update(int Id)
        {

            HttpClient httpClient = _httpClientFactory.CreateClient("BookLibApiClient");
            HttpResponseMessage response = await httpClient.GetAsync("/api/Publishers/id?id=" + Id);

            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                PublisherDto pDto = JsonConvert.DeserializeObject<PublisherDto>(str);
                return View(pDto);

            }
            else
            {
                return RedirectToAction("Add");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(PublisherDto pDto)
        {
            try
            {
                var publisherJson = JsonConvert.SerializeObject(pDto);
                HttpClient httpClient = _httpClientFactory.CreateClient("BookLibApiClient");
                StringContent content = new StringContent(publisherJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PutAsync("/api/Publishers", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Error", "There is an API error");
                    return View(pDto);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Caught exception : " + ex);
                //return "Error：" + e.Message;
                return View(pDto);
            }
        }

        public async Task<IActionResult> DeletePublisher(int Id)
        {

            HttpClient httpClient = _httpClientFactory.CreateClient("BookLibApiClient");
            HttpResponseMessage response = await httpClient.DeleteAsync("/api/Publishers/" + Id);

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
