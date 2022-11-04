using BlazorAbbPoc.Shared.Plc;

namespace BlazorAbbPoc.Server.Services
{
    public interface IPlcMsgDispatcher
    {
        Task DispatchPlcMsg(AbbPlcMsg argMsg);
        void Initialize();
    }
}