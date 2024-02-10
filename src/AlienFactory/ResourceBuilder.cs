namespace AlienFactory;

using System.Diagnostics;
using System.Resources;

internal static class ResourceBuilder
{
    private static readonly ResourceManager ResourceManager =
        new("AlienFactory.Assets.Resources", typeof(ResourceBuilder).Assembly);

    internal static string GetResource(string type, string property)
    {
        var name = $"{type}_{property}";
        var resource = ResourceManager.GetString(name)
                       ?? throw new MissingManifestResourceException($"Resource {name} not found");
        if (string.IsNullOrWhiteSpace(resource))
        {
            Trace.TraceWarning($"Resource {name} is empty or whitespace");
        }

        return resource;
    }

}
