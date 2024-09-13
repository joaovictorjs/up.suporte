using Npgsql;

namespace up.suporte.Stores
{
    public class PgConnectionStore
    {
        public NpgsqlConnection? CurrentConnection { get; set; }
    }
}
