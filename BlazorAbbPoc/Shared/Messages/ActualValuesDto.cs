namespace BlazorAbbPoc.Shared.Messages;

public class ActualValuesDto
{
    //from incoming plc msg
    public int l1A { get; set; }
    public int l2A { get; set; }
    public int l3A { get; set; }
    public int l1nV { get; set; }
    public int l2nV { get; set; }
    public int l3nV { get; set; }
    public int l1l2V { get; set; }
    public int l2l3V { get; set; }
    public int l3l1V { get; set; }
    public int pActTotal { get; set; }
    public int pReactTotal { get; set; }
    public int pAppTotal { get; set; }
    public int frq { get; set; }

    //from plc msg or if not available from device settings
    public int protA_L_I1 { get; set; }
}
