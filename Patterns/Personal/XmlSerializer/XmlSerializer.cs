using Patterns.Personal.TypeChecker;
using System.Collections;
using System.Text;
using System.Xml;

namespace Patterns.Personal.XmlSerializer;

public class XmlSerializer(XmlWriterSettings settings)
{
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

            if (property.PropertyType.IsCollectionType())
            {
                SerializeCollection(writer, value, property.Name);
            }
            else if (property.PropertyType.IsObjectType())
            {
                SerializeObject(writer, value, property.Name);
            }
            else if (property.PropertyType.IsSimpleType())
            {
                SerializeSimpleType(writer, value, property.Name);
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
