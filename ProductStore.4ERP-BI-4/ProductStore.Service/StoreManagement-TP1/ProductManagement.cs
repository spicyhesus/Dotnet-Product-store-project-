using ProductStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductStore.Service.StoreManagement_TP1
{
    public class ProductManagement
    {
        List<Product> myProducts;
        public ProductManagement(List<Product> products)
        {
            myProducts = products;
        }
        public IEnumerable<Chemical> Get5Chemicals(double price)
        {
            //linq
            //var query = from p in myProducts.OfType<Chemical>()
            //           where p.Price > price /*&& p is Chemical*/
            //          select p;
            //return /*(IEnumerable<Chemical>)*/query.Take(5);

            //lambda

            return myProducts.OfType<Chemical>().Where(p => p.Price > price).Take(5);
        }
        public IEnumerable<Product> GetProductsByPrice(double prix)
        {
            //linq
            /*return (from p in myProducts
                    where p.Price > prix
                    select p).Skip(2);*/
            //lambda
            return myProducts.Where(p => p.Price > prix).Skip(2);
        }
        public double GetAveragePrice()
        {
            //return myProducts.Average(p => p.Price);//Lambda
            return (from p in myProducts
                    select p.Price).Average();//linq
        }



        public Product GetProductByMaxPrice()
        {
            return myProducts.OrderBy(p => p.Price).LastOrDefault();//1
            //return myProducts.OrderByDescending(p => p.Price).FirstOrDefault();//2
            //return myProducts.OrderBy(p => p.Price).Reverse().FirstOrDefault();//3
            //double max = myProducts.Max(p => p.Price);
            //return myProducts.Where(p => p.Price == max).First();//4
            //.....
        }

        public int GetCountChemicalByCity(string city)
        {
            return myProducts.OfType<Chemical>().Count(c=>c.Address.City.Equals(city));
        }
        public IEnumerable<Chemical> GetChemicalsByCity()
        {
            return myProducts.OfType<Chemical>().OrderBy(c => c.Address.City);
        }
        public IGrouping<string, IEnumerable<Chemical>> GetChemicalsGroupedByCity()
        {
            return (IGrouping<string, IEnumerable<Chemical>>)
                myProducts.OfType<Chemical>().OrderBy(c => c.Address.City).GroupBy(c => c.Address.City);
        }
        public void DisplayChemicalsGroupedByCity()
        {
            var result=
                myProducts.OfType<Chemical>().OrderBy(c => c.Address.City).GroupBy(c => c.Address.City);

            foreach (var ProductsByCity in result)
            {
                Console.WriteLine("City = "+ProductsByCity.Key);
                foreach (var chemical in ProductsByCity)
                {
                    Console.WriteLine("Product = "+chemical.Name);
                }
            }
        }
    }
}
