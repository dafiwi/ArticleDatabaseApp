using System.ComponentModel.DataAnnotations;

namespace ArticleDatabaseApp
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        public string ArticleName { get; set; }
        public string Color { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }  
    }
}