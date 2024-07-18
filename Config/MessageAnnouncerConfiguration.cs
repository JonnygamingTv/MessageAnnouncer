﻿using Rocket.API;

namespace fr34kyn01535.MessageAnnouncer.Config
{
    public class MessageAnnouncerConfiguration : Rocket.API.IRocketPluginConfiguration
    {
        public int Interval { get; set; }

        public Message[] Messages { get; set; }

        public TextCommand[] TextCommands { get; set; }
        public void LoadDefaults()
        {
            Interval = 100;
            Messages = new Message[] {
                new Message("Welcome to our server, we hope you enjoy your stay!", "Green"),
            new Message("Join our TeamSpeak 3 server!", "Green"),
            new Message("Please chat in english. Be polite.", "Green"),
            new Message("We are searching staff, Apply on our forum!", "Green"),
            new Message("Check out https://JonHosting.com", "Green"),
            new Message("If you have any questions ask an admin on our TeamSpeak 3 server!", "Green"),
            new Message("Please chat in english. Be polite.", "Green")
            };

            TextCommands = new TextCommand[]
        {
                new TextCommand
                {
                    Name = "rules",
                    Help = "Shows the server rules",
                    Lines = new[]
                    {
                    "#1 No offensive content in the chat, respect other players",
                    "#2 No bug using, exploiting or abuse of powers",
                    "#3 Don't ask admins for items, teleports, loot respawn, ect.",
                    "#4 Please speak english in the public chat"
                }
                }
        };
        }
    }
}