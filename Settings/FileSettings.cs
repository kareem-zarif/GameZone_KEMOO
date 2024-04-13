namespace GameZone_KEMOO.Settings
{
    public  static class FileSettings
    {
        public const string ImgPathAfterRoot = "/assests/imgs/games";
        public const string AllowedExyensions = ".jpg,.jpeg,.png";
        public const float MaxFileSizeInMBs = 2;
        public const int MaxFileSizeinKiloByte = (int)MaxFileSizeInMBs * 1024;
        public const int MaxFileSizeinByte = (int)MaxFileSizeInMBs * 1024*1024;
    }
}
