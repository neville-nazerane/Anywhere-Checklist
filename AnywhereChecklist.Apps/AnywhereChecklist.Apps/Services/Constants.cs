using System;
using System.Collections.Generic;
using System.Text;

namespace AnywhereChecklist.Apps.Services
{
    static class Constants
    {

#if DEBUG
        internal const string baseUrl = "http://10.0.2.2:63706";
#else
        internal const string baseUrl = "https://checklist.nevillenazerane.com";
#endif

        internal const string socketUrl = baseUrl;

    }
}
