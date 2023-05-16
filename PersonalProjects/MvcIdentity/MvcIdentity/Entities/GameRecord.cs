using System.ComponentModel.DataAnnotations;

namespace MvcIdentity.Entities
{
    public class GameRecord
    {
        [Key]
        public int MatchId { get; set; }
        public bool WinOrLoose { get; set; }
        public string GameName { get; set; }
        public string Against { get; set; }
        public DateTime TimeRecord { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
