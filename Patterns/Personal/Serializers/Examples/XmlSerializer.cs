using Patterns.Personal.Serializers.Concept;
using Patterns.Personal.TypeChecker.Concept;
using System.Collections;
using System.Text;
using System.Xml;

namespace Patterns.Personal.Serializers.Examples;

public class XmlSerializer(XmlWriterSettings settings, NullOrEmptyMode nullOrEmptyMode) : ISerializer
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
        var type = rootObject.GetType();

        // For simple types, immediately serialize and stop further processing
        if (type.GetHighLevelType() == HighLevelType.Simple)
        {
            SerializeSimpleType(writer, rootObject, rootObject.GetType().Name);
            return;
        }

        // Serialize object properties
        foreach (var property in rootObject.GetType()
            .GetProperties()
            .Where(p => p.SetMethod?.IsPublic == true))
        {
            var value = property.GetValue(rootObject);

            switch (property.PropertyType.GetHighLevelType())
            {
                case HighLevelType.Simple:
                    SerializeSimpleType(writer, value, property.Name);
                    break;
                case HighLevelType.Object:
                    SerializeObject(writer, value, property.PropertyType, property.Name);
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
        if (value != null) // TODO what if value is whitespace string?
        {
            var text = value switch
            {
                DateTimeOffset dto => dto.ToString("yyyy-MM-dd HH:mm:ss zzz"),
                DateTime dt => dt.ToString("yyyy-MM-dd HH:mm:ss"),
                DateOnly d => d.ToString("yyyy-MM-dd"),
                TimeOnly t => t.ToString("HH:mm:ss zzz"),
                _ => value.ToString()
            };

            writer.WriteString(text);
        }
        writer.WriteEndElement();

        return;
    }

    private void SerializeObject(XmlWriter writer, object? value, Type type, string name)
    {
        writer.WriteStartElement(name);

        // Null object
        if (nullOrEmptyMode == NullOrEmptyMode.SerializeEmptyExample
            && value == null)
        {
            SerializeEmptyExampleObject(writer, type);
        }
        // Initialized object
        else if (value != null)
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

        // Empty collection
        if (nullOrEmptyMode == NullOrEmptyMode.SerializeEmptyExample
            && !((IEnumerable)value).Cast<object>().Any())
        {
            SerializeEmptyCollectionObject(writer, (ICollection)value);
        }
        else
        {
            // Filled collection
            foreach (var item in (ICollection)value)
            {
                if (item.GetType().Equals(typeof(string)))
                {
                    Serialize(item, writer);
                }
                else
                {
                    writer.WriteStartElement(item.GetType().Name);
                    Serialize(item, writer);
                    writer.WriteEndElement();
                }
            }
        }

        writer.WriteEndElement();

        return;
    }

    private void SerializeEmptyCollectionObject(XmlWriter writer, ICollection collection)
    {
        if (TypeChecker.Concept.TypeChecker.GetCollectionElementType(collection.GetType())
            is not Type elementType)
        {
            return;
        }

        if (elementType.Equals(typeof(string)))
        {
            writer.WriteStartElement(nameof(String));
            writer.WriteEndElement();
            return;
        }

        if (Activator.CreateInstance(elementType) is object instance)
        {
            writer.WriteStartElement(instance.GetType().Name);
            Serialize(instance, writer);
            writer.WriteEndElement();
        }
    }

    private void SerializeEmptyExampleObject(XmlWriter writer, Type type)
    {
        if (type != null
            && Activator.CreateInstance(type) is object instance)
        {
            Serialize(instance, writer);
        }
    }
}
