using DotBox.Core.Extensions;

namespace DotBox.Core.DataAccess.DropBoxDb.Sql;

public static class DropBoxDbLoader
{
    public static string Load(string scriptName)
    {
        string resourceName = $"{nameof(DotBox)}.{nameof(Core)}.{nameof(DataAccess)}.{nameof(DropBoxDb)}.{nameof(Sql)}.{scriptName}.sql";
        return typeof(DropBoxDbLoader).Assembly.ReadResourceText(resourceName).Insert(0, $"--{scriptName}\n");
    }
}
