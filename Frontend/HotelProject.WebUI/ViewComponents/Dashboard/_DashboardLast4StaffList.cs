using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Dtos.StaffDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardLast4StaffList : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardLast4StaffList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient(); //istemci oluşturduk
            var responseMessage = await client.GetAsync("http://localhost:23657/api/Staff/Last4Staff"); //bu adrese istekte bulunduk
            if (responseMessage.IsSuccessStatusCode) //adresten başarılı durum kodu dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //Gelen veriyi jsonData adlı değişkene atadık
                var values = JsonConvert.DeserializeObject<List<ResultLast4StaffDto>>(jsonData); //json türündeki veriyi deserialize ederek normal forma döndürdük
                return View(values);
            }
            return View();
        }
    }
}
