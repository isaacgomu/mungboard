using System.ComponentModel.DataAnnotations;

namespace Api.Modules.Test;

public record TestRequest([Required] string Msg);

public record TestCarRequest(
    [Required] string CarName,
    [Required] string CarBrand,
    [Required, MinLength(1)] string[] CarColours
);

// looks like c# doesn't allow unions directly, have to create an enum
public enum IfGateType { TypeA, TypeB }
public record IfGateRequest([Required] IfGateType Type);