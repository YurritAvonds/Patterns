#:package Microsoft.Extensions.Hosting@10.0.5
#:project ../Patterns/Patterns.csproj

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Patterns.Personal.Serializers;
using System.Xml;

/// <summary>
/// Run this in a terminal using dotnet run DependencyInjection.cs
/// </summary>

// Builder that includes two services of the same type, but with different keys.
var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<JsonSerializationApp>();
        services.AddHostedService<XmlSerializationApp>();
        services.AddScoped<ISerializer, XmlSerializer>();
        services.AddKeyedSingleton<ISerializer, XmlSerializer>("xml");
        services.AddKeyedSingleton<ISerializer, JsonSerializer>("json");
        services.AddSingleton(new XmlWriterSettings
        {
            Indent = true,
            OmitXmlDeclaration = true,
        });
    });
var host = builder.Build();
host.Run();

/// <summary>
/// Application to serialize to JSON. Exactly the same as the XML one, except for the 
/// name and the [FromKeyedServices("json")] attribute, which specifies that it wants the JSON serializer.
/// </summary>
/// <param name="serializer">JSON serializer (based only on the specified key)</param>
class JsonSerializationApp([FromKeyedServices("json")] ISerializer serializer) : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        var result = serializer.Serialize(new Root());
        Console.Write(result);
        Console.WriteLine(string.Empty);

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"Closing {nameof(JsonSerializationApp)}...");
        Console.WriteLine(string.Empty);
        return Task.CompletedTask;
    }
}

/// <summary>
/// Application to serialize to XML. Exactly the same as the JSON one, except for the 
/// name and the [FromKeyedServices("xml")] attribute, which specifies that it wants the XML serializer.
/// </summary>
/// <param name="serializer">XML serializer (based only on the specified key)</param>
class XmlSerializationApp([FromKeyedServices("xml")] ISerializer serializer) : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        var result = serializer.Serialize(new Root());
        Console.Write(result);
        Console.WriteLine(string.Empty);

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"Closing {nameof(XmlSerializationApp)}...");
        return Task.CompletedTask;
    }
}