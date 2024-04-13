namespace GameZone_KEMOO.Models
{
    public class GameDevice 
    {
        //pk => composit in fluentApi
        //fk
        public int GameId {  get; set; }
        public int DeviceId {  get; set; }
        //nav
        public Game Game { get; set; } = default!;
        public Device Device { get; set; } = default!;
    }
}
