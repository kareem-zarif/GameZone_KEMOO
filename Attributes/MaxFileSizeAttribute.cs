namespace GameZone_KEMOO.Attributes
{
    public class MaxFileSizeAttribute:ValidationAttribute
    {
        private readonly int _maxFileSizeInBytes;

        public MaxFileSizeAttribute(int maxFileSizeInBytes)
        {
            _maxFileSizeInBytes = maxFileSizeInBytes;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var comingFile = value as IFormFile;
            if (comingFile != null)
            {
                if (comingFile.Length>_maxFileSizeInBytes)
                {
                    return new ValidationResult($"Your File Size :{comingFile.Length/1024} KB is More Than Allowed : {_maxFileSizeInBytes/1024} KB");
                }
            }
            return ValidationResult.Success;
        }
    }
}
