namespace nba_results_notifier.Models;

public class Game
{
    public required Team HomeTeam { get; set; }
    
    public required Team AwayTeam { get; set; }
}