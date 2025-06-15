using System.Text.Json;
using System.Text.RegularExpressions;

namespace DotBox.Api.Settings;

public class AppSettings
{
    public required ConnectionStringElement ConnectionStrings { get; set; }

    public required SqlLoggerElement SqlLogger {  get; set; }

    public override string ToString() =>
        Regex.Replace(
            JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true }),
            "^[ \t]+([0-9]+)\\,?\n",
            "$1, ",
            RegexOptions.Multiline
        );
}
