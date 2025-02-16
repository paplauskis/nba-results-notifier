namespace nba_results_notifier.Models;

public class Team
{
    public string Name { get; set; }

    public short TotalPoints { get; set; }
    
    public short FirstQuarterPoints { get; set; }
    
    public short SecondQuarterPoints { get; set; }
    
    public short ThirdQuarterPoints { get; set; }
    
    public short FourthQuarterPoints { get; set; }
}