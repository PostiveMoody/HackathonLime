using HackathonLime.Domain.OnlineCinema;
using Microsoft.EntityFrameworkCore;

namespace HackathonLime.DAL
{
    public class HackathonLimeDbContext : DbContext
    {
        public DbSet<FilmModel> Films { get; set; }
        public HackathonLimeDbContext() 
        {
        }
        public HackathonLimeDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmModel>().ToTable("Film");
            modelBuilder.Entity<FilmModel>().HasKey("FilmId");
            modelBuilder.Entity<FilmModel>().Property(it => it.FilmId).HasDefaultValueSql("nextval('\"FilmIdSequence\"')");
            modelBuilder.HasSequence<int>("FilmIdSequence").IncrementsBy(1).HasMin(1).HasMax(100000).StartsAt(1);
            base.OnModelCreating(modelBuilder);
        }
    }
}
