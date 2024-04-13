namespace GameZone_KEMOO.Models
{
    public class Device : Base
    {
        [MaxLength(50)]
        public string IconName { get; set; }= string.Empty;
        //nav
        public ICollection<GameDevice>GameDevices { get; set; }= new List<GameDevice>();
    }
}
