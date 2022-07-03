using MediatR;
using Shell.API.Domain.Events;
using Shell.API.Domain.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Shell.API.Application.Features.Handlers
{
    public class PageNameChangedHandler : INotificationHandler<PageNameChangedEvent>
    {
        private readonly IRowService _rowService;

        public PageNameChangedHandler(IRowService rowService)
        {
            _rowService = rowService;
        }

        public async Task Handle(PageNameChangedEvent notification, CancellationToken cancellationToken)
        {
            await _rowService.ChangePageNameAsync(notification.OldPageName, notification.NewPageName);
        }
    }
}
