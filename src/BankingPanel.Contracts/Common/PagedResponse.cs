namespace BankingPanel.Contracts.Common;
public class PagedResponse<T>
{
    public IEnumerable<T> Data { get; set; } // The actual data (e.g., list of items)
    public int PageNumber { get; set; } // Current page number
    public int PageSize { get; set; } // Number of items per page
    public int TotalPages { get; set; } // Total number of pages
    public int TotalRecords { get; set; } // Total number of records

}