using Patterns.Personal.TypeChecker;
using System.Collections;
using System.Text;
using System.Xml;

namespace Patterns.Personal.Serializers;

public class XmlSerializer(XmlWriterSettings settings) : ISerializer
{
    /// <summary>
    /// Convert C# objects to corresponding XML representation.
    /// </summary>
    /// <param name="rootObject">The object to be serialized.</param>
    /// <returns></returns>
    public string Serialize(object rootObject)
    {
        var stringBuilder = new StringBuilder();
        using (var writer = XmlWriter.Create(stringBuilder, settings))
        {
            writer.WriteStartElement(rootObject.GetType().Name);
            Serialize(rootObject, writer);
            writer.WriteEndElement();
        }

        return stringBuilder.ToString();
    }

    private void Serialize(object rootObject, XmlWriter writer)
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

    private static void SerializeSimpleType(XmlWriter writer, object? value, string name)
    {
        writer.WriteStartElement(name);
        if (value != null)
        {
            writer.WriteString(value.ToString());
        }
        writer.WriteEndElement();

        return;
    }

    private void SerializeObject(XmlWriter writer, object? value, string name)
    {
        writer.WriteStartElement(name);
        if (value != null)
        {
            Serialize(value, writer);
        }
        writer.WriteEndElement();

        return;
    }

    private void SerializeCollection(XmlWriter writer, object? value, string name)
    {
        if (value == null)
        {
            return;
        }

        writer.WriteStartElement(name);
        foreach (var item in (IEnumerable)value)
        {
            SerializeObject(writer, item, item.GetType().Name.ToString());
        }
        writer.WriteEndElement();

        return;
    }
}
