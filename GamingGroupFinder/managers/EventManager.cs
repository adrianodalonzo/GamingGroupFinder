using GamingGroupFinderDatabase;

namespace GamingGroupFinder {

    public class EventManager {

        private ApplicationContext db = new ApplicationContext();
        // private Event _event;

        // public EventManager(Event _event) {
        //     this._event = _event;
        // }

        // this is probably just going to create a new event and add it to the database
        public void CreateEvent(Event e) {
            // add checking for an existing event
            // if (e.Title == (from Event in db.EventsDB select Event.Title).Single()) {
            //     throw new ArgumentException("Event already exists");
            // }
            UserDB Owner = (from user in db.UsersDB where user.Username.Equals(e.Owner.Username) select user).Single();
            GameDB Game = (from game in db.GamesDB where game.GameName.Equals(e.Game.Name) select game).Single();
            PlatformDB Platform = (from platform in db.PlatformsDB where platform.PlatformName.Equals(e.Platform.Name) select platform).Single();
            RankDB MinRank = (from rank in db.RanksDB where rank.RankName.Equals(e.MinRank.RankName) && rank.RankValue >= e.MinRank.RankValue select rank).Single();
            RankDB MaxRank = (from rank in db.RanksDB where rank.RankName.Equals(e.MaxRank.RankName) && rank.RankValue == e.MaxRank.RankValue select rank).Single();
            EventDB eventEntity = new EventDB(Owner, e.Title, e.DateTime, e.Location, Game, Platform, MinRank, MaxRank, e.Description);
            db.Add(eventEntity);
            db.SaveChanges();
        }

        public void EditEvent(Event e, EventDB toEdit) {
            UserDB Owner = (from user in db.UsersDB where user.Username.Equals(e.Owner.Username) select user).Single();
            GameDB Game = (from game in db.GamesDB where game.GameName.Equals(e.Game.Name) select game).Single();
            PlatformDB Platform = (from platform in db.PlatformsDB where platform.PlatformName.Equals(e.Platform.Name) select platform).Single();
            RankDB MinRank = (from rank in db.RanksDB where rank.RankName.Equals(e.MinRank.RankName) select rank).Single();
            RankDB MaxRank = (from rank in db.RanksDB where rank.RankName.Equals(e.MaxRank.RankName) select rank).Single();
            EventDB editedEvent = new EventDB(Owner, e.Title, e.DateTime, e.Location, Game, Platform, MinRank, MaxRank, e.Description);
            toEdit = editedEvent;
            db.SaveChanges();
        }

        // this is probably just going to delete an event from the database. not sure what would be taken in as a parameter (event id?, event object, ...)
        public void DeleteEvent(Event e) {
            UserDB Owner = (from user in db.UsersDB where user.Username.Equals(e.Owner.Username) select user).Single();
            GameDB Game = (from game in db.GamesDB where game.GameName.Equals(e.Game.Name) select game).Single();
            PlatformDB Platform = (from platform in db.PlatformsDB where platform.PlatformName.Equals(e.Platform.Name) select platform).Single();
            RankDB MinRank = (from rank in db.RanksDB where rank.RankName.Equals(e.MinRank.RankName) select rank).Single();
            RankDB MaxRank = (from rank in db.RanksDB where rank.RankName.Equals(e.MaxRank.RankName) select rank).Single();
            EventDB toDelete = new EventDB(Owner, e.Title, e.DateTime, e.Location, Game, Platform, MinRank, MaxRank, e.Description);
            db.EventsDB.Remove(toDelete);
            db.SaveChanges();
        }

        // this is probably just going to add a user to the event's list of attendees
        public void AttendEvent(User u, Event e) {
            UserDB Owner = (from user in db.UsersDB where user.Username.Equals(e.Owner.Username) select user).Single();
            GameDB Game = (from game in db.GamesDB where game.GameName.Equals(e.Game.Name) select game).Single();
            PlatformDB Platform = (from platform in db.PlatformsDB where platform.PlatformName.Equals(e.Platform.Name) select platform).Single();
            RankDB MinRank = (from rank in db.RanksDB where rank.RankName.Equals(e.MinRank.RankName) select rank).Single();
            RankDB MaxRank = (from rank in db.RanksDB where rank.RankName.Equals(e.MaxRank.RankName) select rank).Single();
            EventDB eventEntity = new EventDB(Owner, e.Title, e.DateTime, e.Location, Game, Platform, MinRank, MaxRank, e.Description);
            UserDB userEntity = (from user in db.UsersDB where user.Username.Equals(u.Username) select user).Single();
            eventEntity.UsersAttending.Add(userEntity);
            db.SaveChanges();
        }

        // this is probably just going to remove a user from the event's list of attendees
        public void LeaveEvent(User u, Event e) {
            UserDB Owner = (from user in db.UsersDB where user.Username.Equals(e.Owner.Username) select user).Single();
            GameDB Game = (from game in db.GamesDB where game.GameName.Equals(e.Game.Name) select game).Single();
            PlatformDB Platform = (from platform in db.PlatformsDB where platform.PlatformName.Equals(e.Platform.Name) select platform).Single();
            RankDB MinRank = (from rank in db.RanksDB where rank.RankName.Equals(e.MinRank.RankName) select rank).Single();
            RankDB MaxRank = (from rank in db.RanksDB where rank.RankName.Equals(e.MaxRank.RankName) select rank).Single();
            EventDB eventEntity = new EventDB(Owner, e.Title, e.DateTime, e.Location, Game, Platform, MinRank, MaxRank, e.Description);
            UserDB userEntity = (from user in db.UsersDB where user.Username.Equals(u.Username) select user).Single();
            eventEntity.UsersAttending.Remove(userEntity);
            db.SaveChanges();
        }

        // this is probably just going to return the event's list of attendees
        public List<UserDB> ViewAttendees(Event e) {
            List<UserDB> Attendees = new List<UserDB>();
            UserDB Owner = (from user in db.UsersDB where user.Username.Equals(e.Owner.Username) select user).Single();
            GameDB Game = (from game in db.GamesDB where game.GameName.Equals(e.Game.Name) select game).Single();
            PlatformDB Platform = (from platform in db.PlatformsDB where platform.PlatformName.Equals(e.Platform.Name) select platform).Single();
            RankDB MinRank = (from rank in db.RanksDB where rank.RankName.Equals(e.MinRank.RankName) select rank).Single();
            RankDB MaxRank = (from rank in db.RanksDB where rank.RankName.Equals(e.MaxRank.RankName) select rank).Single();
            EventDB eventEntity = new EventDB(Owner, e.Title, e.DateTime, e.Location, Game, Platform, MinRank, MaxRank, e.Description);
            foreach (UserDB user in eventEntity.UsersAttending) {
                Attendees.Add(user);
            }
            return Attendees;
        }

        // same as search event
        public List<EventDB> FindEvent(Game game, string platform, string rank) {
            List<EventDB> EventList = new List<EventDB>();
            for (int i = 0; i < db.EventsDB.Count(); i++) {
                if (db.EventsDB.ElementAt(i).Game.GameName.Equals(game.Name) || db.EventsDB.ElementAt(i).Platform.PlatformName.Equals(platform) || db.EventsDB.ElementAt(i).MinRank.RankName.Equals(rank)) {
                    EventDB DBEvent = db.EventsDB.ElementAt(i);
                    EventList.Add(DBEvent);
                }
            }
            return EventList;
        } 

    }
}