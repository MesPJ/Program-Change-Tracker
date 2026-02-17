namespace ProgramChangeTracker.Models;

public class ChangeRequest
{
    public int Id {get; set;}
    public string Title {get; set;} = "";
    public string Description {get; set;} = "";
    public string Status {get; set;} = "Open";
    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
    public DateTime UpdatedAt {get; set;} = DateTime.UtcNow;
}