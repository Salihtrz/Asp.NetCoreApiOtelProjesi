using HotelProject.WebUI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofile/_salihtrz_"),
                Headers =
    {
        { "x-rapidapi-key", "4f35d0c40dmshb56e29babb44826p1d0467jsn646c39b8d64d" },
        { "x-rapidapi-host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ResultInstagramFollowersDto resultInstagramFollowersDto = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);
                ViewBag.followers = resultInstagramFollowersDto.followers;
                ViewBag.following = resultInstagramFollowersDto.following;
            }


            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://yt-api.p.rapidapi.com/channel/about?id=UCTti7j7ICoBS0_xV_OU7hxg"),
                Headers =
    {
        { "x-rapidapi-key", "4f35d0c40dmshb56e29babb44826p1d0467jsn646c39b8d64d" },
        { "x-rapidapi-host", "yt-api.p.rapidapi.com" },
    },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                ResultYoutubeFollowersDto resultYoutubeFollowersDto = JsonConvert.DeserializeObject<ResultYoutubeFollowersDto>(body2);
                ViewBag.subscriberCount = resultYoutubeFollowersDto.subscriberCount;
                ViewBag.title = resultYoutubeFollowersDto.title;

            }


            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Fsalih-terzi-a1b344237%2F&include_skills=false&include_certifications=false&include_publications=false&include_honors=false&include_volunteers=false&include_projects=false&include_patents=false&include_courses=false&include_organizations=false&include_profile_status=false&include_company_public_url=false"),
                Headers =
    {
        { "x-rapidapi-key", "4f35d0c40dmshb56e29babb44826p1d0467jsn646c39b8d64d" },
        { "x-rapidapi-host", "fresh-linkedin-profile-data.p.rapidapi.com" },
    },
            };
            using (var response3 = await client3.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body3 = await response3.Content.ReadAsStringAsync();
                ResultLinkedinFollowersDto resultLinkedinFollowersDto = JsonConvert.DeserializeObject<ResultLinkedinFollowersDto>(body3);
                ViewBag.followers_count = resultLinkedinFollowersDto.data.followers_count;
                ViewBag.connections_count = resultLinkedinFollowersDto.data.connections_count;
            }
            return View();
        }

    }
}
