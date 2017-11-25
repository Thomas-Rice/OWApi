using NUnit.Framework;
using OWApi.Queries;
using Shouldly;

namespace OWApi.Tests.UnitTests
{
    [TestFixture]
    public class GameHistoryShould
    {
        //TODO Mock database
        [Test]
        public void ReturnASingleGameResultFromDatabase()
        {
            var result = new GetHistoryQuery().GetSingleGameResult(1);

            result.Count.ShouldBe(1);
            result[0].Score.ShouldNotBeNull();
            result[0].Streak.ShouldNotBeNull();
            result[0].Result.ShouldNotBeNull();
        }


        [Test]
        public void ReturnAllResultsFromDatabase()
        {
            var result = new GetHistoryQuery().GetGameResults();

            result.Count.ShouldBeGreaterThanOrEqualTo(1);
        }


        [Test]
        public void AddGameToDatabase()
        {
            new GetHistoryQuery().AddGameResult(100, 100 , "TEST");

            var result = new GetHistoryQuery().GetGameResults();

            result.Reverse();
            result[0].Score.ShouldBe(100);
            result[0].Streak.ShouldBe(100);

        }
        //[Test]
        //public void AddGameToDatabase()
        //{

        //    var gameHistory = new GameHistory();
        //    gameHistory.AddGameResult(150, 3, "woo");
        //    var gameHistory2 = new GameHistory();
        //    var results = gameHistory2.GetGameHistory();

        //    var result = JsonConvert.DeserializeObject<GamesJsonObject>(results);

        //    result.Games.Count.ShouldBe(3);
        //    result.Games[0].Result.ShouldBe("W");
        //    result.Games[1].Result.ShouldBe("W");
        //    result.Games[2].Result.ShouldBe("woo");
        //}

    }
}
