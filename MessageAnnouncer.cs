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
using Rocket.RocketAPI;
using Rocket.Logging;

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
            List<Command> commands = Commander.Commands.ToList();
            foreach (TextCommand t in Configuration.TextCommands)
            {
                commands.Add(new RocketTextCommand(t.Name, t.Help, t.Text));
            }
            Commander.Commands = commands.ToArray();
        }

        protected override void Unload()
        {
            Command[] commands = Commander.Commands;
            commands = commands.Where(c => c.GetType().Assembly.GetName() != Assembly.GetExecutingAssembly().GetName()).ToArray();
            Commander.Commands = commands;
        }

        private void printMessage()
        {
            try
            {
                if (Loaded && Configuration.Messages != null && (lastmessage == null || ((DateTime.Now - lastmessage.Value).TotalSeconds > Configuration.Interval)))
                {
                    if (lastindex > (Configuration.Messages.Length - 1)) lastindex = 0;
                    string message = Configuration.Messages[lastindex];
                    RocketChatManager.Say(message);
                    Logger.Log(message);
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
