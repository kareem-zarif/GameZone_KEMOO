namespace GameZone_KEMOO.Services
{
    public class CategoriesService:ICategoriesService
    {
       private readonly ApplicationDBContext _context;

        public CategoriesService(ApplicationDBContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetCategories()
        {
           return _context.Categories.Select(c=>new SelectListItem { Value=c.id.ToString(), Text=c.name }).AsNoTracking().OrderBy(x=>x.Text);
        }

    }
}
