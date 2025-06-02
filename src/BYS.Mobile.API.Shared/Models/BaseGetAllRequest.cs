using BYS.Mobile.API.Shared.Constants;
using System.ComponentModel;

namespace BYS.Mobile.API.Share.Request
{
    public class BaseGetAllRequest
    {
        [DefaultValue(100)]
        public int PageSize { get; set; } = 100;
        [DefaultValue(1)]
        public int PageIndex { get; set; } = 1;
        public string Filter { get; set; }
        public int? Skip { get; set; }
        [DefaultValue("CreatedAt")]
        public string SortField { get; set; } = "CreatedAt";
        [DefaultValue(false)]
        public bool? Asc { get; set; } = false;

        public void EnsusePagingIsValid()
        {
            if (this.PageIndex < 0)
            {
                this.PageIndex = 0;
            }

            if (this.PageSize < 1)
            {
                this.PageSize = Constant.MinPageSizeValue;
            }
        }
    }
}

