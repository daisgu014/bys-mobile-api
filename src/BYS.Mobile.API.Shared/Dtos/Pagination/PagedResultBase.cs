namespace BYS.Mobile.API.Shared.Dtos.Pagination;

public abstract class PagedResultBase
{
    public int CurrentPage { get; set; }

    public int PageCount
    {
        get
        {
            if (PageSize == 0) return 1;

            var pageCount = (double)RowCount / PageSize;
            return (int)Math.Ceiling(pageCount);
        }
        set { PageCount = value; }
    }

    public int PageSize { get; set; }

    public int RowCount { get; set; }

    public int TotalElement { get; set; }

    public int FirstRowOnPage
    {
        get
        {
            return (CurrentPage - 1) * PageSize + 1;
        }
    }

    public int LastRowOnPage
    {
        get
        {
            return Math.Min(CurrentPage * PageSize, RowCount);
        }
    }
}