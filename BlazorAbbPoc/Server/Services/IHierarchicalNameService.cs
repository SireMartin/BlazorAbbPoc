namespace BlazorAbbPoc.Server.Services
{
    public interface IHierarchicalNameService
    {
        string GetHierarchicalNameForPlcDeviceId(string plcDeviceId);
        void Initialize();
    }
}