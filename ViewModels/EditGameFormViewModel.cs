namespace GameZone_KEMOO.ViewModels
{
    public class EditGameFormViewModel:GameFormViewModel
    {
        public  int id {  get; set; } 

        //add currentCoverName Property => to receive the returned CoverName from DB => then map the IFormFile you want 
        public string? CurrentCoverName { get; set; }

        [AllowedExtensions(FileSettings.AllowedExyensions), MaxFileSize(FileSettings.MaxFileSizeinByte)]
        public IFormFile? Cover { get; set; } = default!; //the cover here is not mandatory =>as user may not change the cover he used
    }
}
