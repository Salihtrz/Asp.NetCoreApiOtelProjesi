using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AppUserDto;
using HotelProject.WebUI.Dtos.RoomDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    public class AdminUsersController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminUsersController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            //var client = _httpClientFactory.CreateClient(); //istemci oluşturduk
            //var responseMessage = await client.GetAsync("http://localhost:23657/api/AppUser"); //bu adrese istekte bulunduk
            //if (responseMessage.IsSuccessStatusCode) //adresten başarılı durum kodu dönerse
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync(); //Gelen veriyi jsonData adlı değişkene atadık
            //    var values = JsonConvert.DeserializeObject<List<ResultAppUserDto>>(jsonData); //json türündeki veriyi deserialize ederek normal forma döndürdük
            //    return View(values);
            //}
            return View();
        }
        public async Task<IActionResult> UserList()
        {
            var client = _httpClientFactory.CreateClient(); //istemci oluşturduk
            var responseMessage = await client.GetAsync("http://localhost:23657/api/AppUser"); //bu adrese istekte bulunduk
            if (responseMessage.IsSuccessStatusCode) //adresten başarılı durum kodu dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //Gelen veriyi jsonData adlı değişkene atadık
                var values = JsonConvert.DeserializeObject<List<ResultAppUserListDto>>(jsonData); //json türündeki veriyi deserialize ederek normal forma döndürdük
                return View(values);
            }
            return View();
        }
    }
}
