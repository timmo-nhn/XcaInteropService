namespace XcaInteropService.Commons.Models.Custom.RestfulRegistry;

public class Pagination
{
    public int? Next { get; set; }
    public int? Prev { get; set; }
    public int TotalResults { get; set; }
    public int PageNumber { get; set; }
    public int NumberOfResults { get; set; }
    public int LastPage { get; set; }
}