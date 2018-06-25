using System;
using Rocket.Core.Plugins;
using System.Globalization;
using fr34kyn01535.MessageAnnouncer.Config;
using Rocket.API.Commands;
using Rocket.API.DependencyInjection;
using Rocket.API.Drawing;
using Rocket.API.Scheduler;
using Rocket.API.User;
using Rocket.Core.Logging;
using Rocket.Core.Scheduler;

namespace fr34kyn01535.MessageAnnouncer
{
    public class MessageAnnouncerPlugin : Plugin<MessageAnnouncerConfiguration>
    {
        private readonly ITaskScheduler _scheduler;

        public MessageAnnouncerPlugin(IDependencyContainer container, ITaskScheduler scheduler) : base("MessageAnnouncer", container)
        {
            _scheduler = scheduler;
        }

        private int _lastindex;

        protected override void OnLoad(bool isFromReload)
        {
            base.OnLoad(isFromReload);
            Logger.LogInformation("Loaded.");

            _scheduler.SchedulePeriodically(this, PrintMessage, "Message announcer", new TimeSpan(0, 0, 0, ConfigurationInstance.Interval));

            if (!isFromReload)
                return;

            var provider = (TextCommandProvider)Container.Resolve<ICommandProvider>("text_commands");
            provider.Rebuild();
        }

        private void PrintMessage()
        {
            var userManager = Container.Resolve<IUserManager>();
            if (_lastindex > (ConfigurationInstance.Messages.Length - 1))
                _lastindex = 0;

            Message message = ConfigurationInstance.Messages[_lastindex];
            userManager.Broadcast(null, message.Text, GetColorFromName(message.Color, Color.Green));
            _lastindex++;
        }

        private Color GetColorFromName(string colorString, Color defaultColor)
        {
            var color = defaultColor;
            try
            {
                color = Color.FromName(colorString);
                if (color != default(Color))
                    return color;

                int argb = Int32.Parse(colorString.Replace("#", ""), NumberStyles.HexNumber);
                color = Color.FromArgb(argb);
            }
            catch { }

            return color;
        }
    }
}
