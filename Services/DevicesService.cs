namespace GameZone_KEMOO.Services
{
    public class DevicesService:IDevicesService
    {
        private readonly ApplicationDBContext _dbContext;

        public DevicesService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<SelectListItem> GetDevices()
        {
            //projection => change type of reterfed data from DB using select 
            return _dbContext.Devices.Select(d=>new SelectListItem { Value=d.id.ToString(), Text=d.name }).AsNoTracking().OrderBy(x=>x.Text);
        }

    }
}
