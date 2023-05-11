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

        public void SetApplicationContext(ApplicationContext context) {
            db = context;
        }

        private EventDB _eventDB;

        public EventDB? GetEvent(int id)
        {
            EventDB eventDB = db.EventsDB
                                .Include(ev => ev.Platform)
                                .Include(ev => ev.Game)
                                .Include(ev => ev.Owner)
                                .Where(ev => ev.EventDBId == id)
                                .Select(ev => ev).SingleOrDefault();
            _eventDB = eventDB;
            return eventDB;
        }

        public void CreateEvent(EventDB e) {
            if (e is null) {
                throw new ArgumentNullException("e (event) cannot be null");
            }
            _eventDB = new EventDB(e.Title, e.Owner);

            try {
                UserDB existingUser = db.UsersDB
                                        .FirstOrDefault(u => u.Username.Equals(e.Owner.Username));
                
                if(existingUser != null) {
                    _eventDB.Owner = existingUser;
                } else {
                    db.UsersDB.Add(e.Owner);
                    _eventDB.Owner = e.Owner;
                }

                _eventDB.Title = e.Title;
                _eventDB.Time = e.Time;
                _eventDB.Location = e.Location;
                _eventDB.Game = e.Game;
                _eventDB.Platform = e.Platform;
                _eventDB.Description = e.Description;
                _eventDB.UsersAttending = e.UsersAttending;
            
                db.EventsDB.Add(_eventDB);
                db.SaveChanges();
            } catch(Exception ex) {
                Console.WriteLine(ex);
            }
        }

        public void EditEvent(EventDB eDB) {
            if (eDB is null) {
                throw new ArgumentNullException("eDB (eventDB) cannot be null");
            }

            if (_eventDB is null) {
                _eventDB = eDB;
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
            if (e is null) {
                throw new ArgumentNullException("e (eventDB) cannot be null");
            }

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
        public void AttendEvent(EventDB eventDB, string username) {
            if (eventDB is null || username is null) {
                throw new ArgumentNullException("eventDB and username cannot be null");
            }

            _eventDB = eventDB;
            
            UserDB userEntity = (from user in db.UsersDB where user.Username.Equals(username) select user).Single();
            
            try {
                _eventDB.UsersAttending.Add(userEntity);
                db.SaveChanges();
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }

        // this is probably just going to remove a user from the event's list of attendees
        public void LeaveEvent(EventDB eventDB, string username) {
            if (eventDB is null || username is null) {
                throw new ArgumentNullException("eventDB and username cannot be null");
            }

            _eventDB = eventDB;

            UserDB userEntity = (from user in db.UsersDB where user.Username.Equals(username) select user).Single();
            
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
            if (e is null) {
                throw new ArgumentNullException("e (event) cannot be null");
            }
            List<UserDB> Attendees = new List<UserDB>();
            foreach (UserDB user in _eventDB.UsersAttending) {
                Attendees.Add(user);
            }
            return Attendees;
        }

        // same as search event
        public List<EventDB> FindEvent(Game game, string platform) {
            if (game is null || platform is null) {
                throw new ArgumentNullException("game and platform cannot be null");
            }
            
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
            if (query is null) {
                throw new ArgumentNullException("query cannot be null");
            }
            
            List<EventDB> EventList = db.EventsDB
                                        .AsEnumerable()
                                        .Where(e => (e.Game != null && e.Game.GameName.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                                                    (e.Platform != null && e.Platform.PlatformName.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                                                    (e.Title != null && e.Title.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                                                    (e.Description != null && e.Description.Contains(query, StringComparison.OrdinalIgnoreCase)))
                                        .ToList();
            return EventList;
        }

        public List<EventDB> GetEvents() {
            List<EventDB> events = db.EventsDB
                                    .Include(ev => ev.Platform)
                                    .Include(ev => ev.Game)
                                    .Include(ev => ev.Owner)
                                    .Select(ev => ev).ToList();
            return events;
        }

    }
}