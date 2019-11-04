using Alphasoft.Models;
using System.Collections.Generic;

namespace Alphasoft.IRepositories
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> GetAllWithCategory();
    }
}
