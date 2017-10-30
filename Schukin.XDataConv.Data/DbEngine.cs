//using System;
//using System.Data;
//using System.Data.Common;
//using System.Data.SQLite;

//namespace Schukin.XDataConv.Data
//{
//    public class DbEngine : IDisposable
//    {
//        private readonly SQLiteConnection _connection;
//        private readonly SQLiteDataAdapter _adapter;

//        public DbEngine()
//        {
//            var factory = (SQLiteFactory)DbProviderFactories.GetFactory("System.Data.SQLite");
//            _connection = (SQLiteConnection)factory.CreateConnection();
//            _adapter = new SQLiteDataAdapter("select ID, LDID, FAMIL, IMJA, OTCH, DROG, POSEL, NASP, YLIC, NDOM, " +
//                                             "NKORP, NKW, NKOMN, ILCHET, VIDGF, OPL, OTPL, KOLZR, GKU, ORG, VIDTAR, " +
//                                             "TARIF, FAKT, SUMTAR, SUMDOLG, OPLDOLG, DATDOLG, MONTH, YEAR from RECIPIENTS",
//                _connection);

//            var builder = new SQLiteCommandBuilder(_adapter);

//            DataTable = new DataTable("RECIPIENTS");
//        }



//        public DataTable DataTable { get; }

//        public void Create(string filename)
//        {
//            if (_connection.State != ConnectionState.Closed)
//                _connection.Close();

//            SQLiteConnection.CreateFile(filename);

//            _connection.ConnectionString = $"Data Source = {filename}";
//            _connection.Open();

//            using (var command = new SQLiteCommand(_connection))
//            {
//                command.CommandText = @"create table [RECIPIENTS] (" +
//                                      "[ID] integer primary key autoincrement not null," +
//                                      "[LDID] varchar(36) not null," +
//                                      "[FAMIL] varchar(100)," +
//                                      "[IMJA] varchar(100)," +
//                                      "[OTCH] varchar(100)," +
//                                      "[DROG] varchar(10)," +
//                                      "[POSEL] varchar(50)," +
//                                      "[NASP] varchar(50)," +
//                                      "[YLIC] varchar(50)," +
//                                      "[NDOM] varchar(10)," +
//                                      "[NKORP] varchar(10)," +
//                                      "[NKW] varchar(10)," +
//                                      "[NKOMN] varchar(10)," +
//                                      "[ILCHET] varchar(50)," +
//                                      "[VIDGF] varchar(255)," +
//                                      "[OPL] varchar(50)," +
//                                      "[OTPL] varchar(50)," +
//                                      "[KOLZR] varchar(5)," +
//                                      "[GKU] varchar(255)," +
//                                      "[ORG] varchar(255)," +
//                                      "[VIDTAR] varchar(5)," +
//                                      "[TARIF] varchar(50)," +
//                                      "[FAKT] varchar(50)," +
//                                      "[SUMTAR] varchar(50)," +
//                                      "[SUMDOLG] varchar(50)," +
//                                      "[OPLDOLG] varchar(50)," +
//                                      "[DATDOLG] varchar(10)," +
//                                      "[MONTH] varchar(2)," +
//                                      "[YEAR] varchar(4)" +
//                                      ");";
//                command.CommandType = CommandType.Text;
//                command.ExecuteNonQuery();
//            }
//        }

//        public void Open(string filename)
//        {
//            ChangeConnection(filename);

//            DataTable.Clear();
//            _adapter.Fill(DataTable);
//        }

//        public void Clear()
//        {
//            foreach (DataRow row in DataTable.Rows)
//            {
//                row.Delete();
//            }
//        }

//        public void Update()
//        {
//            _adapter.Update(DataTable);
//        }

//        public void ChangeConnection(string filename)
//        {
//            if (_connection.State != ConnectionState.Closed)
//                _connection.Close();

//            _connection.ConnectionString = $"Data Source = {filename}";
//            _connection.Open();
//        }

//        public void Dispose()
//        {
//            _adapter?.Dispose();
//            _connection?.Dispose();
//            DataTable?.Dispose();
//        }
//    }
//}
