using System.Collections.Generic;
using System.Data.SqlClient;
using Newtonsoft.Json;
using OWApi.Queries;

namespace OWApi
{
    public partial class GameHistory
    {
        private readonly SqlConnection _sqlConnection;

        public GameHistory()
        {
            _sqlConnection = new ConnectionCreator().CreateConnection();
        }

        public string GetGameHistory()
        {
            return SerializeObject(new GetHistoryQuery(_sqlConnection).GetGameResults());
        }


        public string GetSingleGameHistory(int index)
        {
            return SerializeObject(new GetHistoryQuery(_sqlConnection).GetSingleGameResult(index));
        }

        public string AddGameResult(int score, int streak, string result)
        {
            var gameHistory = new GetHistoryQuery(_sqlConnection);
            gameHistory.AddGameResult(score, streak, result);
            return SerializeObject(gameHistory.GetGameResults());
        }

        public string SerializeObject(List<GameResult> listToSerialize)
        {
            return JsonConvert.SerializeObject(
                new
                {
                    Games = listToSerialize
                });
        }
    }
}