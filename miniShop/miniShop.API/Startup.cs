using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using miniShop.Business;
using miniShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniShop.API
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "miniShop.API", Version = "v1" });
            });


            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, FakeUserService>();
            var connectionString = Configuration.GetConnectionString("db");
            services.AddDbContext<MiniShopDbContext>(option => option.UseSqlServer(connectionString));
            services.AddAutoMapper(typeof(RequestMappingProfile));

            services.AddCors(opt => opt.AddPolicy("allow", policyBuilder =>
            {
                policyBuilder.AllowAnyHeader();
                policyBuilder.AllowAnyMethod();
                policyBuilder.AllowAnyOrigin();

            }));


            var bearer = new Bearer();
            //var issuer = Configuration.GetSection("Bearer")["Issuer"];
            Configuration.GetSection("Bearer").Bind(bearer);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(option =>
                    {
                        //gelen request nasıl onaylanacak?
                        option.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateActor = true,
                            ValidateAudience = true,
                            ValidateIssuer = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = bearer.Issuer,
                            ValidAudience = bearer.Auidence,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(bearer.SecurityKey))

                        };
                    });

            services.AddHealthChecks();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //app.Run(async (ctx) =>
            //{
            //    await ctx.Response.WriteAsync("Talep sunucuya ulaştı");

            //});
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "miniShop.API v1"));
            }

            app.UseHealthChecks("/check");
          

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("allow");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<BadWordsCheckMiddleware>();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
