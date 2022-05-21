using BookLibWebMvc.EntitiesDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace BookLibWebMvc.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        //DropDownDto ddDto = new DropDownDto();

        public BookController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            List<BookDto> list = new List<BookDto>();
            HttpClient httpClient = _httpClientFactory.CreateClient("BookLibApiClient");
            HttpResponseMessage response = await httpClient.GetAsync("/api/Books");

            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<BookDto>>(str);
                return View(list);
            }
            else
                return View(list);
        }

        public async Task<IActionResult> Add()
        {
            DropDownDto ddDto = new DropDownDto();
            HttpClient httpClient = _httpClientFactory.CreateClient("BookLibApiClient");
            HttpResponseMessage response = await httpClient.GetAsync("/api/Books/GetCreateDDown");

            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                ddDto = JsonConvert.DeserializeObject<DropDownDto>(str);

                ViewBag.Genres = new SelectList(ddDto.Genres, "GenreId", "GenreName");
                ViewBag.Authors = new SelectList(ddDto.Authors, "AuthorId", "FirstName");
                ViewBag.Publishers = new SelectList(ddDto.Publishers, "PublisherId", "Name");
            }

            BookDto bDto = new BookDto();
            return View(bDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(BookDto bDto)
        {
            try
            {
                var bookJson = JsonConvert.SerializeObject(bDto);
                HttpClient httpClient = _httpClientFactory.CreateClient("BookLibApiClient");
                StringContent content = new StringContent(bookJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync("/api/Books", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Error", "There is an API error");
                    return View(bDto);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Caught exception : " + ex);
                return View(bDto);
            }
        }

        public async Task<IActionResult> Update(int Id)
        {
            DropDownDto ddDto = new DropDownDto();
            HttpClient httpClient = _httpClientFactory.CreateClient("BookLibApiClient");

            // Get Drop Down datas
            HttpResponseMessage respDDown = await httpClient.GetAsync("/api/Books/GetCreateDDown");

            if (respDDown.IsSuccessStatusCode)
            {
                var str = await respDDown.Content.ReadAsStringAsync();
                ddDto = JsonConvert.DeserializeObject<DropDownDto>(str);

                ViewBag.Genres = new SelectList(ddDto.Genres, "GenreId", "GenreName");
                ViewBag.Authors = new SelectList(ddDto.Authors, "AuthorId", "FirstName");
                ViewBag.Publishers = new SelectList(ddDto.Publishers, "PublisherId", "Name");
            }

            // Get the book to update.
            HttpResponseMessage response = await httpClient.GetAsync("/api/Books/id?id=" + Id);

            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                BookDto bDto = JsonConvert.DeserializeObject<BookDto>(str);
                return View(bDto);

            }
            else
            {
                return RedirectToAction("Add");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(BookDto bDto)
        {
            try
            {
                var bookJson = JsonConvert.SerializeObject(bDto);
                HttpClient httpClient = _httpClientFactory.CreateClient("BookLibApiClient");
                StringContent content = new StringContent(bookJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PutAsync("/api/Books", content);
                //HttpResponseMessage response = await httpClient.PutAsync("/api/Authors", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Error", "There is an API error");
                    return View(bDto);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Caught exception : " + ex);
                return View(bDto);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Id)
        {

            HttpClient httpClient = _httpClientFactory.CreateClient("BookLibApiClient");
            HttpResponseMessage response = await httpClient.DeleteAsync("/api/Books/" + Id);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");


            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
