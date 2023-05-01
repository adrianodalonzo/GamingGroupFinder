using GamingGroupFinderDatabase;

namespace GamingGroupFinderGUI.Models;

public class InterestDB {
    public int InterestId { get; set; }
    public string InterestName { get; set; }
    public List<ProfileDB> Profiles { get; } = new();

    public InterestDB(string interestName) {
        this.InterestName = interestName;
    }

    private InterestDB() {

    }
}