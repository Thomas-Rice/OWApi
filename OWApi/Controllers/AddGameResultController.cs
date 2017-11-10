using System.Web.Http;

namespace OWApi.Controllers
{
    public class AddGameResultController : ApiController
    {
        // POST: api/addGameResult
        public string Post([FromBody] int index, string result, int score, int streak)
        {
            
            var gameToAdd = new GameResult
            {
                Index = index,
                Result = result,
                Score = score,
                Streak = streak
            };
            return new GameHistory().GetGameHistory();
        }

    }
}
