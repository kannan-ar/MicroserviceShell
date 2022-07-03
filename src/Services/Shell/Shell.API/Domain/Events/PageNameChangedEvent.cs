using MediatR;

namespace Shell.API.Domain.Events
{
    public class PageNameChangedEvent : INotification
    {
        public PageNameChangedEvent(string oldPageName, string newPageName)
        {
            OldPageName = oldPageName;
            NewPageName = newPageName;
        }

        public string OldPageName { get; }
        public string NewPageName { get; }
    }
}
