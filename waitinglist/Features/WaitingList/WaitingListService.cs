using System.Collections.Generic;
using System.Linq;

namespace waitinglist.Features.WaitingList;

public sealed class WaitingListService
{
    private readonly WaitingListRepository _repository;

    public WaitingListService(WaitingListRepository repository)
    {
        _repository = repository;
    }

    public WaitingListConfirmationViewModel Register(WaitingListViewModel model)
    {
        var entry = _repository.Add(model.Name, model.Email, model.Notes);
        var queuePosition = _repository.GetAll().Count;

        return new WaitingListConfirmationViewModel
        {
            Name = entry.Name,
            Email = entry.Email,
            SubmittedAt = entry.CreatedAt,
            QueuePosition = queuePosition
        };
    }

    public IReadOnlyList<WaitingListEntry> GetEntries() => _repository.GetAll();
}

