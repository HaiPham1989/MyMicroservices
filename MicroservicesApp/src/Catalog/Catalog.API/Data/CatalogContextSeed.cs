using Catalog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>
            {
                new Product()
                {
                    Name = "Iphone X",
                    Summary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum ullamcorper elementum sem non consequat. Proin orci mi, pulvinar rhoncus leo in, molestie rhoncus nisi.",
                    Description = "Vivamus eleifend massa nisl, id vulputate ipsum auctor id. Nunc id faucibus tellus. Etiam lobortis vel magna a gravida. Aliquam id leo euismod tellus tempor faucibus ac ut erat. ",
                    ImageFile = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "SamSung Galaxy S10",
                    Summary = "Aenean eu cursus nulla, quis euismod dui. Aliquam erat volutpat. Integer molestie eros enim, a varius erat fringilla ut. Suspendisse vel tortor feugiat, euismod metus ut, consectetur orci.",
                    Description = "Aliquam ligula orci, congue et dui non, aliquam tempus dui. In in cursus augue. Morbi et magna accumsan, dignissim nunc eu, feugiat sem. Mauris accumsan sem id orci pharetra, sit amet lacinia lacus viverra",
                    ImageFile = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "Vsmart V-3",
                    Summary = "Cras aliquam accumsan ante et pretium. Vestibulum a sollicitudin ante. Sed dictum suscipit enim non eleifend. Aliquam risus justo, faucibus et suscipit a, pharetra a enim",
                    Description = "Donec pulvinar erat non est feugiat cursus. Sed augue erat, gravida sed tempus vitae, tincidunt sit amet sapien. Integer sed placerat metus.",
                    ImageFile = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    Name = "Oppo VL",
                    Summary = "Quisque mattis elementum ipsum, vel fermentum nisi ullamcorper et. Curabitur at odio rhoncus, scelerisque arcu vel, pretium tellus. Mauris ultricies augue volutpat, facilisis orci sit amet, viverra ligula. Curabitur dictum et velit sed commodo. Pellentesque facilisis laoreet quam tempus venenatis.",
                    Description = "Vivamus dapibus est nisl, id pretium risus faucibus eget. Suspendisse non tortor congue, varius augue id, dictum purus. Etiam semper nibh a congue vestibulum.",
                    ImageFile = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                }
            };
        }
    }
}