using System;
using System.ComponentModel.DataAnnotations;

namespace waitinglist.Features.WaitingList;

public sealed class WaitingListViewModel
{
    [Required]
    [Display(Name = "Full name")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Notes { get; set; }
}

public sealed class WaitingListConfirmationViewModel
{
    public string Name { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;

    public DateTimeOffset SubmittedAt { get; init; }

    public int QueuePosition { get; init; }
}

