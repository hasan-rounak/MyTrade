using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyTrade.Business.Query;
using MyTrade.Common.Interfaces;
using MyTrade.Helper.Extensions;
using MyTrade.Infra;
using System.IO.Compression;
using Microsoft.AspNetCore.OData.Extensions;

namespace MyTrade.API
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
            // Brotli compression
            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<BrotliCompressionProvider>();
            });
#pragma warning disable ASP0000 // Do not call 'IServiceCollection.BuildServiceProvider' in 'ConfigureServices'
            //var serviceProvider = services.BuildServiceProvider();
#pragma warning restore ASP0000 // Do not call 'IServiceCollection.BuildServiceProvider' in 'ConfigureServices'
            //serviceProvider.GetService<AuthService>().AddAuthentication(ref services);

            services.AddHealthChecks();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyTrade.API", Version = "v1" });
            });
            services.AddMediatR(typeof(GetTradeQuery).Assembly).AddAutomapperConfiguration();

            services.AddScoped<ITradeRepository, TradeRepository>();
            //services.Configure<ApiBehaviorOptions>
            //(
            //    options => options.InvalidModelStateResponseFactory = context =>
            //    {
            //        List<string> errors = context.ModelState
            //                                     .Values
            //                                     .SelectMany(modelStateEntry => modelStateEntry.Errors.Select(error => error.ErrorMessage))
            //                                     .ToList();

            //        return new BadRequestObjectResult
            //        (
            //            new ValidationError("One or more validation errors occurred", errors)
            //        );
            //    }
            //);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyTrade.API v1"));
            }

            app.UseResponseCompression()
                //.UseGlobalExceptionHandler()
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
