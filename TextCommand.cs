using Rocket.Unturned;
using Rocket.Unturned.Chat;
using SDG;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fr34kyn01535.MessageAnnouncer
{
    public class RocketTextCommand : Command
    {
        private List<string> text;

        public RocketTextCommand(string commandName,string commandHelp,List<string> text)
        {
            base.commandName = commandName;
            base.commandHelp = commandHelp;
            base.commandInfo = base.commandName + " - " + base.commandHelp;
            this.text = text;
        }

        protected override void execute(Steamworks.CSteamID caller, string command)
        {
            foreach (string l in text) {
                UnturnedChat.Say(caller, l);
            }
        }
    }
}
