using BlazorAbbPoc.Shared;

namespace BlazorAbbPoc.Server.Services;
public class DataService
{
    public Dictionary<string, List<(DateTime, AbbPlcMsg)>> PlcTimedData { get; set; } = new();
    public Dictionary<string, AbbPlcMsg> PlcData { get; set; } = new();
}
