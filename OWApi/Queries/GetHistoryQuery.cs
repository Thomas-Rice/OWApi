using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace OWApi.Queries
{
    public class GetHistoryQuery
    {
        private readonly IDbConnection _connection;

        public GetHistoryQuery()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OWAPIDB"].ConnectionString);
        }

        public List<Table1> GetGameResults()
        {
            using (_connection)
            {
                return _connection.Query<Table1>("USPGetGameResults", commandType: CommandType.StoredProcedure).ToList();
            }

        }

        public List<Table1> GetSingleGameResult(int index)
        {
            using (_connection)
            {
                return _connection.Query<Table1>("USPGetSingleGameResult", new {Index = index}, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void AddGameResult(int score, int streak, string result)
        {
            using (_connection)
            {
                _connection.Query<Table1>("USPAddSingleGameResult", new { Score = score , Streak = streak, Result = result }, commandType: CommandType.StoredProcedure);

            }

        }

        private void deleteSingleGameResult(int index)
        {
            throw new NotImplementedException();
        }

        private void deleteMultipleGameResults(bool all, int? index = null)
        {
            throw new NotImplementedException();
        }

    }
}