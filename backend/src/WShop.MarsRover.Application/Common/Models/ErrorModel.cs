namespace WShop.MarsRover.Application.Common.Models
{
    public class ErrorModel
    {
        public ErrorModel(string key, string[] messages)
        {
            Key = key;
            Messages = messages;
        }
        public string Key { get; set; }

        public string[] Messages { get; set; }
    }
}