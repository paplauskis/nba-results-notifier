using nba_results_notifier.Models;

namespace nba_results_notifier.Interfaces;

public interface IGameScraper
{
    public List<Game> GetGames();
}