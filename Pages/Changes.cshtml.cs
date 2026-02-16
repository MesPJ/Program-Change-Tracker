using Microsoft.AspNetCore.Mvc.RazorPages;
using ProgramChangeTracker.Models;
using ProgramChangeTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProgramChangeTracker.Pages;

public class ChangesModel : PageModel
{
       
    private readonly ChangeRequestService _service;

    [BindProperty] //binds variable to post from form
    public string Title {get; set;} = "";

    public ChangesModel(ChangeRequestService service)
    {
        _service = service;
    }

    public List<ChangeRequest> Items {get; private set;} = new();

    public void OnGet()
    {
        Items = _service.GetAll();
    }
    public Microsoft.AspNetCore.Mvc.IActionResult OnPost()
    {
        if (string.IsNullOrWhiteSpace(Title))
        {
            
            Items = _service.GetAll();
            return Page();
        }

        _service.Add(Title);
        return RedirectToPage();
    }
}