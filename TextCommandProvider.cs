using System.Collections.Generic;
using System.Linq;
using Rocket.API;
using Rocket.API.Commands;
using Rocket.API.Plugins;

namespace fr34kyn01535.MessageAnnouncer
{
    public class TextCommandProvider : ICommandProvider
    {
        private readonly IPluginManager _pluginManager;

        public TextCommandProvider(IPluginManager pluginManager)
        {
            _pluginManager = pluginManager;
        }

        public string ServiceName => "TextCommands";
        public ILifecycleObject GetOwner(ICommand command)
        {
            return _pluginManager.GetPlugin("MessageAnnouncer");
        }

        public void Init()
        {
        }

        public void Rebuild()
        {
            _commands.Clear();
        }

        private readonly List<ICommand> _commands = new List<ICommand>();
        public IEnumerable<ICommand> Commands
        {
            get
            {
                var owner = (MessageAnnouncerPlugin)GetOwner(null);
                if (!owner.IsAlive)
                    return new List<ICommand>();

                foreach (var cmd in owner.ConfigurationInstance.TextCommands)
                {
                    if (_commands.Any(c => c.Name.Equals(cmd.Name)))
                        continue;

                    _commands.Add(new RocketTextCommand(cmd.Name, cmd.Help, cmd.Permission, cmd.Lines.ToList()));
                }

                return _commands;
            }
        }
    }
}