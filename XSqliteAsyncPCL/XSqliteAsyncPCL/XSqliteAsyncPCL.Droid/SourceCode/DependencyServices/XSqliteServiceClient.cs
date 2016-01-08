using System;
using System.IO;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.XamarinAndroid;
using Xamarin.Forms;
using XSqliteAsyncPCL.Droid.SourceCode.DependencyServices;
using XSqliteAsyncPCL.SourceCode.DependencyServices;

[assembly: Dependency(typeof(XSqliteServiceClient))]
namespace XSqliteAsyncPCL.Droid.SourceCode.DependencyServices
{
    public class XSqliteServiceClient : IXSqliteService
    {
        public SQLiteAsyncConnection GetAsyncConnection()
        {
            const string sqliteFilename = "XamarinTemplate.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            var path = Path.Combine(documentsPath, sqliteFilename);

            var platform = new SQLitePlatformAndroid();

            var connectionWithLock = new SQLiteConnectionWithLock(
                                         platform,
                                         new SQLiteConnectionString(path, true));

            var connection = new SQLiteAsyncConnection(() => connectionWithLock);

            return connection;
        }
    }
}