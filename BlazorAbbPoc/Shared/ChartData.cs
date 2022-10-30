using BlazorAbbPoc.Shared.Plc;

namespace BlazorAbbPoc.Shared;

public class ChartData
{
    public DateTime timestamp { get; set; }
    public AbbPlcMsg? plcMsg { get; set; }
}
