using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using pizzeria.utils;
using pizzeria.Application;
using pizzeria.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.StackExchangeRedis;

namespace pizzeria
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<PizzeriaContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("PizzeriaContext")));

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration.GetConnectionString("redisConfiguration");
                options.InstanceName = Configuration.GetConnectionString("redisInstance");;
            });

            var userService = new ServiceDescriptor(typeof(IUserService), typeof(UserService), ServiceLifetime.Scoped);
            services.Add(userService);
            var userRepository = new ServiceDescriptor(typeof(IUserRepository), typeof(PizzeriaContext), ServiceLifetime.Scoped);
            services.Add(userRepository);
            var ingredientService = new ServiceDescriptor(typeof(IIngredientService), typeof(IngrdientService), ServiceLifetime.Scoped);
            services.Add(ingredientService);
            var ingredientRepository = new ServiceDescriptor(typeof(IIngredientRepository), typeof(PizzeriaContext), ServiceLifetime.Scoped);
            services.Add(ingredientRepository);           
            var uploadService = new ServiceDescriptor(typeof(IPizzeriaService), typeof(PizzeriaService), ServiceLifetime.Scoped);
            services.Add(uploadService);
            var uploadRepository = new ServiceDescriptor(typeof(IPizzeriaRepository), typeof(PizzeriaContext), ServiceLifetime.Scoped);            
            services.Add(uploadRepository);
            var streamService = new ServiceDescriptor(typeof(IStreamService),typeof(StreamService),ServiceLifetime.Scoped);
            services.Add(streamService);
            services.AddMvc()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
