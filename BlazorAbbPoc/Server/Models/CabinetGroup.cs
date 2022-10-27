namespace BlazorAbbPoc.Server.Models;

public class CabinetGroup
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual IList<Cabinet> Cabinets{ get; set; }
}