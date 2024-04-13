using System.ComponentModel.DataAnnotations;

namespace GameZone_KEMOO.Models
{
    public class Base
    {
        public int id {  get; set; }
        [MaxLength(250)]
        public string name {  get; set; }=string.Empty;
    }
}
