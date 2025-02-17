using nba_results_notifier.Models;

namespace nba_results_notifier.Interfaces;

public interface IRendererAsync
{
    public Task<string> RenderAsync(string templateName, List<Game> models);
}