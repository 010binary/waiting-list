using System;
using System.Collections.Generic;
using System.Linq;

namespace waitinglist.Features.Notifications;

public sealed record NotificationItem(string Title, string Message, DateTimeOffset CreatedAt);

public sealed class NotificationService
{
    private readonly WaitingList.WaitingListService _waitingListService;

    public NotificationService(WaitingList.WaitingListService waitingListService)
    {
        _waitingListService = waitingListService;
    }

    public IReadOnlyList<NotificationItem> GetNotifications()
    {
        var waitingListCount = _waitingListService.GetEntries().Count;

        return new[]
        {
            new NotificationItem("Feature folders", "Vertical slice routing is now enabled for the app.", DateTimeOffset.UtcNow),
            new NotificationItem("Waiting list", $"There are currently {waitingListCount} waiting list member(s).", DateTimeOffset.UtcNow)
        };
    }
}

