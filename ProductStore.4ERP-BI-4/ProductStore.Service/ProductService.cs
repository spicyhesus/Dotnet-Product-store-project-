using ProductStore.Data;
using ProductStore.Data.Infrastructures;
using ProductStore.Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductStore.Service
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork utk):base(utk)
        {

        }
        //implémentation des méthodes spécifiques ( sauf crud)
        public IEnumerable<Product> Get5ProductsByCategory(string catname)
        {
            return GetMany(p => p.Category.CategoryName.Contains(catname)).Take(5);
        }
    }
}
