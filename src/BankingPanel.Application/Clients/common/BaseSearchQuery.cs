namespace BankingPanel.Application.Clients.common;

public record BaseSearchQuery
{
    public string SearchText { get; set; }

    /// <summary>
    /// The field by which to sort.
    /// </summary>
    public string SortBy { get; set; }

    /// <summary>
    /// Indicates if the sorting should be ascending or descending.
    /// </summary>
    public bool SortDescending { get; set; }

    /// <summary>
    /// The size of the page (number of items per page).
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// The index of the page to retrieve (0-based index).
    /// </summary>
    public int PageNumber { get; set; }
}