namespace Patterns.Personal.Serializers.Concept;

public interface ISerializer
{
    string Serialize(object rootObject);
}