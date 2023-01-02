namespace AppraisalTool.App.Models.Notification
{
    public class NotificationVm
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string NotificationText { get; set; }

        public DateTime NotificationDate { get; set; } = DateTime.Now;

        public bool IsRead { get; set; }
    }
}
