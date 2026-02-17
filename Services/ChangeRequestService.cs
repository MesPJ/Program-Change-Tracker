using Microsoft.AspNetCore.Http.Features;
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


    public ChangeRequest Add(string title, string description)
    {
        var item = new ChangeRequest
        {
            Id = _nextId++,
            Title = title,
            Description = description, 
            Status = "Open",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _items.Add(item);
        return item;
    }

    public void Close(int id)
    {
        var item = _items.FirstOrDefault(x => x.Id == id);
        if(item == null) return;

        item.Status = "Closed";
        item.UpdatedAt = DateTime.UtcNow;

    }

}