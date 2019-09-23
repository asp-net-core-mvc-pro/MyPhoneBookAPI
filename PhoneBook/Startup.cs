using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PhoneBook
{
    using AutoMapper;

    using Microsoft.EntityFrameworkCore;

    using Phonebook.Data;

    using Swashbuckle.AspNetCore.Swagger;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PhonebookContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("PhonebookConnectionString"));
            });

            services.AddAutoMapper();

            services.AddTransient<PhonebookSeeder>();

            services.AddScoped<IPhonebookRepository, PhonebookRepository>();

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "My First API",
                    Description = "My First ASP.NET Core 2.2 Web API",
                    TermsOfService = "None",
                    Contact = new Contact()
                    {
                        Name = "Morsal Mousavi",
                        Email = "morsla84@gmail.com",
                        Url = "https://google.com/"
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            if (env.IsDevelopment())
            {
                // Seed the database
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetService<PhonebookSeeder>();
                    seeder.Seed();
                }
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
