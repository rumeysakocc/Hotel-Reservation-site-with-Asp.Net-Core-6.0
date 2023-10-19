using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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

        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }

        // Bu yöntemi çağırarak "api" kullanıcısına "CREATE DATABASE" yetkisini verebilirsiniz.
        public void GrantCreateDatabasePermission()
        {
            using (var connection = this.Database.GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "USE master; GRANT CREATE DATABASE TO [api];";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}


