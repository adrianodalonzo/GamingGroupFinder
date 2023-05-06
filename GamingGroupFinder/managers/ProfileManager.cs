/*
    methods:
        - clear profile ??
    figure out how to get images
*/

using GamingGroupFinderDatabase;
using GamingGroupFinderGUI.Models;

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
        // List<InterestDB> Interests = InterestListToInterestsDBList(p.Interests);
        // List<PlatformDB> Platforms = PlatformListToPlatformsDBList(p.Platforms); 
        // List<GameDB> Games = GameListToGameDBList(p.Games);
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
            _profile = GetProfile(profile.User);
        }
        _profile.Games = profile.Games;
        _profile.Interests = profile.Interests;
        _profile.Platforms = profile.Platforms;
        db.SaveChanges();
    }

    public List<ProfileDB> SearchProfile(string username) {
        List<ProfileDB> ProfileList = new List<ProfileDB>();
            for (int i = 0; i < db.ProfilesDB.Count(); i++) {
                if (db.ProfilesDB.ElementAt(i).User.Username.Equals(username)) {
                    ProfileDB DBProfile = db.ProfilesDB.ElementAt(i);
                    ProfileList.Add(DBProfile);
                }
            }
            return ProfileList;
    }

}