using Cash.BE.Helpers;

namespace Cash.BE.Request;

public class FilterField
{
    public string FieldName { get; set; } = null!;
    public string? FieldValue { get; set; }
    public Allowedfilter Method { get; set; }
    public List<string>? FieldValues { get; set; }
}