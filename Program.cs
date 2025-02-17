using nba_results_notifier.Interfaces;
using nba_results_notifier.Services;

var games = new GameScrapingService().GetGames();

var razorService = new RazorTemplateService();
string emailBody = await razorService.RenderAsync("GameResultTables", games);
ISendable emailService = new EmailService();

await emailService.Send(
    $"Last Night's NBA Game Results ({DateTime.Now.AddDays(-1):yyyy-MM-dd})",
    emailBody
);