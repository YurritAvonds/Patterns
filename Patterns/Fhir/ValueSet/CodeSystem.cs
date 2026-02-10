namespace Patterns.Fhir.ValueSet
{
    public class CodeSystem(string uri, string oid) : ISystem
    {
        public string Uri { get; private set; } = uri;
        public string Oid { get; private set; } = oid;
        public string[] Codes { get; set; } = [];
    }
}
