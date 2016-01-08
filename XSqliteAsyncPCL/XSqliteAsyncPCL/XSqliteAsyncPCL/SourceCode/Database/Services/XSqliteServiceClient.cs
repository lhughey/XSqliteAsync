using System;
using System.Diagnostics;
using System.Threading;
using SQLite.Net.Async;
using Xamarin.Forms;
using XSqliteAsyncPCL.SourceCode.Database.Models;
using XSqliteAsyncPCL.SourceCode.DependencyServices;

namespace XSqliteAsyncPCL.SourceCode.Database.Services
{
    public class XSqliteServiceClient : IXSqliteServiceClient
    {
        private static readonly Lazy<XSqliteServiceClient> Lazy =
        new Lazy<XSqliteServiceClient>(() => new XSqliteServiceClient());

        public static IXSqliteServiceClient Instance => Lazy.Value;

        private XSqliteServiceClient()
        {
        }

        private SQLiteAsyncConnection _dbConnection;
        public SQLiteAsyncConnection DbConnection
        {
            get
            {
                if (_dbConnection == null)
                {
                    LazyInitializer.EnsureInitialized(ref _dbConnection, DependencyService.Get<IXSqliteService>().GetAsyncConnection);
                }

                return _dbConnection;
            }
        }

        public async void CreateDbIfNotExist()
        {
            await DbConnection.CreateTableAsync<YourModelHere>();
            Debug.WriteLine("Create db success!");
        }
    }
}
