namespace WpfHostApi.ViewModels
{
    internal class Notification
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public int Duration { get; set; } = 1000;
    }
}