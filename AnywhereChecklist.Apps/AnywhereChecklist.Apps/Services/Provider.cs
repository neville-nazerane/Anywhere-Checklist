using AnywhereChecklist.Apps.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnywhereChecklist.Apps.Services
{
    static class Provider
    {

        static IServiceProvider _buildProvider()
            => new ServiceCollection()
                    
                .AddSingleton<ApiClient>()
                .AddScoped<AuthSocket>()
                .AddScoped<UpdateSocket>()
                .AddScoped<ListsRepository>()

                // view models
                .AddScoped<ListingViewModel>()
                .AddScoped<ListingViewModel>()

                .BuildServiceProvider();

        static IServiceProvider _serviceProvider;
        static IServiceProvider ServiceProvider => _serviceProvider ?? (_serviceProvider = _buildProvider());

        public static IServiceScope CreateScope() => ServiceProvider.CreateScope();

        public static T Get<T>() => ServiceProvider.Get<T>();

        public static async Task<bool> IsAuthenticatedAsync() => await Get<ApiClient>().IsAuthenticatedAsync();

        public static void UnAuthenticate() => Get<ApiClient>().UnAuthenticate();

    }
}
