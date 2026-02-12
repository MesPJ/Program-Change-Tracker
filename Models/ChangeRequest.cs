namespace ProgramChangeTracker.Models;

public class ChangeRequest
{
    public int Id {get; set;}
    public string Title {get; set;} = "";

    public string Status {get; set;} = "Open";
}