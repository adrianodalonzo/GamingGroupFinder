using System.ComponentModel.DataAnnotations.Schema;
using GamingGroupFinderDatabase;

namespace GamingGroupFinderGUI.Models;

public class UserDB {
    public int UserDBId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public ProfileDB? Profile { get; set; }
    [InverseProperty("UsersAttending")]
    public List<EventDB> EventsAttending { get; set; } = new();
    [InverseProperty("Owner")]
    public List<EventDB> EventsOwned { get; set; } = new();

    public UserDB(string username, string password, string salt, ProfileDB profile) {
        this.Username = username;
        this.Password = password;
        this.Salt = salt;
        this.Profile = profile;
    }

    private UserDB() {

    }
}