using Rocket.API;
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
    public class RocketTextCommand : IRocketCommand
    {
        private List<string> text;
        private string name;
        private string help;
        

        public RocketTextCommand(string commandName,string commandHelp,List<string> text)
        {
            name = commandName;
            help = commandHelp;
            this.text = text;
        }

        public List<string> Aliases
        {
            get { return new List<string>(); }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            foreach (string l in text)
            {
                UnturnedChat.Say(caller, l);
            }
        }

        public string Help
        {
            get { return help; }
        }

        public string Name
        {
            get { return name; }
        }

        public List<string> Permissions
        {
            get { return new List<string>(); }
        }

        public string Syntax
        {
            get { return ""; }
        }


        public AllowedCaller AllowedCaller
        {
            get { return Rocket.API.AllowedCaller.Both; }
        }
    }
}
