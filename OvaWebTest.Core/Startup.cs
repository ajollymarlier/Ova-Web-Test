using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OvaWebTest.Application;
using OvaWebTest.Domain;
using OvaWebTest.Persistence.InMemory;
using Microsoft.AspNetCore.Cors;
using OvaWebTest.Persistence;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System;

namespace OvaWebTest
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            InjectApplicationDependencies(services);
            InjectInfraDependencies(services);

            services.AddIdentityCore<User>();
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 0;

                // User settings
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            services.AddSwaggerGen();
            //services cors
            services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            services.Configure<UserDatabaseSettings>((settings) =>
            {
                settings.UserCollectionName = "Users";
                settings.ConnectionString = "mongodb+srv://arunjm00:NqiQGs90I8nBvfBp@cluster0.qwbr7xp.mongodb.net/?retryWrites=true&w=majority";
                settings.DatabaseName = "UserDatabase";
            });
        }

        private void InjectApplicationDependencies(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }

        private void InjectInfraDependencies(IServiceCollection services)
        {
            services.AddSingleton<IUserStore<User>, UserRepository>();

            services.AddScoped<UserDatabaseManager, UserDatabaseManager>();

            services.AddSingleton<IUserDatabaseSettings>(sp => 
                sp.GetRequiredService<IOptions<UserDatabaseSettings>>().Value);

            services.AddSingleton<IMongoClient>(s => 
            new MongoClient("mongodb+srv://arunjm00:NqiQGs90I8nBvfBp@cluster0.qwbr7xp.mongodb.net/?retryWrites=true&w=majority"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "OvaWebTest v1.0.0");
                    c.RoutePrefix = string.Empty;
                });

                app.UseHttpsRedirection();
                app.UseRouting();
                app.UseCors("corsapp");
                app.UseAuthorization();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
