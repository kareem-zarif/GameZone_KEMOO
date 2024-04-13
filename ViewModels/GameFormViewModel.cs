namespace GameZone_KEMOO.ViewModels
{
    public class GameFormViewModel
    {
        [MaxLength(250), DisplayName("Name")]
        public string name { get; set; } = string.Empty;
        [Display(Name = "Category")]
        public int CategoryId { get; set; } //receive int from user
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>(); //to call Categories from database to present in selectlist in thview
        [DisplayName("Supported Devices")]
        public List<int> SelectedDevices { get; set; } = default!;  //receive ints from user
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>(); //to call devices to present in view as SelectList
        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;
    }
}
