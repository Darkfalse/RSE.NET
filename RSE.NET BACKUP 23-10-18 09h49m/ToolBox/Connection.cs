using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace ToolBox {
    public class Connection
    {
        private DbProviderFactory factory { get; set; }
        private string connectString { get; set; }

        public Connection(string invariantName, string connectionString) {
            factory = DbProviderFactories.GetFactory(invariantName);
            connectString = connectionString;

            //using (DbConnection db = CreateConnection()) { db.Open(); }
        }

        public int ExecuteNonQuery(Command cmd) {
            using (DbConnection db = CreateConnection())
            {
                db.Open();
                return CreateCommand(db, cmd).ExecuteNonQuery();
            }
        }

        public object ExecuteScalar(Command cmd) {
            using (DbConnection db = CreateConnection())
            {
                using (DbCommand cmd2 = CreateCommand(db, cmd))
                {
                    db.Open();
                    return cmd2.ExecuteScalar();
                }
            }
        }

        public IEnumerable<TResult> ExecuteReader<TResult>(Command cmd, Func<IDataRecord, TResult> func) {
            using (DbConnection db = CreateConnection())
            {
                using (DbCommand cmd2 = CreateCommand(db, cmd))
                {
                    db.Open();
                   DbDataReader reader = cmd2.ExecuteReader();
                    
                    while (reader.Read()) {
                        yield return func(reader);
                    }
                }
            }
        }

        public DbCommand CreateCommand(DbConnection db, Command cmd) {
            DbCommand cmd2 = db.CreateCommand();
            cmd2.CommandText = cmd.Query;
            foreach (KeyValuePair<string, object> kv in cmd.Parameters)
            {
                DbParameter param = cmd2.CreateParameter();
                param.ParameterName = kv.Key;
                if (kv.Value == null)
                    param.Value = DBNull.Value;
                else
                    param.Value = kv.Value;
                cmd2.Parameters.Add(param);
            }
            return cmd2;
        }

        public DbConnection CreateConnection() {
            DbConnection db = factory.CreateConnection();
            db.ConnectionString = connectString;
            return db;
        }
    }
}
