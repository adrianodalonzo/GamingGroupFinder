using Microsoft.EntityFrameworkCore;

namespace GamingGroupFinderDatabase;

public class ApplicationContext : DbContext {
    public DbSet<UserDB> UsersDB {get;set;}
    public DbSet<MessageDB> MessagesDB {get;set;}
    public DbSet<ProfileDB> ProfilesDB {get;set;}
    // public DbSet<Contact> Contacts {get;set;}
    public DbSet<GameDB> GamesDB {get;set;}
    public DbSet<GameDBRankDB> GamesDBRanksDB {get;set;}
    public DbSet<RankDB> RanksDB {get;set;}
    public DbSet<PlatformDB> PlatformsDB {get;set;}
    public DbSet<EventDB> EventsDB {get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        string? oracleUser = Environment.GetEnvironmentVariable("ORACLE_APP_USER");
        string? oraclePassword = Environment.GetEnvironmentVariable("ORACLE_APP_PASSWORD");
        optionsBuilder.UseOracle($"User Id={oracleUser};Password={oraclePassword};Data Source=198.168.52.211:1521/pdbora19c.dawsoncollege.qc.ca");
    }
}