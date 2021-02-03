using Application.Configuration.Data;
using Domain.Core;
using Domain.UserProfiles;
using Infrastucture.Core;
using Infrastucture.Database;
using Infrastucture.Domain;
using Infrastucture.Domain.UserProfiles;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdBoard
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
            services.AddAuthentication().AddFacebook(options =>
            {
                options.AppId = Configuration["Authentication:Facebook:AppId"];
                options.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                options.AccessDeniedPath = "/AccessDeniedPathInfo";
                options.Fields.Add("first_name");
                options.Fields.Add("last_name");
                options.Fields.Add("picture");
                options.Fields.Add("email");
                options.Events = new OAuthEvents
                {
                    OnCreatingTicket = context =>
                    {
                        var picture = context.User.GetProperty("picture").GetProperty("data").GetProperty("url").GetString();

                        context.Properties.Items.Add("picture", picture);
                        return Task.CompletedTask;
                    }
                };
            });


            var connectionString = Configuration.GetConnectionString("AdBoardContextConnection");

            services.AddDbContext<AdBoardDbContext>(options => {
                options.UseSqlServer(connectionString);
                options.ReplaceService<IValueConverterSelector, StronglyTypedIdValueObjectConverterSelector>();
            });
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<AdBoardDbContext>();


            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSingleton<ISqlConnectionFactory>(new SqlConnectionFactory(connectionString));
            services.AddMediatR(typeof(ISqlConnectionFactory).Assembly);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
