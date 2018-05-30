namespace fr34kyn01535.MessageAnnouncer.Config
{
    public class Message
    {
        public string Text { get; set; }
        public string Color { get; set; }

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
}