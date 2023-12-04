using Microsoft.Extensions.DependencyInjection;
using NewsWebApp.Core.Interfaces;
using NewsWebApp.DAL.Repository;
using NewsWebApp.DAL.Service;
using System;

namespace NewsWebApp.DAL
{
    public static class Configure
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IDataService, DataService>();
            services.AddTransient<IStoryRepository, StoryRepository>();
        }
    }
}
