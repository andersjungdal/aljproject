﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Blazor.Server.SignalR.Hubs
{
    public class ChatHub : Hub
    {
        public async Task JoinGroup(string groupId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupId);
            await Clients.Caller.SendAsync("NewUserEntered", "Welcome to group chat");
        }
        public async Task SendGroup(string message, string groupId)
        {
            await Clients.Group(groupId).SendAsync("SendMessageToGroup", message);
        }
        
    }
}
