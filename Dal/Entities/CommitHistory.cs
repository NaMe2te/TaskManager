using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class CommitHistory : TrackableEntity<long>
{
    public CommitHistory(string commitHash, DateTime commitDate, int commitNumber, long authorId, long taskId)
    {
        CommitHash = commitHash;
        CommitDate = commitDate;
        CommitNumber = commitNumber;
        AuthorId = authorId;
        TaskId = taskId;
    }
    
    protected CommitHistory() { }
    
    public string CommitHash { get; set; }
    public DateTime CommitDate { get; set; }
    public int CommitNumber { get; set; }

    public long AuthorId { get; set; }
    public User Author { get; set; }
    
    public long TaskId { get; set; }
    public Task Task { get; set; }
}