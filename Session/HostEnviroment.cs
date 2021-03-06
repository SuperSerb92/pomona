using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Session
{ 
        public static class HostEnvironment
        {
            private static IHostingEnvironment _hostingEnvironment;

            public static void Configure(IHostingEnvironment hostingEnvironment)
            {
                _hostingEnvironment = hostingEnvironment;
            }
            public static IHostingEnvironment HostingEnvironment => _hostingEnvironment;

            public static string HostingRootFile => ((Microsoft.Extensions.FileProviders.PhysicalFileProvider)(HostEnvironment.HostingEnvironment.ContentRootFileProvider)).Root;
        }
    
}
