namespace BYS.Mobile.API.Shared.Response;

public class ProductResponse
{
    public int IcproductId { get; set; }
    /// <summary>
    /// Mã mặt hàng
    /// </summary>
    public string ItemNo { get; set; }
    /// <summary>
    /// Tên mặt hàng
    /// </summary>
    public string ItemName { get; set; }

    /// <summary>
    /// Loại gỗ (Wood)
    /// </summary>
    public string Wood { get; set; }

    /// <summary>
    /// Đường dẫn hoặc tên file hình (Picture)
    /// </summary>
    public string Picture { get; set; }

    /// <summary>
    /// Kích thước (mm)
    /// </summary>
    public string SizeMm { get; set; }

    /// <summary>
    /// SOQ (pcs/sets)
    /// </summary>
    public decimal? SoqPcsSets { get; set; }

    /// <summary>
    /// Quy cách đóng gói
    /// </summary>
    public string Packing { get; set; }

    /// <summary>
    /// Giá cho số lượng trên SOQ
    /// </summary>
    public decimal AboveSoq { get; set; }

    /// <summary>
    /// Giá cho số lượng dưới SOQ
    /// </summary>
    public decimal BelowSoq { get; set; }

    /// <summary>
    /// Số lượng trên container 20 feet
    /// </summary>
    public int QuantityPer20Ft { get; set; }

    /// <summary>
    /// Trọng lượng mỗi mặt hàng (kg)
    /// </summary>
    public decimal ItemWeightKgs { get; set; }
}
