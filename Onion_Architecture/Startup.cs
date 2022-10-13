using Microsoft.EntityFrameworkCore;
using OA.Repo;
using OA.Service;
using System.Configuration;
using Microsoft.Extensions.Configuration;


namespace Onion_Architecture
{
    public class Startup
    {
        IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserProfileService, UserProfileService>();

            
        }
    }
}
