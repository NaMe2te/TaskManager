using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class Comment : TrackableEntity<int>
{
    public string Text { get; set; }

    public int TaskId { get; set; }
    public Task Task { get; set; }
    
    public int CommentedBy { get; set; }
    public User Commenter { get; set; }
}