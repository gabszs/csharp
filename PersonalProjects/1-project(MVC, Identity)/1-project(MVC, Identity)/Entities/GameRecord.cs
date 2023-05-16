namespace _1_project_MVC__Identity_.Entities
{
    public class GameRecord
    {
        public int GameId { get; set; }
        public bool WinOrLoose { get; set; }
        public string GameName { get; set; }
        public string Against { get; set; }
        public TimeOnly TimeRecord { get; set; }
        public TimeOnly Duration { get; set; }

    }
}
