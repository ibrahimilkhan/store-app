using System.Text.Json;

namespace StoreApp.Infrastructure.Extensions;

public static class SessionExtension
{
    public static void SetJson(this ISession session, string key, object value)
    {
        session.SetString(key, JsonSerializer.Deserialize<string>(value));

    }
}