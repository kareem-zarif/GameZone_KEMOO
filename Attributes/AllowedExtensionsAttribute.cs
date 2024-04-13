namespace GameZone_KEMOO.Attributes
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        //injection of coming extension => to prevent any accedantly change in it
        private readonly string _allowedExtensions;

        public AllowedExtensionsAttribute(string allowedExtensions)
        {
            _allowedExtensions = allowedExtensions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var comingFile = value as IFormFile; // instead of change the base method parameter
            if (comingFile is not null)
            {
                var comingExtension = Path.GetExtension(comingFile.FileName);
                bool isAllowedExtension = _allowedExtensions.Split(',').Contains(comingExtension, StringComparer.OrdinalIgnoreCase);
                if (!isAllowedExtension)
                {
                    return new ValidationResult($" {comingExtension} Not Allowd");
                }
            }

            return ValidationResult.Success;
        }
    }
}
