namespace nba_results_notifier.Interfaces;

public interface ISendable
{
    public Task Send(string subject, string body);
}