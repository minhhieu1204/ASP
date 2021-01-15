using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnASP.Hubs
{
    public class NotificationHubs:Hub
    {
        public static string messagesss { set; get; }
        public async Task NotificationClient()
        {
            await Clients.All.SendAsync("ClientSideFunction", messagesss);
        }
    }
}
