using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using NoteBusinessLibrary;

namespace MyNoteWebAPI
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
            var constr = Configuration.GetConnectionString("notedb");
            services.AddDbContext<NoteDbContext>(options => options.UseSqlServer(constr,b=>b.MigrationsAssembly("MyNoteWebAPI")));
            services.AddScoped<NoteDbContext>();
            services.AddScoped<IMyNoteHandler, MyNoteHandler>();
            services.AddScoped<IMyNoteService, MyNoteService>();
            services.AddScoped<IMyLabelHandler, MyLabelHandler>();
            services.AddScoped<IMyLabelService, MyLabelService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
