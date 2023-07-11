using Core.Entities;
using System.Linq.Expressions;

namespace Core.Spacefications
{
    public class ProductsWithTypesAndBrandsSpacification : BaseSpacification<Product>
    {
        public ProductsWithTypesAndBrandsSpacification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

        public ProductsWithTypesAndBrandsSpacification(int id) 
            : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}
