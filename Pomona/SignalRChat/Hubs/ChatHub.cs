using DBModel;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        //https://docs.microsoft.com/en-us/aspnet/core/tutorials/signalr?view=aspnetcore-3.1&tabs=visual-studio

        readonly DbModelContext db;
        //private List<string> loggedSessions
        //{
        //    get
        //    {
        //        return (Session.AppContext.MemoryCache.Get("loggedSessions_") == null)
        //            ? null : (List<string>)(Session.AppContext.MemoryCache.Get("loggedSessions_"));
        //    }
        //    set
        //    {
        //        Session.AppContext.MemoryCache.Set("loggedSessions_", value);
        //    }
        //}

        public ChatHub(DBModel.DbModelContext db)
        {
            this.db = db;
        }
        List<string> CurrentConnections = new List<string>();
        public override Task OnConnectedAsync()
        {
            // var httpContext = Context.GetHttpContext();

            LoginUser(Session.AppContext.UserID);

            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception ex)
        {
            LogoutUser(Session.AppContext.UserID);
           // var httpContext = Context.GetHttpContext();
          //  var sessionAutentification = httpContext.Request.Query["autentification"][0];                   
            return base.OnDisconnectedAsync(ex);
        }

        private void LogoutUser(int userID)
        {
            var user = db.Users.Where(x => x.UserID == userID).FirstOrDefault();
            user.IndLogged = 0;
            db.Users.Update(user);
            db.SaveChanges();
        }

        private void LoginUser(int userID)
        {
            var user = db.Users.Where(x => x.UserID == userID).FirstOrDefault();
            user.IndLogged = 1;
            db.Users.Update(user);
            db.SaveChanges();
        }

        //public List<string> GetAllActiveConnections()
        //{
        //    return CurrentConnections.ToList();
        //}
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }



    }
}
