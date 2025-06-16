using Dapper;
using DotBox.Core.Configuration;
using DotBox.Core.DataAccess.DropBoxDb.Interfaces;
using DotBox.Core.DataAccess.DropBoxDb.Models;
using DotBox.Core.DataAccess.DropBoxDb.Sql;
using Microsoft.Data.SqlClient;

namespace DotBox.Core.DataAccess.DropBoxDb.Implementations;

public class FileRepository : IFileRepository
{
    private readonly string _connectionString;
    private readonly ISqlLogger _sqlLogger;

    public FileRepository(
        IConnectionStringConfiguration configuration,
        ISqlLogger sqlLogger)
    {
        _connectionString = configuration.DotBoxDb;
        _sqlLogger = sqlLogger;
    }

    public async Task Add(InsertFileQuery query)
    {
        using var sqlConnection = new SqlConnection(_connectionString);
        string sql = DropBoxDbLoader.Load("InsertFile");

        using var _ = _sqlLogger.Log(sqlConnection, sql, query);
        await sqlConnection.ExecuteAsync(sql, query);
    }

    public async Task Delete(DeleteFileQuery query)
    {
        using var sqlConnection = new SqlConnection(_connectionString);
        string sql = DropBoxDbLoader.Load("DeleteFile");

        using var _ = _sqlLogger.Log(sqlConnection, sql, query);
        await sqlConnection.ExecuteAsync(sql, query);
    }
}
