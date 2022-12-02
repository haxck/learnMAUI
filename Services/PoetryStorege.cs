

using MauiApp1.Models;
using SQLite;

namespace MauiApp1.Services
{
    public class PoetryStorege : IPoetryStorage
    {
        public const string DBFileName = "poetrydb.sqlite3";
        public static readonly String PoetryDbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DBFileName);

        private SQLiteAsyncConnection _connection;
        public SQLiteAsyncConnection Connection =>
            _connection ??= new SQLiteAsyncConnection(PoetryDbPath);


        public async Task InitializeAsync()
        {
            await Connection.CreateTableAsync<Poetry>();
        }
        public async Task AddAsync(Poetry poetry)
        {
            await Connection.InsertAsync(poetry);
        }

        public async Task<IEnumerable<Poetry>> ListAsync()
        {
            return await Connection.Table<Poetry>().ToListAsync();
        }
    }
}
