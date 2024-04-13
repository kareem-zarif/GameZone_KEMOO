using System.Threading.Tasks;

namespace GameZone_KEMOO.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IDevicesService _devicesService;
        private readonly IGameService _gameService;

        public GamesController(ICategoriesService categoriesService, IDevicesService devicesService, IGameService gameService)
        {
            _categoriesService = categoriesService;
            _devicesService = devicesService;
            _gameService = gameService;
        }

        public IActionResult Index()
        {
            var comGames = _gameService.GetAllGames();
            return View(comGames);
        }

        public IActionResult Details(int id)
        {
            var GameById = _gameService.GetGameById(id);
            if (GameById is null)
            {
                return NotFound();
            }
            return View(GameById);
        }

        [HttpGet] //get =>  is the default http action  
        public IActionResult Create()
        {
            CreateGameFormViewModel viewModel = new()
            {
                Categories = _categoriesService.GetCategories(),

                Devices = _devicesService.GetDevices(),
            };
            //link viewModel to its Controller
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // a hidden token not saved in cookies but embedded as hidden in view => a safety layer sothat if attakers steal your cookies ,they still unable reach your applcation
        public async Task<IActionResult> Create(CreateGameFormViewModel model)
        {
            //serverSide Validation 
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesService.GetCategories();
                model.Devices = _devicesService.GetDevices();
                //link viewModel to its Controller
                return View(model);
            }
            //save the game in database+save the cover img in server (wwwroot)
            await _gameService.Create(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var foundGame = _gameService.GetGameById(id);
            if (foundGame is null)
            {
                return NotFound();
            }

            EditGameFormViewModel editViewModel = new()
            {
                id = foundGame.id,
                name = foundGame.name,
                Description = foundGame.Description,
                CategoryId = foundGame.CategoryId,
                SelectedDevices = foundGame.GameDevices.Select(x => x.DeviceId).ToList(),
                Categories = _categoriesService.GetCategories(),
                Devices = _devicesService.GetDevices(),
                CurrentCoverName = foundGame.CoverName,
            };

            return View(editViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesService.GetCategories();
                model.Devices = _devicesService.GetDevices();
                return View(model);
            }

            var updatedGame = await _gameService.EditGame(model);
            if (updatedGame is null)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isDel = _gameService.Delete(id);
            return isDel ? Ok() : BadRequest(); // as i will use ajax
        }
    }
}
