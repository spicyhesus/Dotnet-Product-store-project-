using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductStore.Domain.Entities
{
    public class Client
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Key]
        public int CIN { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        //prop de navigation
        public virtual IList<Facture> Factures { get; set; }

    }
}
