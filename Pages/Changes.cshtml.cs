using Microsoft.AspNetCore.Mvc.RazorPages;
using ProgramChangeTracker.Models;
using ProgramChangeTracker.Services;

namespace ProgramChangeTracker.Pages;

public class ChangesModel : PageModel
{
    private readonly ChangeRequestService _service;

    public ChangesModel(ChangeRequestService service)
    {
        _service = service;
    }

    public List<ChangeRequest> Items {get; private set;} = new();

    public void OnGet()
    {
        Items = _service.GetAll();
    }
}