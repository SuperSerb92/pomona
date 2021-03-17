using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;


namespace Session
{
    public class AppContext
    {
        private static IHttpContextAccessor _httpContextAccessor;
        private static IMemoryCache _memoryCache;
        private static int userID;


        private static ISession _session => _httpContextAccessor.HttpContext.Session;

        public static void Configure(IHttpContextAccessor httpContextAccessor, IMemoryCache memoryCache)
        {
            _httpContextAccessor = httpContextAccessor;
            _memoryCache = memoryCache;
        }
        public static HttpContext HttpContext => (_httpContextAccessor == null) ? null : _httpContextAccessor.HttpContext;
        public static IMemoryCache MemoryCache => (_memoryCache == null) ? null : _memoryCache;

        public static IDictionary<object, object> Items { get { return _httpContextAccessor.HttpContext.Items; } }

        public static string Id
        {
            get
            {
              
                var routes = _httpContextAccessor.HttpContext.GetRouteData();
                var val = routes?.Values["guid"]?.ToString() as string;

                return val;
            }
        }
        public static string sessionID
        {
            get
            {
                return _session.Id;
            }
        }

        public static int UserID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
            }
        }


    }
}
