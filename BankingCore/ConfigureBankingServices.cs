using BankingCore.Controllers;
using BankingCore.Services;
using BankingCore.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace BankingCore
{
    public static class ConfigureBankingServices
    {
        public static IServiceCollection AddBankingCore(this IServiceCollection services)
        {
            services.AddScoped<BankController>();
            services.AddScoped<AccountController>();
            services.AddScoped<TransactionController>();

            services.AddScoped<BankService>();
            services.AddScoped<AccountService>();
            services.AddScoped<TransactionService>();

            services.AddScoped<BankValidator>();
            services.AddScoped<AccountValidator>();
            services.AddScoped<TransactionValidator>();
            return services;
        }
    }
}
