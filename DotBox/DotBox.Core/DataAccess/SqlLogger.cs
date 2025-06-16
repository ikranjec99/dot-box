using DotBox.Core.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace DotBox.Core.DataAccess;

public class SqlLogger : ISqlLogger
{
    private readonly ILogger _logger;
    private readonly ISqlLoggerConfiguration _sqlLoggerConfiguration;

    public SqlLogger(
        ILogger<SqlLogger> logger,
        ISqlLoggerConfiguration sqlLoggerConfiguration)
    {
        _logger = logger;
        _sqlLoggerConfiguration = sqlLoggerConfiguration;
    }

    public SqlLog Log(SqlConnection sqlConnection, string sql)
        => new(_sqlLoggerConfiguration, _logger, sqlConnection, sql, null);

    public SqlLog Log(SqlConnection sqlConnection, string sql, object parameters)
        => new(_sqlLoggerConfiguration, _logger, sqlConnection, sql, parameters);
}
