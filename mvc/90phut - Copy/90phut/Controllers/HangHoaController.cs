using GoodsMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GoodsMVC.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HangHoaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

  
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7053/api/HangHoa"); 
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var goods = JsonSerializer.Deserialize<List<HangHoa>>(json);
                return View(goods);
            }
            return View(new List<HangHoa>());
        }
    }
}