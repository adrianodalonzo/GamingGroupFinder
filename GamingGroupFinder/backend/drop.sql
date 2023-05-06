drop table "__EFMigrationsHistory" cascade constraints purge;
drop table "UsersDB" cascade constraints purge;
drop table "RanksDB" cascade constraints purge;
drop table "ProfilesDB" cascade constraints purge;
drop table "PlatformsDB" cascade constraints purge;
drop table "PlatformDBProfileDB" cascade constraints purge;
drop table "MessagesDB" cascade constraints purge;
drop table "InterestsDB" cascade constraints purge;
drop table "InterestDB" cascade constraints purge;
drop table "InterestDBProfileDB" cascade constraints purge;
drop table "GamesDBRanksDB" cascade constraints purge;
drop table "GameDBRankDB" cascade constraints purge;
drop table "GamesDB" cascade constraints purge;
drop table "GameDBProfileDB" cascade constraints purge;
drop table "GameDBPlatformDB" cascade constraints purge;
drop table "EventsDB" cascade constraints purge;
drop table "EventDBUserDB" cascade constraints purge;

commit;