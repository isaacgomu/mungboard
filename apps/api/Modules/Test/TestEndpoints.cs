// This file is entirely just for me testing out C# before I began working on the actual project.


namespace Api.Modules.Test;

public static class TestEndpoints
{
    public static void MapTestEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/test");

        group.MapGet("/", () => "hi");

        group.MapPost("/lol", (TestRequest req) => {
            return Results.Ok($"hi {req.Msg}");
        });

        group.MapPost("/car", (TestCarRequest req) =>
        {
            var colours = string.Join(", ", req.CarColours);

            return Results.Ok($"Hello dealer, I would like to purchase a {req.CarBrand} {req.CarName}, preferably I would like its colour to be one of {colours}");
        });

        group.MapPost("/if-gate", (IfGateRequest req) =>
        {
            // lengthy if gate version: 

            // if (req.Type == IfGateType.TypeA) // dont use strings to validate - use enum type directly
            // {
            //     return Results.Ok("Type A");
            // }
            // else if (req.Type == IfGateType.TypeB)
            // {
            //     return Results.Ok("Type B");
            // }
            // else
            // {
            //     // fallback but this should never be able to happen due to validation
            //     return Results.BadRequest("Neither type posted");
            // }

            // switch version: 

            // return req.Type switch
            // {
            //     IfGateType.TypeA => Results.Ok("Type A"),
            //     IfGateType.TypeB => Results.Ok("Type B"),
            //     _ => Results.BadRequest("Neither type posted"),
            // };

            // ternary operator version
            return req.Type == IfGateType.TypeA ? "Type A" : "Type B";
        });
    }
}