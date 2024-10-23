using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class Comment : SoftDeletableEntity<long>
{
    public Comment(string text, long taskId, long commentedBy)
    {
        Text = text;
        TaskId = taskId;
        CommentedBy = commentedBy;
    }
    
    protected Comment() { }

    public string Text { get; set; }

    public long TaskId { get; set; }
    public Task Task { get; set; }
    
    public long CommentedBy { get; set; }
    public User Commenter { get; set; }
}