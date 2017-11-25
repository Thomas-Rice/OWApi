using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using Dapper;

namespace OWApi.Controllers
{
    public class GetGameHistoryController : ApiController
    {
        // GET: api/GetGameHistory
        public List<Table1> Get()
        {

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["OWAPI-DB"].ConnectionString))
            {
                return db.Query<Table1>(
                                          @"SELECT [Id]
                                          ,[Score]
                                          ,[Streak]
                                          ,[Result]
                                          FROM[dbo].[Table_1]").ToList();
            }

        }

        // GET: api/GetGameHistory/5
        public List<Table1> Get(int index)
        {

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["OWAPIDB"].ConnectionString))
            {
                return db.Query<Table1>(
                                          @"SELECT [Id]
                                          ,[Score]
                                          ,[Streak]
                                          ,[Result]
                                          FROM[dbo].[Table_1]" +
                                          $"WHERE[Id] = {index}").ToList();
            }

        }
    }
}
