using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProductStore.Domain.Entities
{
    public class Provider : Concept
    {
        
        /*private string myConfirmPass;

        public string ConfirmPassword
        {
            get { return myConfirmPass; }
            set { if (value.Equals(Password))
                    myConfirmPass = value;
                else throw new Exception("Invalid confirmation");
            }
        }

        //propfull +2tab
        private string myPass;
        public string Password
        {
            get { return myPass; }
            set 
            {
                if (value.Length >= 5 && value.Length <= 20)
                    myPass = value;
                else throw new Exception("Incorrect password");
            }
        }*/
        [Required,MinLength(8),DataType(DataType.Password)]
        public string Password { get; set; }
        [Required,DataType(DataType.Password)]
        [NotMapped][Compare("Password")]
        public string ConfirmPassword { get; set; }
        //[DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Key]
        public int Id { get; set; }
        public bool IsApproved { get; set; }
        public string UserName { get; set; }
        public DateTime DateCreated { get; set; }
        //prop de navigation
        public virtual IList<Product> Products { get; set; }//Many to many

        //public bool Login(string username, string password)
        //{
        //    return UserName.Equals(username) && Password.Equals(password);
        //}
        //public bool Login(string username, string password,string email)
        //{
        //    return Login(username,password) && Email.Equals(email);
        //}
        public bool Login(string username, string password, string email=null)
        {
            if (String.IsNullOrEmpty(email))
                return UserName.Equals(username) && Password.Equals(password);
            return UserName.Equals(username) && Password.Equals(password)
                && Email.Equals(email);
        }

        public override string GetDetails()
        {
            string result= "Provider : UserName" + UserName + "Email" + Email;
            if (Products != null)
            {
                foreach (Product prod in Products)
                {
                    result += "\n Product : " + prod.GetDetails();
                }
            }
            return result;
        }

        public void GetProducts(string filtername,string filtervalue)
        {
            switch(filtername.ToLower())
            { 
                case "dateprod":
                foreach (Product p in Products)
                {
                    if(p.DateProd.Equals(filtervalue))
                        Console.WriteLine(p.GetDetails());
                }
                break;
                case "name":
                    foreach (Product p in Products)
                    {
                        if (p.Name.Equals(filtervalue))
                            Console.WriteLine(p.GetDetails());
                    }
                    break;
            }
        }
    }
}
