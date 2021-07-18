using System.Collections.Generic;

namespace Minkbuddy.Models.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public Images Images { get; set; }
        public int SubCategoriesCount { get; set; }
        public List<Category> SubCategories { get; set; }
    }
}
