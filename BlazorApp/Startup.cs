using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using BankingCore;
using Blazor.FileReader;
using BankingCore.Controllers;
using BankingCore.Services;
using BankingCore.Validation;

namespace BlazorApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString;

            if (true)
            {
                connectionString = Configuration.GetConnectionString("Database");
            }
            else
            {
                var server = Configuration["DBServer"] ?? "localhost";
                var dbPort = Configuration["DBPort"] ?? "1443";
                var dbUser = Configuration["DBUser"] ?? "SA";
                var dbPass = Configuration["DBPassword"] ?? "password";
                var dbName = Configuration["DBName"] ?? "Pressure";
                connectionString = @$"Server={server};Database={dbName};User={dbUser};Password={dbPass};";
            }            

            services.AddDbContext<BankingDbContext>(options => 
                options.UseSqlServer(connectionString));

            services.AddControllers();
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddScoped<BankController>();
            services.AddScoped<AccountController>();
            services.AddScoped<TransactionController>();
            
            services.AddScoped<BankService>();
            services.AddScoped<AccountService>();
            services.AddScoped<TransactionService>();

            services.AddScoped<BankValidator>();
            services.AddScoped<AccountValidator>();
            services.AddScoped<TransactionValidator>();

            services.AddScoped<System.Net.Http.HttpClient>();

            services.AddFileReaderService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //PrepDb.PrepPopulation(app);

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
