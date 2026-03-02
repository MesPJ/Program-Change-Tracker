using Microsoft.AspNetCore.Http.Features;
using Microsoft.VisualBasic;
using ProgramChangeTracker.Models;

namespace ProgramChangeTracker.Services;

public class ChangeRequestService
{
    private readonly List<ChangeRequest> _items = new();
    private int _nextId = 1;

    public List<ChangeRequest> GetAll()
    {
        return _items.Where(x => !x.IsDeleted).ToList();
    }


    public ChangeRequest Add(string title, string description)
    {
        var item = new ChangeRequest
        {
            Id = _nextId++,
            Title = title,
            Description = description, 
            Status = ChangeStatus.Open,
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

        item.Status = ChangeStatus.Closed;
        item.UpdatedAt = DateTime.UtcNow;

    }

    public void Reopen(int id)
    {
        var item = _items.FirstOrDefault(x => x.Id == id);
        if(item == null) return;
        
        item.Status = ChangeStatus.Open;
        item.UpdatedAt = DateTime.UtcNow;

    }

    public void UpdateStatus(int id, ChangeStatus status)
    {
        var item = _items.FirstOrDefault(x => x.Id == id);
        if(item == null) return;

        item.Status = status;
        item.UpdatedAt = DateTime.UtcNow;
    }

    public void Update(int id, string title, string descrption)
    {
        var item = _items.FirstOrDefault(x => x.Id == id);
        if(item == null) return;

        item.Title = title;
        item.Description = descrption;
        item.UpdatedAt = DateTime.UtcNow;
    }

    public void Delete(int id)
    {
        var item = _items.FirstOrDefault(x => x.Id == id);
        if(item == null) return;

        item.IsDeleted = true;
        item.UpdatedAt = DateTime.UtcNow;
    }

}