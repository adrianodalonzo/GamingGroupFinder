using GamingGroupFinderDatabase;

namespace GamingGroupFinderGUI.Models;

public class RankDB {
    public int RankId { get; set; }
    public int RankValue { get; set; }
    public string RankName { get; set; }
    public List<GameDB> Games { get; } = new();
    
    public RankDB(int rankValue, string rankName) {
        this.RankValue = rankValue;
        this.RankName = rankName;
    }

    private RankDB() {

    }
}