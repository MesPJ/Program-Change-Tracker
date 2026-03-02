using Microsoft.AspNetCore.Mvc.RazorPages;
using ProgramChangeTracker.Models;
using ProgramChangeTracker.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace ProgramChangeTracker.Pages;

public class ChangesModel : PageModel
{
       
    private readonly ChangeRequestService _service;

    [BindProperty] //binds variable to post from form
    public string Title {get; set;} = "";

    [BindProperty]
    public string Description {get; set;} = "";

    [BindProperty]
    public int Id {get; set;}

    [BindProperty]
    public ChangeStatus Status {get; set;}

    public string? ErrorMessage {get; private set;}

    public int? EditId {get; private set;}

    public ChangesModel(ChangeRequestService service)
    {
        _service = service;
    }

    public List<ChangeRequest> Items {get; private set;} = new();

    public void OnGet(int? editId)
    {
        EditId = editId;        
        Items = _service.GetAll();
    }
    public IActionResult OnPost()
    {
        if (string.IsNullOrWhiteSpace(Title))
        {
            ErrorMessage = "Title is required.";
            Items = _service.GetAll();
            return Page();
        }

        _service.Add(Title, Description);
        return RedirectToPage();
    }

    public IActionResult OnPostClose()
    {
        _service.Close(Id);
        return RedirectToPage();
    }

    public IActionResult OnPostReopen()
    {
        _service.Reopen(Id);
        return RedirectToPage();
    }

    public IActionResult OnPostUpdateStatus()
    {
        _service.UpdateStatus(Id, Status);
        return RedirectToPage();
    }

    public IActionResult OnPostSaveEdit()
    {
        if (string.IsNullOrWhiteSpace(Title))
        {
            ErrorMessage = "Title is required.";
            Items = _service.GetAll();
            EditId = Id;
            return Page();
        }

        _service.Update(Id, Title, Description);
        return RedirectToPage();
    }

    public IActionResult OnPostDelete()
    {
        _service.Delete(Id);
        return RedirectToPage();
    }
}