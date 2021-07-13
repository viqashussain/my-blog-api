using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyBlog.Domain;

namespace MyBlog.EntityFramework
{
    public interface IDataContext
    {
        DbSet<Article> Articles { get; set; }
        DbSet<ArticleCategory> ArticleCategories { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<Article> ArticleTags { get; set; }
        DbSet<AboutMeData> AboutMeData { get; set; }

        Task SaveChangesAsync();
        void SaveChanges();
        EntityEntry Entry(object entity);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
