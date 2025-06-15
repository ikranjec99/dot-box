using Microsoft.Data.SqlClient;

namespace DotBox.Core.DataAccess;

public interface ISqlLogger
{
    SqlLog Log(SqlConnection sqlConnection, string sql);
    SqlLog Log(SqlConnection sqlConnection, string sql, object parameters);
}
