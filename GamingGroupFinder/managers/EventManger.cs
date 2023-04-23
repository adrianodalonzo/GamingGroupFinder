/*
    methods:
        - connections to ranks/platforms/games ????
*/

namespace GamingGroupFinder;

public class EventManager {

    private Event _event;

    public EventManager(Event _event) {
        this._event = _event;
    }

    // this is probably just going to create a new event and add it to the database
    public Event CreateEvent(Event e) {
        return null!;
    }

    public Event EditEvent(Event e) {
        return null!;
    }

    // this is probably just going to delete an event from the database. not sure what would be taken in as a parameter (event id?, event object, ...)
    public void DeleteEvent() {

    }

    // this is probably just going to add a user to the event's list of attendees
    public void AttendEvent(User user) {
        
    }

    // this is probably just going to remove a user from the event's list of attendees
    public void LeaveEvent(User user) {
        
    }

    // this is probably just going to return the event's list of attendees
    public string ViewAttendees() {
        return "";
    }

    // same as search event
    public List<Event> FindEvent(Game game, string platform, string rank) {
        return null!;
    } 

}