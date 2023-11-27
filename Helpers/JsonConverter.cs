using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace BoundlessBooks.Helpers;

public static class SessionExtensions
{
    public static T GetObjectFromJson<T>(this ISession session, string key)
    {
        var data = session.GetString(key);
        return data == null ? default(T) : JsonConvert.DeserializeObject<T>(data);
    }

    public static void SetObjectAsJson(this ISession session, string key, object value)
    {
        session.SetString(key, JsonConvert.SerializeObject(value));
    }
}
