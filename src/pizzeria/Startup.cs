using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using pizzeria.utils;
using pizzeria.Application;
using pizzeria.Infraestructure;
using Microsoft.EntityFrameworkCore;
using System;

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

            var userService = new ServiceDescriptor(typeof(IUserService), typeof(UserService), ServiceLifetime.Scoped);
            services.Add(userService);
            var userRepository = new ServiceDescriptor(typeof(IUserRepository), typeof(PizzeriaContext), ServiceLifetime.Scoped);
            services.Add(userRepository);
            var ingredientService = new ServiceDescriptor(typeof(IIngredientService), typeof(IngrdientService), ServiceLifetime.Scoped);
            services.Add(ingredientService);
            var ingredientRepository = new ServiceDescriptor(typeof(IIngredientRepository), typeof(PizzeriaContext), ServiceLifetime.Scoped);
            services.Add(ingredientRepository);
            var pizzeriaService = new ServiceDescriptor(typeof(IPizzeriaService), typeof(PizzeriaService), ServiceLifetime.Scoped);
            services.Add(pizzeriaService);
            var uploadRepository = new ServiceDescriptor(typeof(IPizzeriaRepository), typeof(PizzeriaContext), ServiceLifetime.Scoped);
            services.Add(uploadRepository);
            var streamService = new ServiceDescriptor(typeof(IStreamService), typeof(StreamService), ServiceLifetime.Scoped);
            services.Add(streamService);
            var tempImageRepository = new ServiceDescriptor(typeof(ITempImageRepository), typeof(TempImageRepository), ServiceLifetime.Scoped);
            services.Add(tempImageRepository);
            var imageServerRepository = new ServiceDescriptor(typeof(IImageServerRepository), typeof(ImageServerRepository), ServiceLifetime.Scoped);
            services.Add(imageServerRepository);

            services.AddMvc()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                });
            services.AddHttpClient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<PizzeriaContext>();
                Console.WriteLine("Se conectó a la base de datos: {0}",context.Database.CanConnect());  
                context.Database.EnsureDeleted();
                context.Database.Migrate();
                Console.WriteLine("La migración se realizó correctamente: {0}",context.Database.EnsureCreated());
            }
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
