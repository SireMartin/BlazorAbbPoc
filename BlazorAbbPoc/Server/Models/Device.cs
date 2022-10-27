namespace BlazorAbbPoc.Server.Models;

public class Device
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PlcDeviceId  { get; set; }
    public int DeviceTypeId { get; set; }
    public DeviceType DeviceType { get; set; }
    public int MaxValue { get; set; }
    public int CabinetId { get; set; }
    public Cabinet Cabinet { get; set; }
    public int CabinetPosition { get; set; }
}
