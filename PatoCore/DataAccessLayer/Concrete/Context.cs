using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Database=Dbname;Uid=root;Pwd=password;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<About> abouts { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<Blog> blogs { get; set; }
        public DbSet<BlogCategory> blogCategories { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<GalleryCategory> galleryCategories { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Gallery> galleries { get; set; }
        public DbSet<Repeat1> repeat1s { get; set; }
        public DbSet<Repeat2> repeat2s { get; set; }
        public DbSet<Repeat3> repeat3s { get; set; }
        public DbSet<Slider> sliders { get; set; }
        public DbSet<SSS> sSSes { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<MenuCategory> menuCategories { get; set; }
        public DbSet<RCapacity> rCapacities { get; set; }
        public DbSet<RHours> rHours { get; set; }
        public DbSet<Reservation> reservations { get; set; }
        public DbSet<BlogTestimonials> blogTestimonials { get; set; }

    }
}
