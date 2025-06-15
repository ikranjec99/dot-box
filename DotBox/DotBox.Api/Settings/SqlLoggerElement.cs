using DotBox.Core.Configuration;

namespace DotBox.Api.Settings;

public class SqlLoggerElement : ISqlLoggerConfiguration
{
    public bool Enabled { get; set; }
}
