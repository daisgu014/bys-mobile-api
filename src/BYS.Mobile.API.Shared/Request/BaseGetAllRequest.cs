namespace BYS.Mobile.API.Shared.Request;

public class BaseGetAllRequest
{
    public int PageSize { get; set; }
    public int PageIndex { get; set; }
    public string Filter { get; set; }
    public int? Skip { get; set; }
    public string SortField { get; set; }
    public bool? Asc { get; set; }
}
public class BaseGetAllRequest<TFilter>
    where TFilter : class
{
    public int PageSize { get; set; }
    public int PageIndex { get; set; }
    public TFilter? Filter { get; set; }
    public int? Skip { get; set; }
    public string SortField { get; set; }
    public bool? Asc { get; set; }
}