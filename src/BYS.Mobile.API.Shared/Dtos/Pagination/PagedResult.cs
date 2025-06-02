using Newtonsoft.Json;

namespace BYS.Mobile.API.Shared.Dtos.Pagination;

public class PagedResult<T> : PagedResultBase where T : class
{
    public PagedResult()
    {
        Results = new List<T>();
    }

    public IList<T> Results { get; set; }
}

public class PagedRubyResult<T> where T : class
{
    [JsonProperty("data")]
    public IList<T> Data { get; set; }
    [JsonProperty("meta")]
    public PagedRubyMetadata Meta { get; set; }
    public int Code { get; set; }
    public int Status { get; set; }
    public string Message { get; set; }
}
public class PagedRubyMetadata
{
    [JsonProperty("currentPage")]
    public int CurrentPage { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("totalItems")]
    public int TotalItems { get; set; }
    [JsonProperty("totalPages")]
    public int TotalPages { get; set; }
}