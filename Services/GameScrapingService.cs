using HtmlAgilityPack;
using nba_results_notifier.Interfaces;
using nba_results_notifier.Models;

namespace nba_results_notifier.Services;

public class GameScrapingService : IGameScraper
{
    private const string URL = "https://www.basketball-reference.com/boxscores/";
    private readonly HtmlWeb _web;
    private readonly HtmlDocument _document;
    List<Game>? games = new();
    
    public GameScrapingService() {
        _web = new HtmlWeb();
        _document = _web.Load(URL);
    }
    
    public List<Game>? GetGames()
    {
        HtmlNodeCollection nodes = _document.DocumentNode.SelectNodes("//div/div[contains(@class, 'game_summary')]");

        foreach (HtmlNode node in nodes)
        {
            ExtractGameInfo(node);
        }

        return games;
    }

    private void ExtractGameInfo(HtmlNode node)
    {
        var firstTeamGeneralInfo = node.SelectNodes("./child::table[not(@class)]/tbody/tr[not(@class)]")[0];
        var secondTeamGeneralInfo = node.SelectNodes("./child::table[not(@class)]/tbody/tr[not(@class)]")[1];
        var team = ExtractTeamInfo(firstTeamGeneralInfo);
        var secondTeam = ExtractTeamInfo(secondTeamGeneralInfo);
        
        Console.WriteLine(team.ToString());
        Console.WriteLine(secondTeam.ToString());
    }

    private Team ExtractTeamInfo(HtmlNode node)
    {
        var teamName = node.SelectSingleNode("./child::td").InnerText.Replace("&nbsp;", "");
        var quarterPoints = node.SelectNodes("./child::td[contains(@class, 'center')]");
        var points = ExtractQuarterPoints(quarterPoints);
        
        return new Team
        {
            Name = teamName,
            TotalPoints = GetAllTeamPoints(points),
            FirstQuarterPoints = points[0],
            SecondQuarterPoints = points[1],
            ThirdQuarterPoints = points[2],
            FourthQuarterPoints = points[3],
            OtPoints = points[4..],
        };
    }

    private List<short> ExtractQuarterPoints(HtmlNodeCollection collection)
    {
        List<short> pointsList = new();
        
        foreach (var node in collection)
        {
            pointsList.Add(short.Parse(node.InnerText));
        }
        
        return pointsList;
    }

    private short GetAllTeamPoints(List<short> teamPointsList)
    {
        short teamPoints = 0;

        foreach (var pts in teamPointsList)
        {
            teamPoints += pts;
        }
        
        return teamPoints;
    }
}