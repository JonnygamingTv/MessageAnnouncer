using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using SDG.Unturned;
using Rocket.Core.Plugins;
using Rocket.Core.Logging;
using Rocket.Unturned.Chat;

namespace fr34kyn01535.MessageAnnouncer
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
            Logger.Log("Load");
            if (Configuration != null && Configuration.Instance.TextCommands != null)
            {
                foreach (TextCommand t in Configuration.Instance.TextCommands)
                {
                    Commander.Commands.Add(new RocketTextCommand(t.Name, t.Help, t.Text));
                }
            }
        }

        protected override void Unload()
        {
            Logger.Log("Unload");
            Commander.Commands = Commander.Commands.Where(c => c.GetType().Assembly.GetName() != Assembly.GetExecutingAssembly().GetName()).ToList();
        }

        private void printMessage()
        {
            try
            {
                if (State == Rocket.API.PluginState.Loaded && Configuration.Instance.Messages != null && (lastmessage == null || ((DateTime.Now - lastmessage.Value).TotalSeconds > Configuration.Instance.Interval)))
                {
                    if (lastindex > (Configuration.Instance.Messages.Length - 1)) lastindex = 0;
                    Message message = Configuration.Instance.Messages[lastindex];
                    UnturnedChat.Say(message.Text, UnturnedChat.GetColorFromName(message.Color,Color.green));
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
