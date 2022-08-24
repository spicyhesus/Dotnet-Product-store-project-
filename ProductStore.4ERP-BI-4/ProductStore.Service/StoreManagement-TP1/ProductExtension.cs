using ProductStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStore.Service.StoreManagement_TP1
{
    public static class ProductExtension
    {
        public static string ToUpper(this ProductManagement prodManagement,string name)
        {
            return name.ToUpper();
        }
        public static string ToLower(this ProviderManagement provManagement, string name)
        {
            return name.ToLower();
        }

        public static bool InCategory(this ProductManagement prodManagement,Product p,string categoryName)
        {
            return p.Category.CategoryName.Equals(categoryName);
        }
    }
}
