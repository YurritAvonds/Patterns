namespace Patterns.Personal.XmlSerializer;

public interface ISerializer
{
    string Serialize(object rootObject);
}