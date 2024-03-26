using ApiLibrary.ViewModels;

namespace WebApplicationApp.Models
{
    public class ListLocation
    {
        public ListLocationVM? Listlocations { get; set; }
        public List<ListLocationVM>? Location { get; set; }
        public List<AreaViewModel>? Area { get; set; }
      
    }
}
