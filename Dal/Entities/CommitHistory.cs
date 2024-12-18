using Dal.Entities.BaseEntities;

namespace Dal.Entities;

public class CommitHistory : BaseEntity<long>
{
    public CommitHistory(string branchName, string repositoryOwner, string repositoryName)
    {
        BranchName = branchName;
        RepositoryOwner = repositoryOwner;
        RepositoryName = repositoryName;
    }

    protected CommitHistory() { }
    
    public string BranchName { get; set; }
    public string RepositoryOwner { get; set; }
    public string RepositoryName { get; set; }
}