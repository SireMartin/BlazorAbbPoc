using BlazorAbbPoc.Server.Models;
using BlazorAbbPoc.Shared.Plc;
using Fluxor;

namespace BlazorAbbPoc.Server.Services;

public class PlcMsgDispatcher
{
    private readonly IDispatcher _dispatcher;
    private readonly ILogger _logger;
    private readonly ApiDbContext _dbContext;

    public PlcMsgDispatcher(IDispatcher dispatcher, ApiDbContext dbContext, ILogger<PlcMsgDispatcher> logger)
    {
        _dispatcher = dispatcher;
        _dbContext = dbContext;
        _logger = logger;
    }

    public void DispatchPlcMsg(AbbPlcMsg argMsg)
    {
        //if a message contains a setting value (f.e. ProtecA_L_I1), this has to be dispatched to the store because it is a change in config
        if (argMsg?.ProtA_L_I1 is not null)
        {

        }
    }
}
