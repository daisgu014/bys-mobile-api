namespace BYS.Mobile.API.Shared.Models.Commons.Responses
{
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
        }

        public int PageSize { get; set; }

        public long RowCount { get; set; }

        public int FirstRowOnPage
        {
            get
            {
                return (CurrentPage - 1) * PageSize + 1;
            }
        }

        public long LastRowOnPage
        {
            get
            {
                return Math.Min(CurrentPage * PageSize, RowCount);
            }
        }
    }
}
