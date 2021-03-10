using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        //https://docs.microsoft.com/en-us/aspnet/core/tutorials/signalr?view=aspnetcore-3.1&tabs=visual-studio


        List<string> CurrentConnections = new List<string>();
        public override Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var clients = Clients;

            CurrentConnections.Add(httpContext.Session.Id);
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception ex)
        {
            return base.OnDisconnectedAsync(ex);
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
