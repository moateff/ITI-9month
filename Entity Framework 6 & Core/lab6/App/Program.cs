using System;
using App.Faker;
using App.Context;

namespace App
{
    public class Program
    {
        static void Main(string[] args)
        {
            var faker = new ProductFaker();
            var products = faker.Generate(1000);

            using var context = new MyDbContext();
            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}