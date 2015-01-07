
using Rocket.RocketAPI;
namespace unturned.ROCKS.MessageAnnouncer
{
    public class MessageAnnouncerConfiguration : RocketConfiguration
    {
        public int Interval;
        public string[] Messages;

        public RocketConfiguration DefaultConfiguration
        {
            get {
                MessageAnnouncerConfiguration config = new MessageAnnouncerConfiguration();
                config.Messages = new string[]{ 
                    "Welcome to unturned.ROCKS, we hope you enjoy your stay!",
                    "Join our TeamSpeak 3 server at unturned.ROCKS!",
                    "Please chat in english. Be polite.",
                    "We are searchin staff, Apply on our forum!",
                    "Check out our forum at forum.unturned.ROCKS",
                    "If you have any questions ask an admin on our TeamSpeak 3 server!",
                    "Please chat in english. Be polite.",
                    "We are searchin staff, Apply on our forum!",
                };
                config.Interval =  180;
                return config;
            }
        }
    }
}
