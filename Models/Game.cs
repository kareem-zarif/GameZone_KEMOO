
namespace GameZone_KEMOO.Models
{
    public class Game : Base
    {
        [MaxLength(2500)]
        public string Description {  get; set; }=string.Empty;
        [MaxLength(500)]
        public string CoverName {  get; set; }=string.Empty ;
        //fk
        public int CategoryId { get; set; } 
        //nav
        public Category Category { get; set; } = default!;  //!=>Null-forgiving Operator used from .net 6
        public ICollection<GameDevice> GameDevices { get; set;} = new List<GameDevice>();

    }
}
