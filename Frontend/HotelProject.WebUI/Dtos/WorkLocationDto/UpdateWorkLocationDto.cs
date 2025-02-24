using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebUI.Dtos.WorkLocationDto
{
    public class UpdateWorkLocationDto
    {
        public int WorkLocationID { get; set; }
        public string WorkLocationCity { get; set; }
        public string WorkLocationName { get; set; }
    }
}
