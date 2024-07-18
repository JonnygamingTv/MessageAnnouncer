namespace fr34kyn01535.MessageAnnouncer.Config
{
    public class Message
    {
        public string Text { get; set; }
        public string Color { get; set; }
        public UnityEngine.Color UseColor { get; private set; }

        public Message(string text, string color)
        {
            Text = text;
            Color = color;
            UseColor = MessageAnnouncer.MessageAnnouncerPlugin.GetColorFromName(Color, UnityEngine.Color.green);
        }

        public Message()
        {
            Text = "";
            Color = "";
        }
    }
}