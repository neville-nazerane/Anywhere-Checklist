using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnywhereChecklist.Website
{
    public static class HostExtensions
    {

        public static IWebHostBuilder UseUrlsIfExist(this IWebHostBuilder builder)
        {
            var urls = Environment.GetEnvironmentVariable("USING_URLS")?.Split(";");
            if (urls != null) builder.UseUrls(urls);
            return builder;
        }

    }
}
