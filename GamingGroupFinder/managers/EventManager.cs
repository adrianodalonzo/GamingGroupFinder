using GamingGroupFinderDatabase;
using GamingGroupFinderGUI.Models;
using Microsoft.EntityFrameworkCore;

namespace GamingGroupFinder {

    public class EventManager {

        private static EventManager? _instance;
        private static ApplicationContext db = null!;

        private EventManager() {

        }
        
        public static EventManager GetInstance() {
            if(_instance == null) {
                _instance = new EventManager();
            }
            return _instance;
        }

        public void SetLibraryContext(ApplicationContext context) {
            db = context;
        }

        private EventDB _eventDB;

        // public EventManager(Event _event) {
        //     this._event = _event;
        // }

        private List<UserDB> UserToUserDB(List<User> users) {
            List<UserDB> userDBs = new List<UserDB>();
            foreach (User user in users) {
                userDBs.Add(new UserDB(user.Username, user.Password, user.Salt, null));
            }
            return userDBs;
        }

        public EventDB? GetEvent(int id)
        {
            EventDB eventDB = db.EventsDB.Find(id);
            _eventDB = eventDB;
            return eventDB;
        }


        // this is probably just going to create a new event and add it to the database
        public void CreateEvent(Event e) {
            // add checking for an existing event
            // if (e.Title == (from Event in db.EventsDB select Event.Title).Single()) {
            //     throw new ArgumentException("Event already exists");
            // }
            UserDB Owner = (from user in db.UsersDB where user.Username.Equals(e.Owner.Username) select user).Single();
            GameDB Game = (from game in db.GamesDB where game.GameName.Equals(e.Game.Name) select game).Single();
            PlatformDB Platform = (from platform in db.PlatformsDB where platform.PlatformName.Equals(e.Platform.Name) select platform).Single();
            // List<UserDB> UsersAttending = ((List<UserDB>)(from evnt in db.EventsDB where evnt.Title.Equals(e.Title) select evnt));
            // List<UserDB> usersAttending = (from ev in db.EventsDB where ev.Title.Equals(e.Title) select ev.UsersAttending).ToList();
            EventDB eventEntity = new EventDB(Owner, e.Title, e.DateTime, e.Location, Game, Platform, e.Description, UserToUserDB(e.Attendees));
            _eventDB = eventEntity;
            try {
                db.Add(_eventDB);
                db.SaveChanges();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

        public void CreateEvent(EventDB e) {
            try {
                db.Add(e);
                db.SaveChanges();
            } catch(Exception ex) {
                Console.WriteLine(ex);
            }
        }

        public void EditEvent(EventDB eDB) {
            if (_eventDB is null) {
                _eventDB = GetEvent(eDB.EventDBId);
            }
            _eventDB = eDB;

            try {
                db.SaveChanges();
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }

        // this is probably just going to delete an event from the database. not sure what would be taken in as a parameter (event id?, event object, ...)
        public void DeleteEvent(EventDB e) {
            if (_eventDB is null) {
                _eventDB = GetEvent(e.EventDBId);
            }
            try {
                db.EventsDB.Remove(_eventDB);
                db.SaveChanges();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

        // this is probably just going to add a user to the event's list of attendees
        public void AttendEvent(User u) {
            UserDB userEntity = (from user in db.UsersDB where user.Username.Equals(u.Username) select user).Single();
            
            try {
                _eventDB.UsersAttending.Add(userEntity);
                db.SaveChanges();
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }

        // this is probably just going to remove a user from the event's list of attendees
        public void LeaveEvent(User u) {
            UserDB userEntity = (from user in db.UsersDB where user.Username.Equals(u.Username) select user).Single();
            
            try {
                _eventDB.UsersAttending.Remove(userEntity);
                db.SaveChanges();
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }

        // this is probably just going to return the event's list of attendees
        public List<UserDB> ViewAttendees(Event e) {
            List<UserDB> Attendees = new List<UserDB>();
            foreach (UserDB user in _eventDB.UsersAttending) {
                Attendees.Add(user);
            }
            return Attendees;
        }

        // same as search event
        public List<EventDB> FindEvent(Game game, string platform) {
            List<EventDB> EventList = new List<EventDB>();
            for (int i = 0; i < db.EventsDB.Count(); i++) {
                if (db.EventsDB.ElementAt(i).Game.GameName.Equals(game.Name) || db.EventsDB.ElementAt(i).Platform.PlatformName.Equals(platform)) {
                    EventDB DBEvent = db.EventsDB.ElementAt(i);
                    EventList.Add(DBEvent);
                }
            }
            return EventList;
        } 

        public List<EventDB> SearchEvent(string query) {
            // List<EventDB> EventList = new List<EventDB>();
            // for (int i = 0; i < db.EventsDB.Count(); i++) {
            //     if (db.EventsDB.ElementAt(i).Game.GameName.Equals(query) || db.EventsDB.ElementAt(i).Platform.PlatformName.Equals(query)) {
            //         EventDB DBEvent = db.EventsDB.ElementAt(i);
            //         EventList.Add(DBEvent);
            //     }
            // }
            // return EventList;
            List<EventDB> EventList = db.EventsDB
                                        .Include(e => e.Game)
                                        .AsEnumerable()
                                        .Where(e => e.Game.GameName.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                                                    e.Platform.PlatformName.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                                                    e.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                                                    e.Description.Contains(query, StringComparison.OrdinalIgnoreCase))
                                        .ToList();
            return EventList;
        }

    }
}