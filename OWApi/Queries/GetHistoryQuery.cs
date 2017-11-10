using System.Collections.Generic;
using System.Data.SqlClient;

namespace OWApi.Queries
{
    public class GetHistoryQuery
    {
        private readonly List<GameResult> _gameResults = new List<GameResult>();
        private readonly SqlConnection _connection;

        public GetHistoryQuery(SqlConnection connection)
        {
            _connection = connection;
        }

        public List<GameResult> GetGameResults()
        {
            var queryString = @"SELECT [Id]
                                  ,[Score]
                                  ,[Streak]
                                  ,[Result]
                              FROM[dbo].[Table_1]";

            using (_connection)
            {
                var command = new SqlCommand(queryString, _connection);
                _connection.Open();
                AddToGameResults(command);
            }
            return _gameResults;
        }

        public List<GameResult> GetSingleGameResult(int index)
        {
            var queryString = @"SELECT [Id]
                                  ,[Score]
                                  ,[Streak]
                                  ,[Result]
                              FROM[dbo].[Table_1]" +
                              $"WHERE[Id] = {index}";

            using (_connection)
            {
                var command = new SqlCommand(queryString, _connection);
                _connection.Open();
                AddToGameResults(command);
            }
            return _gameResults;
        }



        public void AddGameResult(int score, int streak, string result)
        {
            var queryString = @"INSERT INTO [dbo].[Table_1]
                                ([Score]
                                ,[Streak]
                                ,[Result])" +
                              "VALUES(@score, @streak, @result)";
                                
            using (_connection)
            {
                var command = new SqlCommand(queryString, _connection);
                command.Parameters.AddWithValue("@Score", score);
                command.Parameters.AddWithValue("@Streak", streak);
                command.Parameters.AddWithValue("@Result", result);

                _connection.Open();
                command.ExecuteNonQuery();
            }

        }

        private void AddToGameResults(SqlCommand command)
        {
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
    }
}