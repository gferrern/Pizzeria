using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using pizzeria.Application;
using pizzeria.Infraestructure;
using Microsoft.EntityFrameworkCore;
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
            //services.Add(new ServiceDescriptor())
            var userService = new ServiceDescriptor(typeof(IUserService), typeof(UserService), ServiceLifetime.Scoped); 
            services.Add(userService);
            var userRepository = new ServiceDescriptor(typeof(IUserRepository),typeof(PizzeriaContext),ServiceLifetime.Scoped);
            services.Add(userRepository);
            //var uploadService = new ServiceDescriptor(typeof(IUploadRepository), typeof(UploadContext), ServiceLifetime.Scoped); 
            //services.Add(uploadService);
            services.AddMvc()
                .ConfigureApiBehaviorOptions(options =>{
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
