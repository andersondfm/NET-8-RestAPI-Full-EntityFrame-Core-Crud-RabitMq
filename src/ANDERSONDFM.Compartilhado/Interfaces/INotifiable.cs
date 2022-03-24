using ANDERSONDFM.Compartilhado.Notifications;

namespace ANDERSONDFM.Compartilhado.Interfaces
{
    public interface INotifiable
    {
        void AddNotifications(IEnumerable<Notification> notifications);
    }
}
