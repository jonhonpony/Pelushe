using System;
using System.Collections.Generic;
using System.Linq;
using TerlikEntities;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TerlikDAL
{
    public class DBCreator : CreateDatabaseIfNotExists<DatabaseContext>
    {
        public static void CreateDatabase()
        {
            using (var context = new DatabaseContext())
            {
                // Eğer veritabanı boşsa, örnek verileri ekleyin
                if (!context.Products.Any() && !context.Categories.Any())
                {
                    var category1 = new Category { Name = "Kadın" };
                    var category2 = new Category { Name = "Erkek" };
                    var category3 = new Category { Name = "Çocuk" };

                    context.Categories.Add(category1);
                    context.Categories.Add(category2);
                    context.Categories.Add(category3);

                    var products = new List<Product>();

                    for (int i = 1; i <= 27; i++)
                    {
                        var category = category1;
                        var imageUrl = "~/img/resim/woman/" + i + "/Ekran Alıntısı.PNG";

                        if (i > 9 && i <= 18)
                        {
                            category = category2;
                            imageUrl = "~/img/resim/man/" + (i - 9) + "/Ekran Alıntısı.PNG";
                        }
                        else if (i > 18)
                        {
                            category = category3;
                            imageUrl = "~/img/resim/kid/" + (i - 18) + "/Ekran Alıntısı.PNG";
                        }

                        var product = new Product
                        {
                            Name = "Ürün " + i,
                         
                            ImageUrl = imageUrl,
                            Category = category
                        };

                        products.Add(product);
                    }

                    context.Products.AddRange(products);

                    context.SaveChanges();
                }
            }
        }
    }
}