using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CisEng.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CisEng
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration,IHostingEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
        }
      
        public IConfiguration Configuration { get; }

        private readonly IHostingEnvironment _environment;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("allowcors",
                builder =>
                {
                    builder.WithOrigins().AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
            services.AddDbContext<AppDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("BlogDBConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            var folderName = Path.Combine(_environment.WebRootPath, "upload");
            app.UseHttpsRedirection();
            
            app.UseStaticFiles();
            app.UseCors("allowcors");
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), folderName)),
                RequestPath = new PathString("/"+this._environment.WebRootPath)
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
           
            
        }
    }
}
