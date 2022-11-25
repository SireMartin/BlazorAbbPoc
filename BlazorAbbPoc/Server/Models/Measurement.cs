namespace BlazorAbbPoc.Server.Models;

public class Measurement
{
    public int Id { get; set; }
    public int DeviceId { get; set; }
    public Device Device { get; set; }
    public DateTimeOffset CreTimestamp { get; set; }

    public int? L1A { get; set; }
    public int? L2A { get; set; }
    public int? L3A { get; set; }
    public int? nA { get; set; }
    public int? L1nV { get; set; }
    public int? L2nV { get; set; }
    public int? L3nV { get; set; }
    public int? L1l2V { get; set; }
    public int? L2l3V { get; set; }
    public int? L3l1V { get; set; }
    public int? PActL1 { get; set; }
    public int? PActL2 { get; set; }
    public int? PActL3 { get; set; }
    public int? PActTotal { get; set; }
    public int? pReactL1 { get; set; }
    public int? pReactL2 { get; set; }
    public int? pReactL3 { get; set; }
    public int? PReactTotal { get; set; }
    public int? PAppL1 { get; set; }
    public int? PAppL2 { get; set; }
    public int? PAppL3 { get; set; }
    public int? PAppTotal { get; set; }
    public int? Frq { get; set; }

    //from plc msg or if not available from device settings
    public int? ProtA_L_I1 { get; set; }
}
