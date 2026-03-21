using Newtonsoft.Json;
using Patterns.Personal.TypeChecker;
using System.Collections;

namespace Patterns.Personal.Serializers;

public class JsonSerializer() : ISerializer
{
    /// <summary>
    /// Convert C# objects to corresponding JSON representation.
    /// </summary>
    /// <param name="rootObject">The object to be serialized.</param>
    /// <returns></returns>
    public string Serialize(object rootObject)
    {
        var stringWriter = new StringWriter();
        using (var writer = new JsonTextWriter(stringWriter)
        {
            Formatting = Newtonsoft.Json.Formatting.Indented,
        })
        {
            writer.WriteStartObject();
            Serialize(rootObject, writer);
            writer.WriteEndObject();
        }

        return stringWriter.ToString();
    }

    private void Serialize(object rootObject, JsonTextWriter writer)
    {
        foreach (var property in rootObject.GetType().GetProperties())
        {
            var value = property.GetValue(rootObject);

            switch (property.PropertyType.GetHighLevelType())
            {
                case HighLevelType.Simple:
                    SerializeSimpleType(writer, value, property.Name);
                    break;
                case HighLevelType.Object:
                    SerializeObject(writer, value, property.Name);
                    break;
                case HighLevelType.Collection:
                    SerializeCollection(writer, value, property.Name);
                    break;
            }
        }

        return;
    }

    private static void SerializeSimpleType(JsonTextWriter writer, object? value, string name)
    {
        writer.WritePropertyName(name);
        writer.WriteValue(value != null
            ? value.ToString()
            : string.Empty);

        return;
    }

    private void SerializeObject(JsonTextWriter writer, object? value, string name)
    {
        if (writer.WriteState != WriteState.Array)
        {
            writer.WritePropertyName(name);
        }
        writer.WriteStartObject();
        if (value != null)
        {
            Serialize(value, writer);
        }
        writer.WriteEndObject();

        return;
    }

    private void SerializeCollection(JsonTextWriter writer, object? value, string name)
    {
        if (value == null)
        {
            return;
        }

        writer.WritePropertyName(name);
        writer.WriteStartArray();
        foreach (var item in (IEnumerable)value)
        {
            SerializeObject(writer, item, item.GetType().Name.ToString());
        }
        writer.WriteEndArray();

        return;
    }
}
