using EventService.Domain.ConferenceSubscriptions;
using EventService.Domain.EventReviews;
using EventService.Domain.Events;
using EventService.Domain.ExhibitionProposals;
using EventService.Domain.Exhibitions;
using EventService.Domain.Members;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EventService.Infrastructure;

public class EventsContext : DbContext
{
    public DbSet<Exhibition> Exhibitions { get; set; }

    public DbSet<Event> Events { get; set; }

    public DbSet<ExhibitionProposal> ExhibitionProposals { get; set; }

    public DbSet<Member> Members { get; set; }

    public DbSet<ConferenceSubscription> ConferenceSubscriptions { get; set; }

    public DbSet<EventReview> EventReviews { get; set; }

    private readonly ILoggerFactory _loggerFactory;

    public EventsContext(DbContextOptions options, ILoggerFactory loggerFactory)
        : base(options)
    {
        _loggerFactory = loggerFactory;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(_loggerFactory).EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
}