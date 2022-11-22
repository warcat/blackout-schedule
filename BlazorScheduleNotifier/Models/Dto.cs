namespace BlazorScheduleNotifier.Models
{
    public class SelectedQueue
    {
        public string City { get; set; }
        public string QueueName { get; set; }
        public bool IsSelected { get; set; }
    }

    public class QueueTime
    {
        public QueueTime(Queue queue, OfflineTime time)
        {
            Queue = queue;
            Time = time;
        }

        public Queue Queue { get; }
        public OfflineTime Time { get; }
    }
}
