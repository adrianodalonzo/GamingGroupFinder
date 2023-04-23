/*
    methods:
        - clear profile ??
    figure out how to get images
*/

// public List<Event> FindEvent(Game game, string platform, string rank) {
    
// }

namespace GamingGroupFinderDatabase;

public class ProfileManager {

    private Profile _profile;
    
    public ProfileManager(Profile _profile) {
        this._profile = _profile;
    }

    // this is probably just going to create a new profile and add it to the database
    public Event CreateProfile(Profile p) {
        return null!;
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