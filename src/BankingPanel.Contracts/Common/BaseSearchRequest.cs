namespace BankingPanel.Contracts.Client.Query;

public abstract record BaseSearchRequest
{
     /// <summary>
    /// The text to search for.
    /// </summary>
    public string SearchText { get; set; } = string.Empty;

    /// <summary>
    /// The field by which to sort.
    /// </summary>
    public string SortBy { get; set; } = string.Empty;

    /// <summary>
    /// Indicates if the sorting should be ascending or descending.
    /// </summary>
    public bool SortDescending { get; set; } = false;

    /// <summary>
    /// The size of the page (number of items per page).
    /// </summary>
    public int PageSize { get; set; } = 10;

    /// <summary>
    /// The index of the page to retrieve (0-based index).
    /// </summary>
    public int PageNumber { get; set; } = 0;



}