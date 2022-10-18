using BlazorAbbPoc.Client.Data;

namespace BlazorAbbPoc.Client.Store.Actions;

public class NavigationConfigurationChangedAction
{
    public NavItem? RootNavItem { get; init; }

    public NavigationConfigurationChangedAction(NavItem? argRootNavItem)
    {
        RootNavItem = argRootNavItem;
    }
}
