using HotelProject.WebUI.Dtos.GuestDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient(); //istemci oluşturduk
            var responseMessage = await client.GetAsync("http://localhost:23657/api/DashboardWidgets/StaffCount"); //bu adrese istekte bulunduk
            var jsonData = await responseMessage.Content.ReadAsStringAsync(); //Gelen veriyi jsonData adlı değişkene atadık
            ViewBag.staffCount = jsonData;

            var client2 = _httpClientFactory.CreateClient(); //istemci oluşturduk
            var responseMessage2 = await client2.GetAsync("http://localhost:23657/api/DashboardWidgets/BookingCount"); //bu adrese istekte bulunduk
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync(); //Gelen veriyi jsonData adlı değişkene atadık
            ViewBag.bookingCount = jsonData2;

            var client3 = _httpClientFactory.CreateClient(); //istemci oluşturduk
            var responseMessage3 = await client3.GetAsync("http://localhost:23657/api/DashboardWidgets/AppUserCount"); //bu adrese istekte bulunduk
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync(); //Gelen veriyi jsonData adlı değişkene atadık
            ViewBag.AppUserCount = jsonData3;

            var client4 = _httpClientFactory.CreateClient(); //istemci oluşturduk
            var responseMessage4 = await client4.GetAsync("http://localhost:23657/api/DashboardWidgets/RoomCount"); //bu adrese istekte bulunduk
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync(); //Gelen veriyi jsonData adlı değişkene atadık
            ViewBag.RoomCount = jsonData4;

            return View();
        }
    }
}
