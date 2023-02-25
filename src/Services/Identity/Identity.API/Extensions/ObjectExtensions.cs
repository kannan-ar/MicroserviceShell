using System.Text.Json;

namespace Identity.API.Extensions
{
    public static class ObjectExtensions
    {
        public static T DeepClone<T>(this T obj)
        {
            var serializedString = JsonSerializer.Serialize(obj);
            return JsonSerializer.Deserialize<T>(serializedString);
        }
    }
}
