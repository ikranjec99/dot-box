using DotBox.Core.Configuration;

namespace DotBox.Api.Settings;

public class ConnectionStringElement : IConnectionStringConfiguration
{
    public required string DotBoxDb { get; set; }
}
