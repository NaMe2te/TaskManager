namespace Application.Dtos;

public class CommitHistoryDto
{
    public long Id { get; set; }
    public string BranchName { get; set; }
    public string RepositoryOwner { get; set; }
    public string RepositoryName { get; set; }
}