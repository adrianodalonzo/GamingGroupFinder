using Microsoft.EntityFrameworkCore;

namespace GamingGroupFinderDatabase;

public class ApplicationContext : DbContext {
    public virtual DbSet<User> Users {get;set;}
    public virtual DbSet<Message> Messages {get;set;}
    public virtual DbSet<Profile> Profiles {get;set;}
    // public virtual DbSet<Contact> Contacts {get;set;}
    public virtual DbSet<Game> Games {get;set;}
    public virtual DbSet<Rank> Ranks {get;set;}
    public virtual DbSet<Platform> Platforms {get;set;}
    public virtual DbSet<Event> Events {get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        string? oracleUser = Environment.GetEnvironmentVariable("ORACLE_APP_USER");
        string? oraclePassword = Environment.GetEnvironmentVariable("ORACLE_APP_PASSWORD");
        optionsBuilder.UseOracle($"User Id={oracleUser};Password={oraclePassword};Data Source=198.168.52.211:1521/pdbora19c.dawsoncollege.qc.ca");
    }
}