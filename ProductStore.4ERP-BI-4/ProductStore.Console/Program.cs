using Microsoft.Extensions.DependencyInjection;
using ProductStore.Data;
using ProductStore.Data.Infrastructures;
using ProductStore.Domain.Entities;
using ProductStore.Service;
using ProductStore.Service.StoreManagement_TP1;
using System;
using System.Collections.Generic;

namespace ProductStore.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");
            #region Objects
            //constructeur paramétré
            Product prod = new Product(new DateTime(2021, 09, 27), "new", "myprod", 10, 1, 23);
            //initialiseur dobjet
            Product prod2 = new Product { Price = 10, Name = "test prod" };
            Chemical Chem = new Chemical
            {
                Address = new Address { 
                City = "Ariana",
                StreetAddress = "Chotrana"
                },
                Name = "Chemical product",
                DateProd=new DateTime(2020,10,02),
                Category=new Category { CategoryName="mycategory"}
            };
            Chemical Chem2 = new Chemical
            {
                Address = new Address { 
                City = "Ben Arous",
                StreetAddress = "Rades"
                },
                Name = "Chemical product2",
                Price=100,Quantity=20,Description="nice",DateProd=DateTime.Now
            };
            //classique
            Provider p = new Provider();
            p.Email = "MedAli.bennasr@esprit.tn";
            p.UserName = "MedAli";
            p.Password = "123456789";
            p.ConfirmPassword = "123456789";
            p.IsApproved = false;
            p.Id = 10;
            p.Products = new List<Product>() {prod,prod2 };

            Provider p2 = new Provider {
                Id=12,
                UserName= "MedAli",
                Email = "MedAli.bennasr@esprit.tn",
                Password = "123456789",
                ConfirmPassword = "123456789",
                IsApproved = false,
                Products = new List<Product>() { prod, prod2 }
            };
            #endregion objects
            #region TP1
            //cwl + 2tab
            //System.Console.WriteLine(" @ du provider = "+p.Email);
            //ProviderManagement provManagement = new ProviderManagement();
            //System.Console.WriteLine("Before = "+p.IsApproved);
            //p.IsApproved = provManagement.SetIsApproved(p);
            //System.Console.WriteLine("After = "+p.IsApproved);

            //System.Console.WriteLine(" Login = "+p.Login("Thouraya", "123456789"));
            //System.Console.WriteLine(" Login = " + p.Login("MedAli", "123456789",
            //    "MedAli.bennasr@esprit.tn"));

            //System.Console.WriteLine("Type chemical = "+Chem.GetMyType());
            //System.Console.WriteLine("Type product = " + prod.GetMyType());
            #endregion TP1
            #region tp2
            //System.Console.WriteLine("\n \n \n ***************************  TP2  *************************");

            //System.Console.WriteLine("Provider by Id "+provManagement.
            //    GetProviderById(10,new List<Provider>{p,p2}).GetDetails());
            //System.Console.WriteLine("Provider by Name " + provManagement.
            //    GetFirstProviderByName("MedAli", new List<Provider> { p, p2 }).GetDetails());

            //ProductManagement productManagement = new ProductManagement(new List<Product> {prod2,Chem,Chem2 });
            //System.Console.WriteLine(" Nb prod by city = "+productManagement.GetCountChemicalByCity("Ariana"));
            //System.Console.WriteLine("**********************************************************************");
            //productManagement.DisplayChemicalsGroupedByCity();
            //System.Console.WriteLine(" To upper = "+productManagement.ToUpper(prod2.Name));
            //System.Console.WriteLine(" In category = "+productManagement.InCategory(Chem, "mycategory"));
            //System.Console.WriteLine("**********************************************************************");
            #endregion
            #region génération de la BDD
            //PSContext myContext = new PSContext();
            //myContext.Chemicals.Add(Chem);//ajouter le produit au DbSet
            ////myContext.Products.Add(prod2);
            //myContext.SaveChanges(); //synchronisation avec la BDD

            //foreach (Product myProduct in myContext.Chemicals)
            //{
            //    System.Console.WriteLine("Product = " + myProduct.Name/*+" Category = " + myProduct.Category.CategoryName*/);
            //    if (myProduct.Category != null)
            //        System.Console.WriteLine(" Category = " + myProduct.Category.CategoryName);

            //}

            #endregion

            #region services avec patterns
            
            var serviceProvider = new ServiceCollection()
            .AddScoped<IProductService , ProductService>()
            .AddTransient<IUnitOfWork, UnitOfWork>()
            .AddSingleton<IDataBaseFactory, DataBaseFactory>()
            .BuildServiceProvider();
            var productService = serviceProvider.GetService<IProductService>();

            productService.Add(Chem);
            productService.Commit();
            System.Console.WriteLine("product added ! ");
            foreach (Product  pp in productService.Get5ProductsByCategory("mycategory"))
            {
                System.Console.WriteLine("Product by category : "+pp.Name);
            }
            
            #endregion
            System.Console.WriteLine("end !! ");
            System.Console.ReadKey();
        }
    }
}
