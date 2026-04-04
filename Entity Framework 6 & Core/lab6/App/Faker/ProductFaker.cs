using Bogus;
using App.Model;

namespace App.Faker
{
    public class ProductFaker : Faker<Product>
    {
        public ProductFaker()
        {
            RuleFor(p => p.Name, f => f.Commerce.ProductName());
            RuleFor(p => p.Description, f => f.Commerce.ProductDescription());
            RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price(10, 1000)));
        }
    }
}