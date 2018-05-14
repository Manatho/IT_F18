using IT_F18.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_F18.Models
{
    public class BlogDB : DbContext
    {
        public BlogDB(DbContextOptions options) :base(options)
        {
        }

        public DbSet<GalleryEntry> galleryEntry;
        public DbSet<Subscriber> subscribers;
        public DbSet<AboutInfo> aboutinfo;
        public DbSet<IT_F18.Models.AboutInfo> AboutInfo { get; set; }
        public DbSet<IT_F18.Models.Subscriber> Subscriber { get; set; }
        public DbSet<IT_F18.Models.GalleryEntry> GalleryEntry { get; set; }
    }
}
