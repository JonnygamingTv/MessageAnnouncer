
using Rocket.RocketAPI;
using System.Collections.Generic;
using System.Xml.Serialization;
namespace unturned.ROCKS.MessageAnnouncer
{
    public sealed class TextCommand
    {
        public string Name;
        public string Help;
        [XmlArrayItem("Line")]
        public List<string> Text;
    }
    public class MessageAnnouncerConfiguration : RocketConfiguration
    {
        public int Interval;
        public string[] Messages;

        [XmlArrayItem("TextCommand")]
        [XmlArray(ElementName = "TextCommands")]
        public List<TextCommand> TextCommands;

        public RocketConfiguration DefaultConfiguration
        {
            get {
                MessageAnnouncerConfiguration config = new MessageAnnouncerConfiguration();
                config.Messages = new string[]{ 
                    "Welcome to unturned.ROCKS, we hope you enjoy your stay!",
                    "Join our TeamSpeak 3 server at unturned.ROCKS!",
                    "Please chat in english. Be polite.",
                    "We are searchin staff, Apply on our forum!",
                    "Check out our forum at https://unturned.ROCKS",
                    "If you have any questions ask an admin on our TeamSpeak 3 server!",
                    "Please chat in english. Be polite.",
                    "We are searchin staff, Apply on our forum!",
                };
                config.TextCommands = new List<TextCommand>(){
                    new TextCommand(){Name="rules",Help="Shows the server rules",Text = new List<string>(){
        "#1 No offensive content in the chat, respect other players",
        "#2 No bug using, exploiting or abuse of powers",
        "#3 Don't ask admins for items, teleports, loot respawn, ect.",
        "#4 Please speak english in the public chat"}}
                };
                config.Interval =  180;
                return config;
            }
        }
    }
}
