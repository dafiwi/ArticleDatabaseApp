using Microsoft.EntityFrameworkCore;

namespace ArticleDatabaseApp
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = ArticleData.db");
        }

        public DbSet<Article> Articles { get; set; }
    }
}
