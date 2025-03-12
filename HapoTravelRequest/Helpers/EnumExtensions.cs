using System.Reflection;

namespace HapoTravelRequest.Helpers;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = field.GetCustomAttribute<DisplayAttribute>();

        return attribute == null ? "N/A" : attribute.Name;
    }
}
