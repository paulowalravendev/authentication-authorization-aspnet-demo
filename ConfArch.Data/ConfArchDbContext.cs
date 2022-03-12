using ConfArch.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConfArch.Data;

public class ConfArchDbContext : DbContext
{
    public ConfArchDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Attendee> Attendees { get; set; } = null!;
    public DbSet<Conference> Conferences { get; set; } = null!;
    public DbSet<Proposal> Proposals { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Conference>().HasData(new Conference(id: 1, name: "Pluralsight Live",
            location: "Salt Lake City", start: new DateTime(2022, 10, 12)));
        modelBuilder.Entity<Conference>().HasData(new Conference(id: 2, name: "Pluralsight Live", location: "London",
            start: new DateTime(2022, 3, 18)));

        modelBuilder.Entity<Proposal>().HasData(new Proposal(id: 1, conferenceId: 1, speaker: "Roland Guijt",
            title: "Authentication and Authorization in ASP.NET Core"));
        modelBuilder.Entity<Proposal>().HasData(new Proposal(id: 2, conferenceId: 2, speaker: "Cindy Reynolds",
            title: "Authentication and Authorization in ASP.NET Core"));
        modelBuilder.Entity<Proposal>().HasData(new Proposal(id: 3, conferenceId: 2, speaker: "Heather Lipens",
            title: "ASP.NET Core TagHelpers"));

        modelBuilder.Entity<Attendee>().HasData(new Attendee(id: 1, conferenceId: 1, name: "Lisa Overthere"));
        modelBuilder.Entity<Attendee>().HasData(new Attendee(id: 2, conferenceId: 1, name: "Robin Eisenberg"));
        modelBuilder.Entity<Attendee>().HasData(new Attendee(id: 3, conferenceId: 2, name: "Sue Mashmellow"));
    }
}
