using Patterns.Personal.Serializers.Concept;
using Patterns.Personal.TypeChecker.Concept;
using System.Collections;
using System.Text;
using System.Xml;

namespace Patterns.Personal.Serializers.Examples;

public class XmlSerializer(XmlWriterSettings settings, CollectionSerializationMode collectionMode) : ISerializer
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

        // Stop recursion for simple types
        if (type.GetHighLevelType() == HighLevelType.Simple)
        {
            SerializeSimpleType(writer, rootObject, rootObject.GetType().Name);
            return;
        }

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

        if (collectionMode == CollectionSerializationMode.SingleObjectInEmptyCollection
            && !((IEnumerable)value).Cast<object>().Any())
        {
            SerializeEmptyCollectionObject(writer, value);
        }

        // Filled collection
        foreach (var item in (ICollection)value)
        {
            writer.WriteStartElement(item.GetType().Name);
            Serialize(item, writer);
            writer.WriteEndElement();
        }

        writer.WriteEndElement();

        return;
    }

    private void SerializeEmptyCollectionObject(XmlWriter writer, object value)
    {
        if (TypeChecker.Concept.TypeChecker.GetCollectionElementType(value.GetType()) is not Type elementType)
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
}
