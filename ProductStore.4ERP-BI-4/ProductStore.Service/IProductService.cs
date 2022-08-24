using ProductStore.Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStore.Service
{
    public interface IProductService:IService<Product>
    {
        //signatures des méthodes spécifiques ( sauf CRUD)
        public IEnumerable<Product> Get5ProductsByCategory(string catname);
    }
}
