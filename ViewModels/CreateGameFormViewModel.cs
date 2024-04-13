namespace GameZone_KEMOO.ViewModels
{
    //viewModel => between view and model => check iput from view and sent to controller + receive response from controller and sent to view
    public class CreateGameFormViewModel : GameFormViewModel
    {//id not nedded => user not input it
        [AllowedExtensions(FileSettings.AllowedExyensions),MaxFileSize(FileSettings.MaxFileSizeinByte)]
        public IFormFile Cover { get; set; } = default!; //receive img from user

        //validate Extension and size
        //[Extension] => this attrubite good for validate Exyension in webApi => make problems in client side validation in mvc
        //so i will add custom validate Attribute
    }
}
