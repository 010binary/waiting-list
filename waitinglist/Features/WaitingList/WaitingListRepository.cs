using System;
using System.Collections.Generic;
using System.Linq;

namespace waitinglist.Features.WaitingList;

public sealed record WaitingListEntry(
    Guid Id,
    string Name,
    string Email,
    string? Notes,
    DateTimeOffset CreatedAt);

public sealed class WaitingListRepository
{
    private readonly List<WaitingListEntry> _entries = [];
    private readonly object _gate = new();

    public WaitingListEntry Add(string name, string email, string? notes)
    {
        var entry = new WaitingListEntry(Guid.NewGuid(), name.Trim(), email.Trim(), notes?.Trim(), DateTimeOffset.UtcNow);

        lock (_gate)
        {
            _entries.Add(entry);
        }

        return entry;
    }

    public IReadOnlyList<WaitingListEntry> GetAll()
    {
        lock (_gate)
        {
            return _entries
                .OrderBy(entry => entry.CreatedAt)
                .ToList();
        }
    }
}

