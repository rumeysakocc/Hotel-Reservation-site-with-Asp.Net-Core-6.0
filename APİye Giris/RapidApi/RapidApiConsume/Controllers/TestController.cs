using HotelProject.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RapidApiConsume.Controllers
{
    [AllowAnonymous]
    public class TestController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/idenfitcom"),
                Headers =
    {
        { "X-RapidAPI-Key", "490578ef41msh3240f65332bd56cp1b2f30jsna52ece847c21" },
        { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                InstagramFollowersViewModel viewModel = JsonConvert.DeserializeObject<InstagramFollowersViewModel>(body);
                return View(viewModel);
            }
            
        }
    }
}
