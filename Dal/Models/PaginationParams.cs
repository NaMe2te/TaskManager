namespace Dal.Models;

public class PaginationParams
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    
    public PaginationParams(int pageNumber = 1, int pageSize = 10)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}