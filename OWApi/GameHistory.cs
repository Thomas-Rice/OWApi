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
            return SerializeObject(new GetHistoryQuery().GetGameResults(_sqlConnection));
        }


        public string GetSingleGameHistory(int index)
        {
            return SerializeObject(new GetHistoryQuery().GetSingleGameResult(_sqlConnection, index));
        }

        //public string AddGameResult(GameResult gameResult)
        //{
        //    _gameResults.Add(gameResult);

        //    return SerializeObject(_gameResults);
        //}

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