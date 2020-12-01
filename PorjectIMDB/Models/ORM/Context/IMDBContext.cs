using Microsoft.EntityFrameworkCore;
using ProjectIMDB.Models.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Models.ORM.Context
{
    public class IMDBContext : DbContext
    {
        public IMDBContext(DbContextOptions<IMDBContext> options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }
        public DbSet<MovieDirector> MovieDirectors { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieScenarist> MovieScenarists { get; set; }
        public DbSet<MovieStar> MovieStars { get; set; }
        public DbSet<PersonJob> PersonJobs { get; set; }

    }
}
