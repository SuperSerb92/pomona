using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Session
{
    public class CurrentSession
    {

        private static SessionData sessionData = null;

        public static SessionData CurrentSessionData
        {
            get
            {
                return AppContext.HttpContext == null ? sessionData : AppContext.MemoryCache.Get("sessionData_" + AppContext.Id) as SessionData;
            }
            set
            {
                if (AppContext.HttpContext == null) sessionData = value;
                else
                {
                    AppContext.MemoryCache.Set("sessionData_" + AppContext.Id, value);
                }

            }

        }
    }
}