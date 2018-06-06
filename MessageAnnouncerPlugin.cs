using System;
using Rocket.Core.Plugins;
using System.Drawing;
using System.Globalization;
using fr34kyn01535.MessageAnnouncer.Config;
using Rocket.API.Commands;
using Rocket.API.DependencyInjection;
using Rocket.API.Scheduler;
using Rocket.API.User;
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
        private DateTime? _lastMessageTime;
        private ITask _task;

        protected override void OnLoad(bool isFromReload)
        {
            base.OnLoad(isFromReload);

            _task = _scheduler.ScheduleEveryAsyncFrame(this, PrintMessage, "Message announcer");

            if (!isFromReload)
                return;

            var provider = (TextCommandProvider)Container.Resolve<ICommandProvider>("text_commands");
            provider.Rebuild();
        }

        private void PrintMessage()
        {
            if (_lastMessageTime != null &&
                (DateTime.Now - _lastMessageTime.Value).TotalSeconds < ConfigurationInstance.Interval)
                return;

            var userManager = Container.Resolve<IUserManager>();
            if (_lastindex > (ConfigurationInstance.Messages.Length - 1))
                _lastindex = 0;

            Message message = ConfigurationInstance.Messages[_lastindex];
            userManager.Broadcast(null, message.Text, GetColorFromName(message.Color, Color.Green));
            _lastMessageTime = DateTime.Now;
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
