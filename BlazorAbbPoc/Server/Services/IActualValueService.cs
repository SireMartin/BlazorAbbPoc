using BlazorAbbPoc.Shared.Messages;
using BlazorAbbPoc.Shared.Plc;

namespace BlazorAbbPoc.Server.Services
{
    public interface IActualValueService
    {
        void UpdatePlcValues(string key, AbbPlcMsg abbPlcMsg);
        void UpdateSettings(string key, int protA_L_I1);
        ActualValuesDto GetActualValuesForHierarchicalName(string argHierarchicalName);
    }
}