using Rocket.API;
using Rocket.Unturned.Chat;
using System;
using System.Collections.Generic;

namespace fr34kyn01535.MessageAnnouncer
{
    public class RocketTextCommand : IRocketCommand
    {
        public string Name { get; }
        public List<string> Aliases => null;
        public string Syntax => "";
        public string Help { get; }
        public string Description => null;
        public List<string> Permissions { get; }

        public AllowedCaller AllowedCaller => AllowedCaller.Both;

        private readonly string[] _textLines;

        public RocketTextCommand(string name, string summary, string permission, string[] textLines)
        {
            Name = name;
            Help = summary;
            Permissions = new List<string> { permission };

            _textLines = textLines;
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            foreach (string l in _textLines)
            {
                UnturnedChat.Say(caller,l);
            }
        }
    }
}
