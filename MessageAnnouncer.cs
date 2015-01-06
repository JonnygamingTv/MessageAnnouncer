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

namespace unturned.ROCKS.MessageAnnouncer
{
    public class MessageAnnouncer : RocketPlugin<MessageAnnouncerConfiguration>
    {
        public int lastindex = 0;
        public DateTime? lastmessage = null;

        protected override void Load()
        {
            Events.OnPlayerConnected += Events_OnPlayerPrint;
            Events.OnPlayerDisconnected += Events_OnPlayerPrint;
        }

        void Events_OnPlayerPrint(Player player)
        {
            printMessage(player.SteamChannel.SteamPlayer.SteamPlayerID.CSteamID);
        }


        private void printMessage(CSteamID id)
        {
            try
            {
                if (lastmessage == null || ((DateTime.Now - lastmessage.Value).TotalSeconds > Configuration.Interval))
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
