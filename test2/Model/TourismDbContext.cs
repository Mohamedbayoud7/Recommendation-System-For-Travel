using Microsoft.EntityFrameworkCore;

namespace test2.Model
{
    public class TourismDbContext : DbContext
    {
        public TourismDbContext(DbContextOptions<TourismDbContext> options) : base(options)
        { }

        public DbSet<user> user { get; set; }
        public DbSet<cities> cities { get; set; }
        public DbSet<hotels> hotels { get; set; }
        public DbSet<historicalplaces> historicalplaces { get; set; }
        public DbSet<trips> trips { get; set; }
        public DbSet<hotelbookings> hotelbookings { get; set; }
        public DbSet<tripBookings> tripBookings { get; set; }
        public DbSet<reviews> reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //one to many
            //city => hotels
            modelBuilder.Entity<hotels>()
        .HasOne(h => h.cities)
        .WithMany(c => c.hotels)
        .HasForeignKey(h => h.city_id)
        .OnDelete(DeleteBehavior.Cascade);
            //cities => historical_places
            modelBuilder.Entity<historicalplaces>()
                .HasOne(hp => hp.cities)
                .WithMany(c => c.historicalPlaces)
                .HasForeignKey(hp => hp.city_id);

            //cities => trips
            modelBuilder.Entity<trips>()
                .HasOne(t => t.cities)
                .WithMany(c => c.trips)
                .HasForeignKey(t => t.city_id);

            //user => tripBookings
            modelBuilder.Entity<tripBookings>()
                .HasOne(tb => tb.user)
                .WithMany(u => u.tripBookings)
                .HasForeignKey(tb => tb.user_id);

            // trips => tripBookings
            modelBuilder.Entity<tripBookings>()
                .HasOne(tb => tb.trips)
                .WithMany(t => t.tripBookings)
                .HasForeignKey(tb => tb.trip_id);

            // user => hotelbookings
            modelBuilder.Entity<hotelbookings>()
                .HasOne(hb => hb.user)
                .WithMany(u => u.hotelbookings)
                .HasForeignKey(hb => hb.user_id);

            //hotels => hotelbookings
            modelBuilder.Entity<hotelbookings>()
                .HasOne(hb => hb.hotels)
                .WithMany(h => h.hotelbookings)
                .HasForeignKey(hb => hb.hotel_id);

            //user => reviews
            modelBuilder.Entity<reviews>()
                .HasOne(r => r.user)
                .WithMany(u => u.reviews)
                .HasForeignKey(r => r.user_id);

            //trips => reviews
            modelBuilder.Entity<reviews>()
                .HasOne(r => r.trips)
                .WithMany(t => t.reviews)
                .HasForeignKey(r => r.trip_id)
                .OnDelete(DeleteBehavior.Cascade);

            //hotels => reviews
            modelBuilder.Entity<reviews>()
                .HasOne(r => r.hotels)
                .WithMany(h => h.reviews)
                .HasForeignKey(r => r.hotel_id)
                .OnDelete(DeleteBehavior.Cascade);
            //many to many
            // user <=> hotels
            modelBuilder.Entity<hotelbookings>()
                .HasKey(hb => new { hb.user_id, hb.hotel_id });

            //user <=> trips
            modelBuilder.Entity<tripBookings>()
                .HasKey(tb => new { tb.user_id, tb.trip_id });

            modelBuilder.Entity<historicalplaces>().ToTable("Historical_Places");
            modelBuilder.Entity<hotels>().ToTable("Hotels");
            modelBuilder.Entity<cities>().ToTable("cities");
        }
    }
}