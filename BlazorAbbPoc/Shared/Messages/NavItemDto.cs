using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace BlazorAbbPoc.Shared.Messages;

public class NavItemDto
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? itemId { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? pageType { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IEnumerable<NavItemDto>? items { get; set; }
}
