using BlazorAbbPoc.Shared.Messages;
using BlazorAbbPoc.Shared.Plc;

namespace BlazorAbbPoc.Server.Services
{
    public interface IActualValueService
    {
        /// <summary>
        /// Updates the actual value for the device, the key must make the device unique
        /// </summary>
        /// <param name="key"></param>
        /// <param name="abbPlcMsg"></param>
        /// <returns>true if a gap was detected, false if not</returns>
        bool UpdatePlcValues(string key, AbbPlcMsg abbPlcMsg);
        void UpdateSettings(string key, int protA_L_I1);
        void UpdateLatestTimestamp(string key, DateTimeOffset? latestTime);
        ActualValuesDto GetActualValuesForHierarchicalName(string argHierarchicalName);
    }
}