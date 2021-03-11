using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyAlbumApplication.Core.Helper;
using MyAlbumApplication.Core.Interfaces;
using MyAlbumApplication.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAlbumApplication.Infrastructure
{
   public static class DependencyInyection
    {
        /// <summary>
        /// we add this method for futures addScoped services and do not write directly in startup
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddSingleton(typeof(ConnectionUrl));

            return services;
        }
    }
}
