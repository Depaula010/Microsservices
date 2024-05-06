using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existsProduct = productCollection.Find(p => true).Any();
            if (!existsProduct)
            {
                productCollection.InsertManyAsync(GetMyProducts());
            }
        }

        private static IEnumerable<Product> GetMyProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "201146sd65sd46",
                    Name = "IPhone X",
                    Description = "TesteProduto legal"
                },
                new Product()
                {
                    Id = "201146sd65sd4611as44s",
                    Name = "IPhone 11",
                    Description = "TesteProduto legal2"
                }
            };
        }
    }
}
