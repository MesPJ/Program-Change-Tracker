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

    public ChangesModel(ChangeRequestService service)
    {
        _service = service;
    }

    public List<ChangeRequest> Items {get; private set;} = new();

    public void OnGet()
    {
        Items = _service.GetAll();
    }
    public IActionResult OnPost()
    {
        if (string.IsNullOrWhiteSpace(Title))
        {
            
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
}