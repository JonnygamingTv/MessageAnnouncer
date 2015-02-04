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

        void Update()
        {
            printMessage();
        }


        private void printMessage()
        {
            try
            {
                if (Loaded && lastmessage == null || ((DateTime.Now - lastmessage.Value).TotalSeconds > Configuration.Interval))
                {
                    if (lastindex > (Configuration.Messages.Length - 1)) lastindex = 0;
                    string message = Configuration.Messages[lastindex];
                    ChatManager.say(message);
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
