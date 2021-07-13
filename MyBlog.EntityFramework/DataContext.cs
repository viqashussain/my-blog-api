using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyBlog.Domain;

namespace MyBlog.EntityFramework
{
    public class DataContext: DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Article> ArticleTags { get; set; }
        public DbSet<AboutMeData> AboutMeData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .ToTable("Articles");
            modelBuilder.Entity<ArticleTag>()
                .ToTable("ArticleTags");
            modelBuilder.Entity<ArticleTag>()
                .HasKey(x => new { x.ArticleId, x.TagId });
            modelBuilder.Entity<ArticleTag>()
                .HasOne(x => x.Article)
                .WithMany(x => x.ArticleTags)
                .HasForeignKey(x => x.ArticleId);
            modelBuilder.Entity<ArticleTag>()
                .HasOne(x => x.Tag)
                .WithMany(x => x.ArticleTags)
                .HasForeignKey(bc => bc.TagId);
        }

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            base.SaveChanges();
        }

        public EntityEntry Entry(object entity)
        {
            return base.Entry(entity);
        }
    }
}
