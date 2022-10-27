namespace BlazorAbbPoc.Server.Models;

public class Cabinet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CabinetGroupId { get; set; }
    public CabinetGroup CabinetGroup { get; set; }
    public virtual IList<Device> Devices { get; set; }
}
