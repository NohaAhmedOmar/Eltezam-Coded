using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace ElTezam_Coded_WebApp.DapperORM
{
    public class Dapper<T> where T : class
    {
        private string ConnectionString { get; set; } = "";
        private IDbConnection Db { get; set; }

        static Dapper<T>? dapper;

        private Dapper()
        {
            ConnectionString = "Data Source=INTALIO-NOHAESS\\MSSQLSERVER03;Initial Catalog=Rafha;Trusted_Connection=False; MultipleActiveResultSets=true;User ID=sa;Password=123456";
            //rafha connection string
            //ConnectionString = "Data Source=SERVER4;Initial Catalog=Rafha;Trusted_Connection=False; MultipleActiveResultSets=true;User ID=rafha;Password=rafha";
            Db = new SqlConnection(ConnectionString);
        }
        public static Task<Dapper<T>> GetInstance()
        {
            if (dapper == null)
                return Task.FromResult(dapper = new Dapper<T>());
            else
                return Task.FromResult(dapper);
        }
        public Task<List<T>> GetAllData(string Query)
        {
            var Result = Db.Query<T>(Query);
            return Task.FromResult((List<T>)Result);
        }
        public Task<string> RunDML(string Query)
        {
            try
            {
                Db.Execute(Query);
                return Task.FromResult("ok");
            }
            catch (Exception e)
            {

                return Task.FromResult(e.Message);
            }
        }

        public Task<int> GetCount(string Query)
        {
            var Result = Db.ExecuteScalar(Query);
            return Task.FromResult((int)Result);
        }
    }
}
