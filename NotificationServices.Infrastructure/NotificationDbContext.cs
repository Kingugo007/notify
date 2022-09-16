using Microsoft.EntityFrameworkCore;
using NotificationServices.Domain.Models;

namespace NotificationServices.Infrastructure
{
    public class NotificationDbContext : DbContext
    {
      public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options)
      {
      }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<Notification>().HasData(new Notification { Id = Guid.NewGuid().ToString() });
        //    builder.Entity<UserNotification>().HasData(new UserNotification { Id = Guid.NewGuid().ToString() });
        //}
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is Notification entity)
                {
                    entity.CreatedAt = DateTimeOffset.UtcNow;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
