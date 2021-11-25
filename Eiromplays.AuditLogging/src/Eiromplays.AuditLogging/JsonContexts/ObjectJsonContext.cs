using System.Text.Json.Serialization;

namespace Eiromplays.AuditLogging.JsonContexts;

[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Default, PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(object))]
public partial class ObjectJsonContext : JsonSerializerContext
{
}