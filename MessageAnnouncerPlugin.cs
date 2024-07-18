using System;
using System.Globalization;
using fr34kyn01535.MessageAnnouncer.Config;
using Rocket.Core.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Rocket.Unturned.Chat;
using UnityEngine;
using System.Collections;
using Rocket.Core;

namespace fr34kyn01535.MessageAnnouncer
{
    public class MessageAnnouncerPlugin : Rocket.Core.Plugins.RocketPlugin<MessageAnnouncerConfiguration>
    {
        private int _lastindex;

        protected override void Load()
        {
            Rocket.Core.Logging.Logger.Log("Loading.");

            StartCoroutine(nameof(PrintMessage));

            if (Configuration.Instance.TextCommands != null)
            {
                for (int i = 0; i < Configuration.Instance.TextCommands.Length; i++)
                {
                    RocketTextCommand cmd = new RocketTextCommand(Configuration.Instance.TextCommands[i].Name, Configuration.Instance.TextCommands[i].Help, Configuration.Instance.TextCommands[i].Permission, Configuration.Instance.TextCommands[i].Lines);
                    R.Commands.Register(cmd);
                }
            }

            Rocket.Core.Logging.Logger.Log("Loaded.");
        }
        protected override void Unload()
        {
            Rocket.Core.Logging.Logger.Log("Unloading.");
            StopAllCoroutines();
            foreach (var command in Configuration.Instance.TextCommands)
            {
                R.Commands.DeregisterFromAssembly(this.Assembly);
            }
            Rocket.Core.Logging.Logger.Log("Unloaded.");
        }
        private IEnumerator PrintMessage()
        {
            yield return new WaitForSeconds(Configuration.Instance.Interval);
            if (_lastindex > (Configuration.Instance.Messages.Length - 1))
                _lastindex = 0;

            Message message = Configuration.Instance.Messages[_lastindex];
            UnturnedChat.Say(message.Text, message.UseColor, true);
            _lastindex++;
            StartCoroutine(nameof(PrintMessage));
        }

        public static Color GetColorFromName(string colorString, Color defaultColor)
        {
            var color = defaultColor;
            try
            {
                color = UnturnedChat.GetColorFromName(colorString, defaultColor);
                if (color != default(Color))
                    return color;

//                int argb = Int32.Parse(colorString.Replace("#", ""), NumberStyles.HexNumber);
                color = (Color)UnturnedChat.GetColorFromHex(colorString);
            }
            catch { }

            return color;
        }
    }
}
