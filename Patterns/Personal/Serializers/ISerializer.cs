namespace Patterns.Personal.Serializers;

public interface ISerializer
{
    string Serialize(object rootObject);
}