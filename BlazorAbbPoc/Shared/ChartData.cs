using BlazorAbbPoc.Shared.Plc;

namespace BlazorAbbPoc.Shared;

public class ChartData
{
    public DateTime timestamp { get; set; }
    public int? l1Voltage { get; set; }
    public int? l2Voltage { get; set; }
    public int? l3Voltage { get; set; }
}
