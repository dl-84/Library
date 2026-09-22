using System.Text.Json.Serialization;

namespace Controls.LicenseTable.Models;

public record PackageModel(
    [property: JsonPropertyName("PackageName")] string Name,
    [property: JsonPropertyName("PackageVersion")] string Version,
    string LicenseType,
    string? LicenseUrl,
    [property: JsonIgnore] string? LicenseContent,
    string Copyright = "",
    string? PackageUrl = null
)
{
    public bool HasLicenseLink => LicenseUrl is not null || LicenseContent is not null;

    public bool HasPackageUrl => PackageUrl is not null;
}
