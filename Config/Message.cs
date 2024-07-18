namespace fr34kyn01535.MessageAnnouncer.Config
{
    public class Message
    {
        public string Text { get; set; }
        public string Color { get; set; }

        public string Icon { get; set; }
        public UnityEngine.Color UseColor { get; set; }

        public Message(string text, string color, string icon = "https://jonhosting.com/JonHostingG.png")
        {
            Text = text;
            Color = color;
            Icon = icon;
            UseColor = MessageAnnouncer.MessageAnnouncerPlugin.GetColorFromName(Color, UnityEngine.Color.green);
        }

        public Message()
        {
            Text = "";
            Color = "";
            Icon = "";
        }
    }
}