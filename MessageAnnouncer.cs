using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Steamworks;
using SDG;
using System.Timers;
using System.IO;
using System.Reflection;
using System.ComponentModel;
using Rocket;
using Rocket.Unturned.Plugins;
using Rocket.Unturned.Logging;
using Rocket.Unturned;
using UnityEngine;

namespace unturned.ROCKS.MessageAnnouncer
{
    public class MessageAnnouncer : RocketPlugin<MessageAnnouncerConfiguration>
    {
        public int lastindex = 0;
        public DateTime? lastmessage = null;

        void FixedUpdate()
        {
            printMessage();
        }

        protected override void Load()
        {
            if (Configuration != null && Configuration.TextCommands != null)
            {
                foreach (TextCommand t in Configuration.TextCommands)
                {
                    Commander.Commands.Add(new RocketTextCommand(t.Name, t.Help, t.Text));
                }
            }
        }

        protected override void Unload()
        {
            Commander.Commands = Commander.Commands.Where(c => c.GetType().Assembly.GetName() != Assembly.GetExecutingAssembly().GetName()).ToList();
        }

        private void printMessage()
        {
            try
            {
                if (Loaded && Configuration.Messages != null && (lastmessage == null || ((DateTime.Now - lastmessage.Value).TotalSeconds > Configuration.Interval)))
                {
                    if (lastindex > (Configuration.Messages.Length - 1)) lastindex = 0;
                    Message message = Configuration.Messages[lastindex];
                    RocketChat.Say(message.Text,RocketChat.GetColorFromName(message.Color,Color.green));
                    Logger.Log(message.Text);
                    lastmessage = DateTime.Now;
                    lastindex++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        }
    }
}
