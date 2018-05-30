using System;
using System.Collections.Generic;
using Rocket.API.Commands;
using Rocket.Core.DependencyInjection;
using Rocket.Core.User;

namespace fr34kyn01535.MessageAnnouncer
{
    [DontAutoRegister]
    public class RocketTextCommand : ICommand
    {
        public string Name { get; }
        public string[] Aliases => null;
        public string Syntax => "";
        public IChildCommand[] ChildCommands => null;
        public string Summary { get; }
        public string Description => null;
        public string Permission { get; }

        private readonly List<string> _textLines;

        public RocketTextCommand(string name, string summary, string permission, List<string> textLines)
        {
            Name = name;
            Summary = summary;
            Permission = permission;

            _textLines = textLines;
        }

        public bool SupportsUser(Type user)
        {
            return true;
        }

        public void Execute(ICommandContext context)
        {
            foreach (string l in _textLines)
            {
                context.User.SendMessage(l);
            }
        }
    }
}
