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

        public EventDB? GetEvent(UserDB owner) {
            EventDB ownerRetrieved = (EventDB) db.EventsDB
                                    .Where(ev => ev.Owner.Username.Equals(owner.Username))
                                    .Select(ev => ev);
            return ownerRetrieved;
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
            if (e is null) {
                throw new ArgumentNullException("e (event) cannot be null");
            }
            if(_eventDB == null) {
                _eventDB = new EventDB(e.Title, e.Owner);
            }

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

            if (_eventDB is null) {
                _eventDB = eventDB;
            }
            
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

            if (_eventDB is null) {
                _eventDB = eventDB;
            }

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
            return db.EventsDB.ToList();
        }

    }
}