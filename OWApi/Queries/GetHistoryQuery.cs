using System.Collections.Generic;
using System.Data.SqlClient;

namespace OWApi.Queries
{
    public class GetHistoryQuery
    {
        private readonly List<GameResult> _gameResults = new List<GameResult>();

        public List<GameResult> GetGameResults(SqlConnection connection)
        {
            const string queryString = "SELECT * FROM dbo.Table_1;";
            using (connection)
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _gameResults.Add( new GameResult()
                        {
                            Index = reader.GetInt32(0),
                            Score = reader.GetInt32(1),
                            Streak = reader.GetInt32(2),
                            Result = reader.GetString(3)
                        });
                    }
                }
            }
            return _gameResults;
        }

        public List<GameResult> GetSingleGameResult(SqlConnection connection, int index)
        {
            var queryString = "SELECT[Id]" +
                              ",[Score]" +
                              ",[Streak]" +
                              ",[Result] " +
                              "FROM[dbo].[Table_1] " +
                              $"WHERE[Id] = { index}";
            using (connection)
            {
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _gameResults.Add(new GameResult()
                        {
                            Index = reader.GetInt32(0),
                            Score = reader.GetInt32(1),
                            Streak = reader.GetInt32(2),
                            Result = reader.GetString(3)
                        });
                    }
                }
            }
            return _gameResults;
        }


    }
}