using GamingGroupFinderDatabase;

namespace GamingGroupFinderGUI.Models;

public class ProfileDB {
    public int ProfileDBId { get; set; }
    public int UserId { get; set; }
    public UserDB User { get; set; } = null!;
    public string? Name { get; set; }
    public string? Pronouns { get; set; }
    public int Age { get; set; }
    public string? Bio { get; set; }
    public string? ProfilePicture { get; set; }
    public List<InterestDB> Interests { get; set; } = new();
    public List<PlatformDB> Platforms { get; set; } = new();
    public List<GameDB> Games { get; set; } = new();

    public ProfileDB(UserDB user, string name, string pronouns, int age, string bio, string profilePicture, List<InterestDB> interests, List<PlatformDB> platforms, List<GameDB> games) {
        this.User = user;
        this.Name = name;
        this.Pronouns = pronouns;
        this.Age = age;
        this.Bio = bio;
        this.ProfilePicture = profilePicture;
        this.Games = games;
        this.Interests = interests;
        this.Platforms = platforms;
    }

    public ProfileDB(UserDB user, string name, string pronouns, int age, string bio, string profilePicture) {
        this.User = user;
        this.Name = name;
        this.Pronouns = pronouns;
        this.Age = age;
        this.Bio = bio;
        this.ProfilePicture = profilePicture;
    }

    private ProfileDB() {

    }
}