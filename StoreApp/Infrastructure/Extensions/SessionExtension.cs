using System.Text.Json;
using Microsoft.AspNetCore.Http.Features;

namespace StoreApp.Infrastructure.Extensions;

public static class SessionExtension
{
    public static void SetJson(this ISession session, string key, object value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }

    public static T? GetJson<T>(this ISession session, string key)
    {
        var data = session.GetString(key);
        return data is null
        ? default
        : JsonSerializer.Deserialize<T>(data);
    }
}