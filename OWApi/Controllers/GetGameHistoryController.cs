using System.Web.Http;

namespace OWApi.Controllers
{
    public class GetGameHistoryController : ApiController
    {
        // GET: api/GetGameHistory
        public string Get()
        {
            return new GameHistory().GetGameHistory();
        }

        // GET: api/GetGameHistory/5
        public string Get(int index)
        {
            return new GameHistory().GetSingleGameHistory(index);
        }
    }
}
