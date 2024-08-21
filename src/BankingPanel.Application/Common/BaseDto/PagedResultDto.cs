public class PagedResultDto<T>
{
    public IEnumerable<T> Data { get; set; } // The actual data (e.g., list of items)
    public int PageNumber { get; set; } // Current page number
    public int PageSize { get; set; } // Number of items per page
    public int TotalPages { get; set; } // Total number of pages
    public int TotalRecords { get; set; } // Total number of records
  
    public PagedResultDto(IEnumerable<T> data, int pageNumber, int pageSize, int totalRecords)
    {
        Data = data;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalRecords = totalRecords;
        TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
    }
}