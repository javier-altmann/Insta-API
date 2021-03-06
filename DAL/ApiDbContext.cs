using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options)
        { }
        
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Hashtag> Hashtags { get; set; }

        public virtual DbSet<PostHashtags> PostHastags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostHashtags>().HasKey(x=> new {x.PostId, x.HashtagId });
            base.OnModelCreating(modelBuilder);
        }
    }
}