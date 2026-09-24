using Api.Modules.Test;

namespace Api.Modules;

public static class ModuleExtensions
{
    public static void MapModules(this IEndpointRouteBuilder app)
    {
        app.MapTestEndpoints();
    }
}