using System.Text.Json.Serialization;

namespace Controls.LicenseTable;

/// <summary>
/// Represents a software package entry in the license table.
/// </summary>
public record PackageModel(
    [property: JsonPropertyName("PackageName")] string Name,
    [property: JsonPropertyName("PackageVersion")] string Version,
    string LicenseType,
    string? LicenseUrl,
    [property: JsonIgnore] string? LicenseContent,
    string Copyright,
    string? PackageUrl
)
{
    /// <summary>
    /// Gets a value indicating whether the license column should be shown as a clickable link.
    /// </summary>
    public bool HasLicenseLink => LicenseUrl is not null || LicenseContent is not null;
}
