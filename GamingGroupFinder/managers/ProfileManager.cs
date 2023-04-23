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

    private Profile _profile;

    // this is probably just going to create a new profile and add it to the database
    public void CreateProfile(Profile p, User u) {
        ApplicationContext db = new ApplicationContext();
        ProfileDB profile1 = new ProfileDB(null, p.Name, p.Pronouns, p.Age, p.Bio, p.ProfilePicture);
        profile1.User = new UserDB(u.Username, u.Password, u.Salt, profile1);
        db.Add(profile1);
        db.SaveChanges();
    }

    // this is probably just going to delete a profile from the database. not sure what would be taken in as a parameter (profile id?, profile object, ...)
    public void DeleteProfile() {

    }

    public Profile EditProfile(Profile p) {
        return null!;
    }

    public void GetProfileGames(Profile p) {

    }

    public void GetProfilePlatforms(Profile p) {

    }

    public void GetProfileInterests(Profile p) {

    }

    public Profile SearchProfile(string username) {
        return null!;
    }

}