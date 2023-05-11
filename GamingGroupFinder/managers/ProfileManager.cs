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

    public static ProfileManager getInstance() {
        if(_instance == null) {
            _instance = new ProfileManager();
        }
        return _instance;
    }

    public static ProfileDB GetProfile(int userId) {
        return (from p in db.ProfilesDB where p.UserId == userId select p).FirstOrDefault();
    }

    public void setApplicationContext(ApplicationContext context) {
        db = context;
    }
    
    private static List<InterestDB> InterestListToInterestsDBList(List<Interest> list) {
        List<InterestDB> interests = new List<InterestDB>();
        foreach(Interest i in list) {
            interests.Add(new InterestDB(i.Name));
        }
        return interests;
    }

    private static List<GameDB> GameListToGameDBList(List<Game> list) {
        List<GameDB> games = new List<GameDB>();
        foreach(Game g in list) {
            games.Add(new GameDB(g.Name));
        }
        return games;
    }

    private static List<PlatformDB> PlatformListToPlatformsDBList(List<Platform> list) {
        List<PlatformDB> platforms = new List<PlatformDB>();
        foreach(Platform p in list) {
            platforms.Add(new PlatformDB(p.Name));
        }
        return platforms;
    }

    // this is probably just going to create a new profile and add it to the database
    public static void CreateProfile(Profile p, User u) {
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

    public void EditProfile(Profile p, ProfileDB toEdit) {
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
        UserDB profileUser = (from user in db.UsersDB where user.Username.Equals(p.User.Username) select user).First();
        ProfileDB Edited = new ProfileDB(profileUser, p.Name, p.Pronouns, p.Age, p.Bio, p.ProfilePicture, null, null, null);
        toEdit = Edited;
        db.SaveChanges();
    }

    // add get profile
    public static ProfileDB GetProfile(UserDB u) {
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

    public static void EditProfile(ProfileDB profile) {
        if(_profile is null) {
            _profile = profile;
        }
        _profile.Games = profile.Games;
        _profile.Interests = profile.Interests;
        _profile.Platforms = profile.Platforms;
        _profile.Age = profile.Age;
        _profile.Bio = profile.Bio;
        _profile.Name = profile.Name;
        _profile.Pronouns = profile.Pronouns;
        _profile.ProfilePicture = profile.ProfilePicture;
        try {
            db.Remove(_profile);
            db.SaveChanges();
            db.Add(_profile);
            db.SaveChanges();
        }
        catch (Exception e) {
            return;
        }
    }

    public List<ProfileDB> SearchProfile(string username) {
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