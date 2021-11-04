using EmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();  // - old way
            //services.AddMvcCore(options => options.EnableEndpointRouting = false);
            services.AddMvc(options => options.EnableEndpointRouting = false).AddXmlSerializerFormatters(); // new way // .AddXmlSerializerFormatters()  allows to return a response that's in XML format

            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();  // dependency injection


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
                            //    ,ILogger<Startup> logger)
        {


            //DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            //defaultFilesOptions.DefaultFileNames.Clear();
            //defaultFilesOptions.DefaultFileNames.Add("foo2.html");
            //app.UseDefaultFiles(defaultFilesOptions);


            //FileServerOptions fileServerOptions = new FileServerOptions();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("foo.html");
            //app.UseFileServer(fileServerOptions);



            //env.IsProduction()
            //env.IsStaging()
            //env.IsEnvironment("Customized Environment Name")


            if (env.IsDevelopment())
            {
                //DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions
                //{
                //    SourceCodeLineCount = 20
                //};

                //app.UseDeveloperExceptionPage(developerExceptionPageOptions);

                app.UseDeveloperExceptionPage();
            }

            //app.UseFileServer();

            //app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();


            //app.Run(async context =>
            //{
            //    //throw new Exception("Some error passing the request.");
            //    await context.Response.WriteAsync("Hello World!");
            //    //logger.LogInformation("MW2: Request handled and response produced.");

            //});





            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

        }
    }
}
