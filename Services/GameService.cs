namespace GameZone_KEMOO.Services
{
    public class GameService : IGameService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment; //to use wwwroot (server storage)
        private readonly string _pathSaveImg;  // variable used may times
        public GameService(ApplicationDBContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
            _pathSaveImg = $"{_webHostEnvironment.WebRootPath}{FileSettings.ImgPathAfterRoot}";
        }

        public async Task Create(CreateGameFormViewModel SubmittedGame)
        {
            //var CoverNameInDB = $"{Guid.NewGuid()}{Path.GetExtension(SubmittedGame.Cover.FileName)}";
            ////save cover img to server
            //var pathToSaveImg = Path.Combine(_pathSaveImg, CoverNameInDB);

            //using var streamToSaveImg = File.Create(pathToSaveImg);
            //await SubmittedGame.Cover.CopyToAsync(streamToSaveImg);
            var savedCoverName = await SaveCover(SubmittedGame.Cover);

            //save game to database 
            Game gameToSend = new()
            {
                name = SubmittedGame.name,
                Description = SubmittedGame.Description,
                CoverName = savedCoverName,
                CategoryId = SubmittedGame.CategoryId,
                GameDevices = SubmittedGame.SelectedDevices.Select(s => new GameDevice { DeviceId = s }).ToList(),
            };
            _dbContext.Add(gameToSend);
            _dbContext.SaveChanges();
        }

        public Game? GetGameById(int _id)
        {
            return _dbContext.Games
                .Include(x => x.Category)
                .Include(x => x.GameDevices)
                .ThenInclude(x => x.Device)
                .AsNoTracking()
                .FirstOrDefault(x => x.id == _id);
        }
        public IEnumerable<Game> GetAllGames()
        {
            return _dbContext.Games
                .Include(g => g.Category)   /*eager loading*/
                .Include(gd => gd.GameDevices)
                .ThenInclude(d => d.Device)
                .AsNoTracking()
                .ToList();
        }

        public async Task<Game?> EditGame(EditGameFormViewModel model)
        {
            var gameToUpdate = _dbContext.Games
                .Include(x => x.GameDevices)
                .ThenInclude(x => x.Device)
                .SingleOrDefault(x => x.id == model.id);

            if (gameToUpdate is null)
                return null;

            var oldCover = gameToUpdate.CoverName;
            var hasNewCover = model.Cover is not null;

            gameToUpdate.name = model.name;
            gameToUpdate.Description = model.Description;
            gameToUpdate.CategoryId = model.CategoryId;
            gameToUpdate.GameDevices = model.SelectedDevices.Select(x => new GameDevice { DeviceId = x }).ToList();

            if (hasNewCover)
            {
                gameToUpdate.CoverName = await SaveCover(model.Cover!);
            }

            var EffectedRows = _dbContext.SaveChanges();
            if (EffectedRows > 0)
            {
                if (hasNewCover)
                {
                    if(oldCover is not null)
                    {
                        var oldCoverToDelete = Path.Combine(_pathSaveImg, oldCover);
                        File.Delete(oldCoverToDelete);
                    }
                }
                return gameToUpdate;
            }
            else
            {
                var newCoverToDelete = Path.Combine(_pathSaveImg, model.CurrentCoverName);
                File.Delete(newCoverToDelete);
                return null; //means the upated not completed => so deletd the new added coverImg   
            }
        }

        public bool Delete(int _id)
        {
            bool isDeleted = false;

            var foundGame = _dbContext.Games.Find(_id);

            if(foundGame is null)
               return false;

            _dbContext.Games.Remove(foundGame);
            //if the delete happen successfully => remove the img from server
            var effectedRows = _dbContext.SaveChanges();

            if(effectedRows > 0)
            {
                isDeleted = true;

                var coverToDelete = Path.Combine(_pathSaveImg,foundGame.CoverName);
                File.Delete(coverToDelete);
            }
            return isDeleted;
        }

        //dry==do not repeat yourself => so put repeated code in a method and use it 
        private async Task<string> SaveCover(IFormFile Cover)
        {
            var randomCoverName = $"{Guid.NewGuid()}{Path.GetExtension(Cover.FileName)}";
            var pathToSaveImgInServer = Path.Combine($"{_pathSaveImg}", randomCoverName);
            using var CreateNewFileStream = File.Create(pathToSaveImgInServer); //using is very imporatant to close the sream automatically and avoid resource leaks و ده اللي بيخلي الصورة مش بتظهر اول ما بتضاف بتظهر لما الابلكيشن لتاني مرة
            await Cover.CopyToAsync(CreateNewFileStream);
            return randomCoverName;
        }

    }
}
