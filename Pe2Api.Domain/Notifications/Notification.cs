namespace Pe2Api.Domain.Notifications
{
    public class Notification
    {
        public Notification()
        {

        }
        public Notification(string key, string message)
        {
            Key = key;
            Message = message;
        }

        public string Key { get; set; }
        public string Message { get; set; }
    }
}
