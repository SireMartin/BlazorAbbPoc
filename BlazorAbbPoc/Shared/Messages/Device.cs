namespace BlazorAbbPoc.Shared.Messages;

public class Device
{
    public int Id { get; set; }
    public string DeviceId { get; set; }
    public int DeviceTypeId { get; set; }
    public int CabinetId { get; set; }
    public int CabinetGroupId { get; set; }
    public int MaxValue { get; set; }
    public int CabinetPosition { get; set; }
}
