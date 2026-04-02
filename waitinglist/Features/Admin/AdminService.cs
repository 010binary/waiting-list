using System.Collections.Generic;
using System.Linq;
using waitinglist.Features.WaitingList;

namespace waitinglist.Features.Admin;

public sealed record AdminDashboardViewModel(int TotalWaitingListMembers, IReadOnlyList<WaitingListEntry> RecentSignups);

public sealed class AdminService
{
    private readonly WaitingListService _waitingListService;

    public AdminService(WaitingListService waitingListService)
    {
        _waitingListService = waitingListService;
    }

    public AdminDashboardViewModel GetDashboard()
    {
        var entries = _waitingListService.GetEntries();
        var recentSignups = entries
            .OrderByDescending(entry => entry.CreatedAt)
            .Take(5)
            .ToList();

        return new AdminDashboardViewModel(entries.Count, recentSignups);
    }
}

