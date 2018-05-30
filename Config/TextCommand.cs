using Rocket.Core.Configuration;

namespace fr34kyn01535.MessageAnnouncer.Config
{
    public class TextCommand
    {
        public string Name { get; set; }
        public string Help { get; set; }

        [ConfigArray]
        public string[] Lines { get; set; }

        public string Permission { get; set; }
    }
}