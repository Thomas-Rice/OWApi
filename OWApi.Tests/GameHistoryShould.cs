using System.Collections.Generic;
using NUnit.Framework;
using Newtonsoft.Json;
using OWApi.Controllers;
using Shouldly;


namespace OWApi.Tests
{
    [TestFixture]
    public class GameHistoryShould
    {


        [Test]
        public void ReturnASingleGameResultFromDatabase()
        {
            var result = new GameHistory().GetSingleGameHistory(1);


            result.Count.ShouldBe(1);
            result[0].Result.ShouldBe("W");
        }


        [Test]
        public void ReturnAllResultsFromDatabase()
        {
            var result = new GameHistory().GetGameHistory();

            result.Count.ShouldBe(2);

        }

        //[Test]
        //public void AddGameToDataBase()
        //{

        //    var gameHistory = new GameHistory();
        //    gameHistory.AddGameResult(150, 3, "woo");
            //var gameHistory2 = new GameHistory();
            //var results = gameHistory2.GetGameHistory();

            //var result = JsonConvert.DeserializeObject<GamesJsonObject>(results);

            //result.Games.Count.ShouldBe(3);
            //result.Games[0].Result.ShouldBe("W");
            //result.Games[1].Result.ShouldBe("W");
            //result.Games[2].Result.ShouldBe("woo");
        }

        //[Test]
        //public void TestDbConnection()
        //{
        //    new ConnectionCreator().CreateConnection();
        //}
    }

