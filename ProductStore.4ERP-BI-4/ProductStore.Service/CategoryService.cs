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
    public class CategoryService :Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork utk):base(utk)
        {

        }
    }
}
