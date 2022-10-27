namespace BlazorAbbPoc.Server.Models;

public class DeviceType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IList<Device> Devices { get; set; }
}
