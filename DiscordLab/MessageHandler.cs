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
using MEC;

namespace DiscordLab
{
    class MessageHandler
    {
        private static DiscordLab discordLab = new DiscordLab();

        private DateTime lasttransfer;

        public string test = "BANANAS";

        public void TrySend(string message)
        {
            discordLab.Info("AAPLES");

            //if (string.IsNullOrEmpty(message)) return;

            //if (discordLab.socket.Connected) SendMessage(message);
            //else if (OpenConnection()) SendMessage(message);
            //else return;
        }

        private static void SendMessage(string message)
        {

        }

        private static bool OpenConnection()
        {
            try
            {
                discordLab.socket.Connect("127.0.0.1", discordLab.botPort);
                return true;

            }
            catch (Exception e)
            {
                discordLab.Error(e.ToString());
                return false;
            }
        }
    }
}
