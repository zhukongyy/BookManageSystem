using AntDesign;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace BlazorApp4
{
    public class MessageModel
    {
        protected bool success;
    }
    public static class NoticeModel
    {

        static public async Task ShowNotification(string message, string description, INotificationService _notice,NotificationType type)
        {
            var config = new NotificationConfig()
            {
                Duration = 3,
                Message = message,
                Description = description + "\n" + System.DateTime.Now.ToString(),
                Placement = NotificationPlacement.Bottom,
                NotificationType = type
            };
            var notificationRef = await _notice.CreateRefAsync(config);
            await notificationRef.OpenAsync();
        }

    }

    public class Book
    {
        [JsonPropertyName("isbn")]
        public string Isbn { get; set; } = "";
        [JsonPropertyName("name")]
        public string Title { get; set; } = "";
        [JsonPropertyName("author")]
        public string Author { get; set; } = "";
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
        [JsonPropertyName("date")]
        public DateTime Book_Add_Date { get; set; }
        [JsonPropertyName("publisher")]
        public string Publisher { get; set; } = "";
        [JsonPropertyName("category")]
        public string? Category { get; set; } = "";
    }

    public class User
    {
        [Required, JsonPropertyName("name")]
        public string? Name { get; set; }
        [Required, JsonPropertyName("card")]
        public string? Card { get; set; }
        [Required, JsonPropertyName("specialty")]
        public string? Specialty { get; set; }
        [Required, JsonPropertyName("education")]
        public string? Education { get; set; }
    }
    public class Lend
    {
        public Book book { get; set; }
        [JsonPropertyName("person")]
        public User user { get; set; }
        public DateTime lend_date { get; set; }
    }
}
