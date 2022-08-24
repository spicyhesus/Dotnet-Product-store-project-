using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProductStore.Domain.Entities
{
    public enum PackagingType
    {
        [Display(Name ="Carton")]
        Carton,
        [Display(Name = "Plastic")]
        Plastic
    }
    public /*sealed*/ class Product:Concept 
    {
        public Product(DateTime dateProd, string description, string name, double price, int productId, int quantity)
        {
            DateProd = dateProd;
            Description = description;
            Name = name;
            Price = price;
            ProductId = productId;
            Quantity = quantity;
        }
        //ctor+2tab
        public Product()
        {

        }
        //prop + 2 tab
        //prop de base
        public PackagingType PType { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Production Date")]
        public DateTime DateProd { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required(ErrorMessage ="This field is required !")]
        [StringLength(25,ErrorMessage ="User input 25 !")]
        [MaxLength(50,ErrorMessage =" Storage max 50 !")]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        public int ProductId { get; set; }
        [Range(0,int.MaxValue)]
        public int Quantity { get; set; }
        public string ImageURL3 { get; set; }
        [Display(Name = "Category")]
        public int? CategoryId { get; set; } // ? : nullable
        //prop de navigation
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }//one to many
        public virtual IList<Provider> Providers { get; set; }//many to many
        public virtual IList<Facture> Factures { get; set; }
        public override string GetDetails()
        {
            return " Name = " + Name + " Price = " + Price;
        }
        public virtual string GetMyType()
        {
            return "UNKNOWN";
        }
    }
}
