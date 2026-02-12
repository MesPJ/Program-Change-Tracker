using ProgramChangeTracker.Models;

namespace ProgramChangeTracker.Services;

public class ChangeRequestService
{
    private readonly List<ChangeRequest> _items = new();
    private int _nextId = 1;

    public List<ChangeRequest> GetAll()
    {
        return _items;
    }

    public ChangeRequest Add(string title)
    {
        var item = new ChangeRequest
        {
            Id = _nextId++,
            Title = title,
            Status = "Open",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _items.Add(item);
        return item;
    }
}