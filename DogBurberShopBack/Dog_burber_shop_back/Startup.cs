using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using DAL;
using BLL;

namespace Dog_burber_shop_back
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dog_burber_shop_back", Version = "v1" });
            });
            services.AddDbContext<Dogs_burber_shopContext>(options => options.UseSqlServer(Configuration.GetSection("ConnectionStrings")["DefultConnection"]));
            services.AddScoped<ICustomerDAL, CustomerDAL>();
            services.AddScoped<IQueueDAL, QueueDAL>();
            services.AddScoped<ICustomerBLL, CustomerBLL>();
            services.AddScoped<IQueueBLL, QueueBLL>();
            services.AddCors(options =>
            {
                options.AddPolicy("Cors",
                    b =>
                    b.WithOrigins(Configuration.GetSection("Cors").Value)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    );
            });

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dog_burber_shop_back v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("Cors");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
           app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            }); 
        }
    }
}
