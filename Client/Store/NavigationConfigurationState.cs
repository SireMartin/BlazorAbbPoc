using Fluxor;
using BlazorAbbPoc.Client.Data;

namespace BlazorAbbPoc.Client.Store;

[FeatureState]
public class NavigationConfigurationState
{
    public Dictionary<string, NavItem[]> Cont { get; set; } = new();

    public NavigationConfigurationState() { }
}
