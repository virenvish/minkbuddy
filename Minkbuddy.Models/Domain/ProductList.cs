using System.Collections.Generic;

namespace Minkbuddy.Models.Domain
{
    public class ProductList
    {
        #region Category
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public Images Image { get; set; }
        public int ProductsCount { get; set; }
        #endregion

        #region ProductList
        public List<ProductMaster> Products { get; set; }
        #endregion
    }

    public class ProductMaster
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public Currency Currency { get; set; }
        public Images Images { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
