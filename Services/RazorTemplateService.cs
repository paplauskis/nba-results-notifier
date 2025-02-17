using nba_results_notifier.Interfaces;
using nba_results_notifier.Models;
using RazorLight;

namespace nba_results_notifier.Services;

public class RazorTemplateService : IRendererAsync
{
    private readonly RazorLightEngine _engine;

    public RazorTemplateService()
    {
        _engine = new RazorLightEngineBuilder()
            .UseFileSystemProject(Path.Combine(Directory.GetCurrentDirectory(), "EmailTemplates"))
            .UseMemoryCachingProvider()
            .Build();
    }

    public async Task<string> RenderAsync(string templateName, List<Game> models)
    {
        return await _engine.CompileRenderAsync(templateName, models);
    }
}