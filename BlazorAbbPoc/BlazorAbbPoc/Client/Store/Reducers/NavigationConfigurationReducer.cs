using BlazorAbbPoc.Client.Store.Actions;
using Fluxor;

namespace BlazorAbbPoc.Client.Store.Reducers;

public static class NavigationConfigurationReducer
{
    [ReducerMethod]
    public static NavigationConfigurationState ReduceNavigationConfigurationChangedAction(NavigationConfigurationState state, NavigationConfigurationChangedAction action)
    {
        NavigationConfigurationState navigationConfigurationState = new();
        action.RootNavItem.FillItems(navigationConfigurationState.Cont);
        return navigationConfigurationState;
    }
}
