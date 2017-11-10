using NUnit.Framework;
using OWApi.Controllers;
using Newtonsoft.Json;
using Shouldly;


namespace OWApi.Tests
{
    [TestFixture]
    public class AddGameResultShould
    {


        [Test]
        public void ReturnASingleGameResultFromDatabase()
        {
            var gameHistory = new GetGameHistoryController().Get(1);

            var result = JsonConvert.DeserializeObject<GamesJsonObject>(gameHistory);

            result.Games.Count.ShouldBe(1);
            result.Games[0].Result.ShouldBe("W");
        }


        [Test]
        public void ReturnAllResultsFromDatabase()
        {
            var gameHistory = new GetGameHistoryController().Get();

            var result = JsonConvert.DeserializeObject<GamesJsonObject>(gameHistory);

            result.Games.Count.ShouldBe(2);
            result.Games[0].Result.ShouldBe("W");
            result.Games[1].Result.ShouldBe("W");
        }

        [Test]
        public void AddGameToDataBase()
        {
            
        }

        [Test]
        public void TestDbConnection()
        {
            new ConnectionCreator().CreateConnection();
        }
    }
}
