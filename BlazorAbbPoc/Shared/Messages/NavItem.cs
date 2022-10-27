using System.Runtime.CompilerServices;

namespace BlazorAbbPoc.Shared.Messages;

public class NavItem
{
    public string itemId { get; set; }
    public string pageType { get; set; }
    public NavItem[] items { get; set; }
}
