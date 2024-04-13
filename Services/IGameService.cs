namespace GameZone_KEMOO.Services
{
    public interface IGameService
    {
        public  Task Create(CreateGameFormViewModel SubmittedGame);
        IEnumerable<Game> GetAllGames();
        public Game? GetGameById(int _id);
        public  Task<Game> EditGame(EditGameFormViewModel model);
        //private  Task<string> SaveCover(IFormFile Cover);
        public bool Delete(int _id);
    }
}
