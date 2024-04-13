
namespace GameZone_KEMOO.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
             
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //composite key 
            modelBuilder.Entity<GameDevice>()
                .HasKey(x => new { x.GameId, x.DeviceId });

            //seeding
            modelBuilder.Entity<Category>()
                .HasData(new Category[]
                {
                    new Category{id=1, name="Action"},
                    new Category{id=2, name="Sports"},
                    new Category{id=3, name="Adventure"},
                    new Category{id=4, name="Racing"},
                    new Category{id=5, name="Fightening"},
                    new Category{id=6, name="Film"},
                });

            modelBuilder.Entity<Device>()
                .HasData(new Device[]
                {
                    new Device{ id=1, name="Playstation", IconName="bi bi-playstation"},
                    new Device{ id=2, name="Xbox", IconName="bi bi-xbox"},
                    new Device{ id=3, name="Nintdo Switch", IconName="bi bi-nintendo-switch"},
                    new Device{ id=4, name="PC", IconName="bi bi-pc"},
                });
        }

        public DbSet<GameDevice> GameDevices { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
