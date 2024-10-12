namespace Dal.Entities;

public class CommitHistory
{
    public int CommitId { get; set; }
    public string CommitHash { get; set; }
    public DateTime CommitDate { get; set; } = DateTime.Now;
    public int AuthorId { get; set; }
    public int CommitNumber { get; set; }
    public int TaskId { get; set; }

    public virtual User Author { get; set; }
    public Task Task { get; set; }
}