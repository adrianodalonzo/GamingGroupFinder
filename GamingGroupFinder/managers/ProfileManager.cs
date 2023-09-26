/*
    methods:
        - clear profile ??
    figure out how to get images
*/

using GamingGroupFinderDatabase;
using GamingGroupFinderGUI.Models;
using Microsoft.EntityFrameworkCore;

namespace GamingGroupFinder;

public class ProfileManager {

    private static ProfileManager? _instance;
    private static ApplicationContext db = null!;
    private static ProfileDB _profile;

    private ProfileManager() {

    }

    public static ProfileManager GetInstance() {
        if(_instance == null) {
            _instance = new ProfileManager();
        }
        return _instance;
    }

    public void SetApplicationContext(ApplicationContext context) {
        db = context;
    }

    // this is probably just going to create a new profile and add it to the database
    public void CreateProfile(Profile p, User u) {
        UserDB profileUser = (from user in db.UsersDB where user.Username.Equals(u.Username) select user).First();
        ProfileDB profile = new ProfileDB(profileUser, null, null, 0, null, null, new List<InterestDB>(), new List<PlatformDB>(), new List<GameDB>());

        db.Add(profile);
        db.SaveChanges();
        _profile = profile;
    }

    // this is probably just going to delete a profile from the database. not sure what would be taken in as a parameter (profile id?, profile object, ...)
    public void DeleteProfile(Profile p, User u) {
        List<InterestDB> Interests = new List<InterestDB>();
        List<PlatformDB> Platforms = new List<PlatformDB>(); 
        List<GameDB> Games = new List<GameDB>();
        foreach(var interest in p.Interests) {
            InterestDB Interest = (from i in db.InterestsDB where i.InterestName.Equals(interest.Name) select i).First();
            Interests.Add(Interest);
        }
        foreach(var platform in p.Platforms) {
            PlatformDB Platform = (from plat in db.PlatformsDB where plat.PlatformName.Equals(platform.Name) select plat).First();
            Platforms.Add(Platform);
        }
        foreach(var game in p.Games) {
            GameDB Game = (from g in db.GamesDB where g.GameName.Equals(game.Name) select g).First();
            Games.Add(Game);
        }
        UserDB profileUser = (from user in db.UsersDB where user.Username.Equals(u.Username) select user).First();
        ProfileDB toDelete = new ProfileDB(profileUser, p.Name, p.Pronouns, p.Age, p.Bio, p.ProfilePicture, null, null, null);
        db.Remove(toDelete);
        db.SaveChanges();
    }

    // add get profile
    public ProfileDB GetProfile(UserDB u) {
        if (u is null) {
            throw new ArgumentNullException("u (user) cannot be null");
        }
        
        ProfileDB profile = (from p in db.ProfilesDB where p.User.Username.Equals(u.Username) select p).SingleOrDefault();
        if(profile is null) {
            profile = new ProfileDB(u, null!, null!, 0, null!, null!, new List<InterestDB>(), new List<PlatformDB>(), new List<GameDB>());
        }
        profile.Games = db.GamesDB
                        .Where(g => g.Profiles.Contains(profile))
                        .Select(g => g).ToList();
        profile.Interests = db.InterestsDB
                            .Where(i => i.Profiles.Contains(profile))
                            .Select(i => i).ToList();
        profile.Platforms = db.PlatformsDB
                            .Where(p => p.Profiles.Contains(profile))
                            .Select(p => p).ToList();
        return profile;
    }

    public void EditProfile(ProfileDB profile) {
        if (profile is null) {
            throw new ArgumentNullException("profile cannot be null");
        }
        // if(_profile is null) {
        _profile = profile;
        // }
        // _profile.Games = profile.Games;
        // _profile.Interests = profile.Interests;
        // _profile.Platforms = profile.Platforms;
        // _profile.Age = profile.Age;
        // _profile.Bio = profile.Bio;
        // _profile.Name = profile.Name;
        // _profile.Pronouns = profile.Pronouns;
        // _profile.ProfilePicture = profile.ProfilePicture;
        try {
            db.SaveChanges();
        }
        catch (Exception e) {
            Console.WriteLine(e);
        }
    }

    public List<ProfileDB> SearchProfile(string username) {
        if (username is null) {
            throw new ArgumentNullException("username cannot be null");
        }
        
        List<ProfileDB> ProfileList = db.ProfilesDB
                        .Include(p => p.User)
                        .AsEnumerable()
                        .Where(p => (p.User != null && p.User.Username.Contains(username, StringComparison.OrdinalIgnoreCase)) ||
                                    (p.Bio != null && p.Bio.Contains(username, StringComparison.OrdinalIgnoreCase)) ||
                                    (p.Interests != null && p.Interests.Any(i => i.InterestName.Contains(username, StringComparison.OrdinalIgnoreCase))))
                        .ToList();
        return ProfileList;
    }

}