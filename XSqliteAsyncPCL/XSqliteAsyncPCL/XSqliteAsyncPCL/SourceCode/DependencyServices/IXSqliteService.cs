using SQLite.Net.Async;

namespace XSqliteAsyncPCL.SourceCode.DependencyServices
{
    public interface IXSqliteService
    {
        SQLiteAsyncConnection GetAsyncConnection();
    }
}
