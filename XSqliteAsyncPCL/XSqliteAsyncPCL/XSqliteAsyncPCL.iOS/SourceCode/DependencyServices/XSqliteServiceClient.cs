using System;
using System.IO;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.XamarinIOS;
using Xamarin.Forms;
using XSqliteAsyncPCL.iOS.SourceCode.DependencyServices;
using XSqliteAsyncPCL.SourceCode.DependencyServices;

[assembly: Dependency(typeof(XSqliteServiceClient))]
namespace XSqliteAsyncPCL.iOS.SourceCode.DependencyServices
{
    public class XSqliteServiceClient : IXSqliteService
    {
        public SQLiteAsyncConnection GetAsyncConnection()
        {
            const string sqliteFilename = "XamarinTemplate.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, sqliteFilename);

            var platform = new SQLitePlatformIOS();

            var connectionWithLock = new SQLiteConnectionWithLock(
                                          platform,
                                          new SQLiteConnectionString(path, true));

            var connection = new SQLiteAsyncConnection(() => connectionWithLock);

            return connection;
        }
    }
}
