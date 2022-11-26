namespace BlazorAbbPoc.Server.Services
{
    public interface IHierarchicalNameService
    {
        string GetHierarchicalNameForPlcDeviceId(string plcDeviceId);
        string GetPlcDeviceIdForHierarchicalName(string hierarchicalName);
        void Initialize();
    }
}