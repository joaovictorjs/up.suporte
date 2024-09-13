using Npgsql;
using up.suporte.Stores;

namespace up.suporte.Services
{
    public interface IPgConnectionService
    {
        void BuildConnectionString(string address, string port, string database, string username, string password);
        Task CreateConnection();
    }

    public class PgConnectionService : IPgConnectionService
    {
        private PgConnectionStore _store;
        private string _connectionString;

        public PgConnectionService(PgConnectionStore store)
        {
            _store = store;
            _connectionString = "";
        }

        public void BuildConnectionString(string address, string port, string database, string username, string password)
        {
            NpgsqlConnectionStringBuilder builder = new NpgsqlConnectionStringBuilder();
            builder.Host = address;
            builder.Port = int.Parse(port);
            builder.Database = database;
            builder.Username = username;
            builder.Password = password;
            _connectionString = builder.ConnectionString;
        }

        public Task CreateConnection()
        {
            _store.CurrentConnection = new NpgsqlConnection(_connectionString);
            return _store.CurrentConnection.OpenAsync();
        }
    }
}
