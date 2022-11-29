using Application.Common.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class NotificationService : Hub, INotificationService
    {
        public async Task SendFriendRequestNoti(string user, string content)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, content);
        }
    }
}
