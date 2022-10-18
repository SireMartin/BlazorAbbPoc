using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorAbbPoc.Shared;

public class AbbPlcMsg
{
    [JsonPropertyName("RK0-1")]
    public string? RK01 { get; set; }
    public int Commands { get; set; }
    public int ContactWear { get; set; }
    [JsonPropertyName("Nr of CB Operations")]
    public int NrofCBOperations { get; set; }
    public int NrofCBmanualopenings { get; set; }
    public int NrofCBprotectiontrips { get; set; }
    public int NrofCBprotectiontripfails { get; set; }
    public int NrofCBprotectiontriptest { get; set; }
    public int ProgrammingFailerrorcode { get; set; }
    public int L1current { get; set; }
    public int L2current { get; set; }
    public int L3current { get; set; }
    public int Necurrent { get; set; }
    public int Internalgroundcurrent { get; set; }
    [JsonPropertyName("External ground current\\/Rc current")]
    public int ExternalgroundcurrentRccurrent { get; set; }
    public int L1NVoltage { get; set; }
    public int L2NVoltage { get; set; }
    public int L3NVoltage { get; set; }
    public int L1L2Voltage { get; set; }
    public int L2L3Voltage { get; set; }
    public int L3L1Voltage { get; set; }
    public int ActivepowerL1 { get; set; }
    public int ActivepowerL2 { get; set; }
    public int ActivepowerL3 { get; set; }
    public int ActivepowerTotal { get; set; }
    public int ReactivepowerL1 { get; set; }
    public int ReactivepowerL2 { get; set; }
    public int ReactivepowerL3 { get; set; }
    public int ReactivepowerTotal { get; set; }
    public int ApparentpowerL1 { get; set; }
    public int ApparentpowerL2 { get; set; }
    public int ApparentpowerL3 { get; set; }
    public int ApparentpowerTotal { get; set; }
    public int PowerFactorL1 { get; set; }
    public int PowerFactorL2 { get; set; }
    public int PowerFactorL3 { get; set; }
    public int PowerFactorTotal { get; set; }
    public int Frequency { get; set; }
    [JsonPropertyName("loadProfile 0-49% In")]
    public int loadProfile049In { get; set; }
    public int loadProfile5079In { get; set; }
    public int loadProfile7989In { get; set; }
    public int loadProfile90In { get; set; }
    public int ActiveEnergyPositive { get; set; }
    public int ActiveEnergyNegative { get; set; }
    public int ActiveEnergyTotal { get; set; }
    public int ReactiveEnergyPositive { get; set; }
    public int ReactiveEnergyNegative { get; set; }
    public int ReactiveEnergyTotal { get; set; }
    public int ApparentEnergyTotal { get; set; }
    public int EnergyStoreTime { get; set; }
    public int TotalHarmonicDistorsion { get; set; }
    [JsonPropertyName("1th Harmonic")]
    public int _1thHarmonic { get; set; }
    public int _2thHarmonic { get; set; }
    public int _3thHarmonic { get; set; }
    public int _4thHarmonic { get; set; }
    public int _5thHarmonic { get; set; }
    public int _6thHarmonic { get; set; }
    public int _7thHarmonic { get; set; }
    public int _8thHarmonic { get; set; }
    public int _9thHarmonic { get; set; }
    public int _10thHarmonic { get; set; }
    public int _11thHarmonic { get; set; }
    public int _12thHarmonic { get; set; }
    public int _13thHarmonic { get; set; }
    public int _14thHarmonic { get; set; }
    public int _15thHarmonic { get; set; }
    public int _16thHarmonic { get; set; }
    public int _17thHarmonic { get; set; }
    public int _18thHarmonic { get; set; }
    public int _19thHarmonic { get; set; }
    public int _20thHarmonic { get; set; }
    public int _21thHarmonic { get; set; }
    public int _22thHarmonic { get; set; }
    public int _23thHarmonic { get; set; }
    public int _24thHarmonic { get; set; }
    public int _25thHarmonic { get; set; }
    public int _26thHarmonic { get; set; }
    public int _27thHarmonic { get; set; }
    public int _28thHarmonic { get; set; }
    public int _29thHarmonic { get; set; }
    public int _30thHarmonic { get; set; }
    public int _31thHarmonic { get; set; }
    public int _32thHarmonic { get; set; }
    public int _33thHarmonic { get; set; }
    public int _34thHarmonic { get; set; }
    public int _35thHarmonic { get; set; }
    public int _36thHarmonic { get; set; }
    public int _37thHarmonic { get; set; }
    public int _38thHarmonic { get; set; }
    public int _39thHarmonic { get; set; }
    public int _40thHarmonic { get; set; }
    public int _41thHarmonic { get; set; }
    public int _42thHarmonic { get; set; }
    public int _43thHarmonic { get; set; }
    public int _44thHarmonic { get; set; }
    public int _45thHarmonic { get; set; }
    public int _46thHarmonic { get; set; }
    public int _47thHarmonic { get; set; }
    public int _48thHarmonic { get; set; }
    public int _49thHarmonic { get; set; }
    public int _50thHarmonic { get; set; }
    public int ProtectA_L_Config { get; set; }
    public int ProtectA_L_I1 { get; set; }
    public int ProtectA_L_t1 { get; set; }
    public int ProtectA_L_Curve { get; set; }
    public int ProtectA_L_PrealarmI1 { get; set; }
    public int ProtectA_S_Config { get; set; }
    public int ProtectA_S_I2 { get; set; }
    public int ProtectA_S_t2 { get; set; }
    public int ProtectA_S_I22 { get; set; }
    public int ProtectA_S_t22 { get; set; }
    public int ProtectA_S_Curve { get; set; }
    public int ProtectA_S_ZoneSelectT { get; set; }
    public int ProtectA_I_Config { get; set; }
    public int ProtectA_I_I3 { get; set; }
    public int ProtectB_L_Config { get; set; }
    public int ProtectB_L_I1 { get; set; }
    public int ProtectB_L_t1 { get; set; }
    public int ProtectB_L_Curve { get; set; }
    public int ProtectB_L_PrealarmI1 { get; set; }
    public int ProtectB_S_Config { get; set; }
    public int ProtectB_S_I2 { get; set; }
    public int ProtectB_S_t2 { get; set; }
    public int ProtectB_S_I22 { get; set; }
    public int ProtectB_S_t22 { get; set; }
    public int ProtectB_S_Curve { get; set; }
    public int ProtectB_S_ZoneSelectT { get; set; }
    public int ProtectB_I_Config { get; set; }
    public int ProtectB_I_I3 { get; set; }
    public string? Timestamp { get; set; }
    public string? Alarm1 { get; set; }
    public string? Alarm2 { get; set; }
    public float rms1 { get; set; }
}
