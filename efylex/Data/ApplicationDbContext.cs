using egylex.Models.Categories;
using egylex.Models.episodes;
using egylex.Models.MovieCategory;
using egylex.Models.Movies;
using egylex.Models.Seasons;
using egylex.Models.Series;
using egylex.Models.SeriesCategories;
using egylex.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace efylex.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Serie> Series { get; set; }
        public virtual DbSet<Season> Seasons { get; set; }
        public virtual DbSet<Episodes> Episodes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Movie> Movies{ get; set; }
        public virtual DbSet<SeriesCategory> SeriesCategories{ get; set; }
        public virtual DbSet<MoviesCategory> MoviesCategories{ get; set; }








        protected override void OnModelCreating(ModelBuilder builder)
        {
            //relation 1 "1 to many between serie and seasons"
            builder.Entity<Serie>()
            .HasMany(s => s.seasons)
            .WithOne(e => e.Serie);

            //relation 2 "1 to many between seasons and episodes"
            builder.Entity<Season>()
            .HasMany(s => s.Episodes)
            .WithOne(e => e.Season);

            //relation 3 "many to many between movies and category"

            builder.Entity<MoviesCategory>().HasKey(mc => new {mc.MovieId, mc.CategoryId});

            builder.Entity<MoviesCategory>()
                .HasOne<Movie>(mc => mc.Movie)
                .WithMany(m => m.MoviesCategories)
                .HasForeignKey(mc => mc.MovieId);


            builder.Entity<MoviesCategory>()
               .HasOne<Category>(mc => mc.Category)
               .WithMany(c => c.MoviesCategories)
               .HasForeignKey(mc => mc.CategoryId);

            //relation 4 "many to many between series and category"

            builder.Entity<SeriesCategory>().HasKey(mc => new { mc.SeriesId, mc.CategoryId });

            builder.Entity<SeriesCategory>()
                .HasOne<Serie>(sc => sc.Serie)
                .WithMany(s => s.SeriesCategories)
                .HasForeignKey(sc => sc.SeriesId);


            builder.Entity<SeriesCategory>()
               .HasOne<Category>(sc => sc.Category)
               .WithMany(c => c.SeriesCategories)
               .HasForeignKey(sc => sc.CategoryId);

            base.OnModelCreating(builder);
        }

    }
}
