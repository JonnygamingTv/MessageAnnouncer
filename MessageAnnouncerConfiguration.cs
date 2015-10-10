using Rocket.API;
using System.Collections.Generic;
using System.Xml.Serialization;
using System;

namespace fr34kyn01535.MessageAnnouncer
{
    public sealed class TextCommand
    {
        public string Name;
        public string Help;
        [XmlArrayItem("Line")]
        public List<string> Text;
    }

    public sealed class Message
    {
        [XmlAttribute("Text")]
        public string Text;

        [XmlAttribute("Color")]
        public string Color;

        public Message(string text, string color)
        {
            Text = text;
            Color = color;
        }
        public Message()
        {
            Text = "";
            Color = "";
        }
    }

    public class MessageAnnouncerConfiguration : IRocketPluginConfiguration
    {
        public int Interval;

        [XmlArrayItem("Message")]
        [XmlArray(ElementName = "Messages")]
        public Message[] Messages;

        [XmlArrayItem("TextCommand")]
        [XmlArray(ElementName = "TextCommands")]
        public List<TextCommand> TextCommands;

        public void LoadDefaults()
        {
            Interval = 180;
            Messages = new Message[]{
                new Message("Welcome to unturned.ROCKS, we hope you enjoy your stay!","Green"),
                new Message("Join our TeamSpeak 3 server at unturned.ROCKS!","Green"),
                new Message("Please chat in english. Be polite.","Green"),
                new Message("We are searchin staff, Apply on our forum!","Green"),
                new Message("Check out our forum at https://unturned.ROCKS","Green"),
                new Message("If you have any questions ask an admin on our TeamSpeak 3 server!","Green"),
                new Message("Please chat in english. Be polite.","Green"),
                new Message("We are searchin staff, Apply on our forum!","Green")
            };
            TextCommands = new List<TextCommand>(){
                new TextCommand(){Name="rules",Help="Shows the server rules",Text = new List<string>(){
                    "#1 No offensive content in the chat, respect other players",
                    "#2 No bug using, exploiting or abuse of powers",
                    "#3 Don't ask admins for items, teleports, loot respawn, ect.",
                    "#4 Please speak english in the public chat"}
                }
            };
        }
    }
}
