namespace ANDERSONDFM.Compartilhado.Notifications
{
    public class Notification
    {
        public string Key { get; set; }
        public string Message { get; set; }

        public Notification()
        {
        }

        public Notification(string key, string message) : this()
        {
            Key = key;
            Message = message;
        }

        public override string ToString()
        {
            return Key;
        }
    }
}
