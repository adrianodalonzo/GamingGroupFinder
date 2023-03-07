# 410Project

# Design Basics

For this application, we will be implementing a gaming group finder. Changes to be made:

## Profiles:

    - Instead of school they attend to, we will ask for the platform of choice.
    - Instead of program they're in, we will ask for what their current rank.
    - Instead of courses they're taking, we will ask them what games they are currently playing.
    - Instead of specific courses they want to study, we will ask which games they would like to play.
    - Instead of non-academic hobbies, we will ask for actvities they do outside of gaming.

## Events

    - Instead of class tests and group study sessions, we will have major events likes tournaments, and smaller events like smaller group gaming sessions.
    - Instead of subject, course, program, and/or school with which event is associated, we will use the game on a specific platform, for people in a specific rank.

Some possible classes needed: 

    - User: 
        username and password. Methods: newAccount(username, password), verifyUser(user), changePassword(), deleteAccount()
    - Profile:
        user, name, pronouns, age, platform, games, bio, profile picture, interests. Methods: createProfile(user), editProfile(user), clearData(user)
    - Event: 
        title, time/date, location, game, platform, rank, description, owner and attendees. Methods: createEvent(), editEvent(event), attendEvent(user), leaveEvent(user), viewAttendees(event)
    - Message:
        sender, recipient, time sent, message, message status. Methods: createMessage(), listMessages(), markSeen(message)
    - Game:
        title, genre, rank

Unit tests:

    - check that changing the password of the user actually changes it in the database.
    - fields for a profile actually change.
    - checking that the number of users created increases once creating a new user/profile. same thing for events.
    - Able to retrieve a list of messages.
    - Check that status of message actually changes.
    ...

# Teamwork Agreements

    To ensure our code is readable,

    - Write comments (who wrote it/what its doing)
    - When one person writes code, show it to other members. If the other members are able to read and understand the code, then its readable. Make changes when given advice
    - Share code frequently (commit often, communicate with teamates frequently).

    To ensure committed code is functional,

        - Test as we write
        - Write test code in another class
        - when help is required with code that isn't functional, we will put code in another branch (debug branch)

    To test code, When a major implementation is made, we test it right away to make sure it performs as expected.

    To divide work,

        Adriano: Presentation Layer
        Vincent: Data Layer
        Charles: Business Logic Layer

    To ensure application is robust and imune to user errors,

        - Data validation (try/catch, while loops, recursion, etc)

    To ensure we have standalone classes that can be tested:

        - Separating contents of application (logic, database, presentation, etc...) into different parts.