using System;
using System.IO;
using Windows.Storage;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WinRT;
using Xamarin.Forms;
using XSqliteAsyncPCL.SourceCode.DependencyServices;
using XSqliteAsyncPCL.UWP.SourceCode.DependencyServices;

[assembly: Dependency(typeof(XSqliteServiceClient))]
namespace XSqliteAsyncPCL.UWP.SourceCode.DependencyServices
{
    public class XSqliteServiceClient : IXSqliteService
    {
        public SQLiteAsyncConnection GetAsyncConnection()
        {
            var dbPath = GetLocalFilePath("XamarinTemplate.db3");
            var connectionFactory = new Func<SQLiteConnectionWithLock>(() => new SQLiteConnectionWithLock(new SQLitePlatformWinRT(), new SQLiteConnectionString(dbPath, storeDateTimeAsTicks: false)));
            var asyncConnection = new SQLiteAsyncConnection(connectionFactory);
            return asyncConnection;
        }
        private static string GetLocalFilePath(string filename)
        {
            var path = ApplicationData.Current.LocalFolder.Path;
            var dbPath = Path.Combine(path, filename);
            return dbPath;
        }
    }
}
