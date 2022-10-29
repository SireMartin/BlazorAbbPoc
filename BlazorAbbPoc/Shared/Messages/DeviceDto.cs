namespace BlazorAbbPoc.Shared.Messages;

public class DeviceDto
{
    public int Id { get; set; }
    public string DeviceId { get; set; }
    public int DeviceTypeId { get; set; }
    public int CabinetId { get; set; }
    public int? CabinetGroupId { get; set; }    //only provided in the http get call to be able to present in the grid
    public int MaxValue { get; set; }
    public int CabinetPosition { get; set; }
}
