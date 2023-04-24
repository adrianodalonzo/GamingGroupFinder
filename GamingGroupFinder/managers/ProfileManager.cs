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
    private ApplicationContext db = new ApplicationContext();
    private Profile _profile;

    // this is probably just going to create a new profile and add it to the database
    public void CreateProfile(Profile p, User u) {
        ProfileDB profile1 = new ProfileDB(null, p.Name, p.Pronouns, p.Age, p.Bio, p.ProfilePicture);
        var profileUser = (from user in db.UsersDB where user.Username.Equals(u.Username) select user).First();
        profile1.User = profileUser;
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