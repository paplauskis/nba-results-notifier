namespace nba_results_notifier.Helpers;

public static class UrlGenerator
{
    private const string BaseUrl = "https://www.basketball-reference.com/boxscores/";

    public static string GetUrlWithYesterdayDate()
    {
        var yesterday = DateTime.Now.AddDays(-1);
        return $"{BaseUrl}?month={yesterday.Month:00}&day={yesterday.Day:00}&year={yesterday.Year}";
    }
}