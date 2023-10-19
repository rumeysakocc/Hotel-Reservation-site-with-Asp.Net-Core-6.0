using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=RKOC\\SQLEXPRESS01;Database=ApiDb;User Id=api;Password=47227892810Ko*c;TrustServerCertificate=true;");

                optionsBuilder.ConfigureWarnings(warnings =>
                    warnings.Default(WarningBehavior.Ignore)
                        // .Log(CoreEventId.QueryCompilationStarting, CoreEventId.SaveChangesCompleted)
                        // https://go.microsoft.com/fwlink/?linkid=2149338 
                        // Savepoints are disabled because Multiple Active Result Sets (MARS) is enabled. 
                        .Throw(RelationalEventId.BoolWithDefaultWarning))
                // , SqlServerEventId.SavepointsDisabledBecauseOfMARS
                //                .UseLazyLoadingProxies()
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                // interceptor
                //                .AddInterceptors(_interceptor)
                // HowToLogSensitiveData
                // All properties should be virtual to use it
                //.UseChangeTrackingProxies()
                .EnableSensitiveDataLogging()
                // HowToLogInfoToConsole
                .LogTo(Console.WriteLine, LogLevel.Information)
                // HowToLogDetailedErrors
                .EnableDetailedErrors(true)
                // HowToLogContextDispose&Init
                .LogTo(Console.WriteLine, new[] { CoreEventId.ContextDisposed, CoreEventId.ContextInitialized })
                // HowToLogDBConnectionAccess
                .LogTo(
                    Console.WriteLine,
                    (eventId, logLevel) => logLevel >= LogLevel.Information
                                   || eventId == RelationalEventId.ConnectionOpened
                                   || eventId == RelationalEventId.ConnectionClosed);
        }


        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SendMessage> SendMessages { get; set; }
        public DbSet<MessageCategory> MessageCategories { get; set; }
    }
}


