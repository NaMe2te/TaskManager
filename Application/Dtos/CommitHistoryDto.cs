namespace Application.Dtos;

public class CommitHistoryDto
{
    public string BranchName { get; set; }
    public string RepositoryOwner { get; set; }
    public string RepositoryName { get; set; }
}