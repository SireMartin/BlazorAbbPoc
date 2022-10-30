using System.Runtime.CompilerServices;

namespace BlazorAbbPoc.Client.Data;

public class NavItem
{
    public string itemId { get; set; }
    public string pageType { get; set; }
    public NavItem[] items { get; set; }

    public void FillItems(Dictionary<string, NavItem[]> argColl, string? argParentItemId = null)
    {
        string? hierarchicalItemId = null;
        if (itemId is not null) //not the root item
        {
            hierarchicalItemId = argParentItemId is null ? itemId : $"{argParentItemId}/{itemId}";
            argColl[hierarchicalItemId] = (items ?? Array.Empty<NavItem>()).Select(x => new NavItem { itemId = $"{hierarchicalItemId}/{x.itemId}", pageType = x.pageType }).ToArray();
        }
        //else
        //{
        //    foreach (var item in items)
        //    {
        //        argColl["root"] = (items ?? Array.Empty<NavItem>()).Select(x => new NavItem { itemId = x.itemId, pageType = "navigation" }).ToArray();
        //    }
        //}
        foreach (var item in items ?? Array.Empty<NavItem>())
        {
            item.FillItems(argColl, hierarchicalItemId);
        }
    }
}
