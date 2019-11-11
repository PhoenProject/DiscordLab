using Newtonsoft.Json;
using Smod2;
using Smod2.API;
using Smod2.Attributes;
using Smod2.Commands;
using Smod2.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using Smod2.EventHandlers;
using Smod2.Piping;
using System.Net.Sockets;
using Smod2.Config;
using System.Net;

namespace DiscordLab
{
    [PluginDetails(
        author = "Phoenix",
        configPrefix = "dl",
        description = "Connects your discord server and your SCP: Secret laboratory servers together",
        id = "phoenix.discordlab",
        name = "DiscordLab",
        SmodMajor = 3,
        SmodMinor = 5,
        SmodRevision = 0
        )]

    public class DiscordLab : Plugin
    {
        internal Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private readonly List<string> messageQueue = new List<string>();

        [ConfigOption]
        internal int botPort = 7727;

        public override void OnDisable()
        {
            Info(this.Details.name + " has been disabled");
        }

        public override void OnEnable()
        {
            Info(this.Details.name + " has been enabled");
        }

        public override void Register()
        {
            AddEventHandlers(new PlayerEvents(this));
            AddEventHandlers(new RoundEvents(this));
        }

        public void TrySend(string message)
        {
            if (string.IsNullOrEmpty(message)) return;
            if (socket.Connected) SendMessage(message);
            else
            {
                OpenConnection();
                SendMessage(message);
                return;
            }
        }

        private void SendMessage(string message)
        {
            socket.Send(Encoding.UTF8.GetBytes(message));
        }

        private void OpenConnection()
        {
            socket.Connect(IPAddress.Parse("127.0.0.1"), botPort);
        }
    }
}
