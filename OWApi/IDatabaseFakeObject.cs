namespace OWApi
{
    public partial class GameHistory
    {
        public interface IDatabaseFakeObject
        {
            int Id { get; set; }
            string Result { get; set; }
            int Score { get; set; }
        }
    }
}