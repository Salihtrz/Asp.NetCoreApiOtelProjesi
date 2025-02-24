using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.StaffDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class DashboardLast6Bookings : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardLast6Bookings(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient(); //istemci oluşturduk
            var responseMessage = await client.GetAsync("http://localhost:23657/api/Booking/Last6Booking"); //bu adrese istekte bulunduk
            if (responseMessage.IsSuccessStatusCode) //adresten başarılı durum kodu dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //Gelen veriyi jsonData adlı değişkene atadık
                var values = JsonConvert.DeserializeObject<List<ResultLast6BookingDto>>(jsonData); //json türündeki veriyi deserialize ederek normal forma döndürdük
                return View(values);
            }
            return View();
        }
    }
}
