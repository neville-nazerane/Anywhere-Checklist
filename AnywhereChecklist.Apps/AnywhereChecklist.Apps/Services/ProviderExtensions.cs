using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.DependencyInjection;

namespace AnywhereChecklist.Apps.Services
{
    static class ProviderExtensions
    {

        public static T Get<T>(this IServiceProvider provider) => provider.GetService<T>();

    }
}
