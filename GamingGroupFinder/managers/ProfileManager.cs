/*
    methods:
        - clear profile ??
    figure out how to get images
*/

// public List<Event> FindEvent(Game game, string platform, string rank) {

// }

using GamingGroupFinderDatabase;

namespace GamingGroupFinder;

public class ProfileManager {
    private static ApplicationContext db = new ApplicationContext();
    // private Profile _profile;

    // this is probably just going to create a new profile and add it to the database
    public void CreateProfile(Profile p, User u) {
        ProfileDB profile = new ProfileDB(null, p.Name, p.Pronouns, p.Age, p.Bio, p.ProfilePicture, new List<InterestDB>(), new List<PlatformDB>(), new List<GameDB>());
        var profileUser = (from user in db.UsersDB where user.Username.Equals(u.Username) select user).First();

        profile.User = profileUser;

        // figure out how to add lists of items to the profiles in database

        // List<GameDB> profileGames = GetProfileGames(p);
        // List<InterestDB> profileInterests = GetProfileInterests(p);
        // List<PlatformDB> profilePlatforms = GetProfilePlatforms(p);

        // if(profileGames.Count == 0) {
        //     profile.Games = GetProfileGames(p);
        // }
        // if(profileInterests.Count == 0) {
        //     profile.Interests = GetProfileInterests(p);
        // }
        // if(profilePlatforms.Count == 0) {
        //     profile.Platforms = GetProfilePlatforms(p);
        // }

        db.Add(profile);
        db.SaveChanges();
    }

    // this is probably just going to delete a profile from the database. not sure what would be taken in as a parameter (profile id?, profile object, ...)
    public void DeleteProfile() {

    }

    // public static List<InterestDB> GetProfileInterests(Profile p) {
    //     var testInterests = new List<InterestDB>();
    //     foreach(var interest in p.Interests) {
    //         InterestDB testInterest = (from i in db.InterestsDB where i.InterestName.Equals(interest.Name) select i).FirstOrDefault();
    //         if (testInterest == null) {
    //             InterestDB newInterest = new InterestDB(interest.Name);
    //             testInterests.Add(newInterest);
    //         }
    //     }
    //     return testInterests;
    // }

    // public static List<PlatformDB> GetProfilePlatforms(Profile p) {
    //     var testPlatforms = new List<PlatformDB>();
    //     foreach(var platform in p.Platforms) {
    //         PlatformDB testPlatform = (from plat in db.PlatformsDB where plat.PlatformName.Equals(platform.Name) select plat).FirstOrDefault();
    //         if (testPlatform == null) {
    //             PlatformDB newPlatform = new PlatformDB(platform.Name);
    //             testPlatforms.Add(newPlatform);
    //         }
    //     }
    //     return testPlatforms;
    // }

    // public static List<GameDB> GetProfileGames(Profile p) {
    //     var testGames = new List<GameDB>();
    //     foreach(var game in p.Games) {
    //         GameDB testGame = (from g in db.GamesDB where g.GameName.Equals(game.Name) select g).FirstOrDefault();
    //         if (testGame == null) {
    //             GameDB newGame = new GameDB(game.Name);
    //             testGames.Add(newGame);
    //         }
    //     }
    //     return testGames;
    // }

    public Profile EditProfile(Profile p) {
        return null!;
    }

    

    public Profile SearchProfile(string username) {
        return null!;
    }

}