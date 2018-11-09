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
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace JarvisEF.WebAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(ConfigureSwaggerGen).AddMvc();
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c => ConfigureSwaggerUI(c));
        }

        private static void ConfigureSwaggerGen(SwaggerGenOptions options)
            => options.SwaggerDoc("api", new Info
            {
                Version = "α v0.1",
                Title = "MyBaby APIs",
                Description = "A simple example ASP.NET Core Web API",
                TermsOfService = "None",    // 약관
                Contact = new Contact { Name = "Noh Youngsun", Email = "youngsunkr@gmail.com", Url = "http://facebook.com/youngsunkr" },
                Extensions = { },
                //License = new License { Name = "Use under LICX", Url = "http://url.com" }
                License = new License { Name = "Use under LICX", Url = "http://www.trusteer.com/en/support/end-user-license-agreement" }


            });

        private static void ConfigureSwaggerUI(SwaggerUIOptions options)
            => options.SwaggerEndpoint("/swagger/api/swagger.json", "API");

    }
}
