namespace GamingGroupFinderDatabase;

public class User {
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public Profile? Profile { get; set; }
    public List<Event> Events { get; } = new();
}

// public class Contact {
//     public int ContactId { get; set; }
//     public int UserId { get; set; }
//     public User User { get; set; } = null!;
// }

public class Profile {
    public int ProfileId { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public string Name { get; set; }
    public string Pronouns { get; set; }
    public int Age { get; set; }
    public string Bio { get; set; }
    public string ProfilePicture { get; set; }
    public List<Interest> Interests { get; } = new();
    public List<Platform> Platforms { get; } = new();
    public List<Game> Games { get; } = new();
}

public class Game {
    public int GameId { get; set; }
    public string GameName { get; set; }
    public List<Platform> Platforms { get; } = new();
    public List<Rank> Ranks { get; } = new();
    public List<Profile> Profiles { get; } = new();
}

public class Platform {
    public int PlatformId { get; set; }
    public string PlatformName { get; set; }
    public List<Game> Games { get; } = new();
    public List<Profile> Profiles { get; } = new();
}

public class Rank {
    public int RankId { get; set; }
    public int RankValue { get; set; }
    public string RankName { get; set; }
    public List<Game> Games { get; } = new();
}

public class Interest {
    public int InterestId { get; set; }
    public string InterestName { get; set; }
    public List<Profile> Profiles { get; } = new();
}

public class Message {
    public int MessageId { get; set; }
    public int SenderId { get; set; }
    public User Sender { get; set; } = null!;
    public int ReceiverId { get; set; }
    public User Receiver { get; set; } = null!;
    public DateTime Time { get; set; }
    public string MessageText { get; set; }
    public bool IsSeen { get; set; }
}

public class Event {
    public int EventId { get; set; }
    public int OwnerId { get; set; }
    public User? User { get; set; }
    public string Title { get; set; }
    public DateTime Time { get; set; }
    public string Location { get; set; }
    public int GameId { get; set; }
    public Game? Game { get; set; }
    public int PlatformId { get; set; }
    public Platform? Platform { get; set; }
    public int MinRankId { get; set; }
    public Rank? MinRank { get; set; }
    public int MaxRankId { get; set; }
    public Rank? MaxRank { get; set; }
    public string Description { get; set; }
    public List<User> Users { get; } = new();
}