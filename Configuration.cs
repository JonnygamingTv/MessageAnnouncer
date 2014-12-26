using Rocket.RocketAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace unturned.ROCKS.MessageAnnouncer
{
    public class Configuration : RocketConfiguration
    {
        public bool Enabled = false;
        public int Interval = 180;
        public string[] Messages = { 
            "Welcome to unturned.ROCKS, we hope you enjoy your stay!",
            "Join our TeamSpeak 3 server at unturned.ROCKS!",
            "lease chat in english. Be polite.",
            "We are searchin staff, Apply on our forum!",
            "Check out our forum at forum.unturned.ROCKS",
            "If you have any questions ask an admin on our TeamSpeak 3 server!",
            "Please chat in english. Be polite.",
            "We are searchin staff, Apply on our forum!",
        };
    }
}
