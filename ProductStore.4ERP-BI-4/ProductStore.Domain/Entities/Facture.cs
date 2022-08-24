using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProductStore.Domain.Entities
{
    public class Facture
    {
        public DateTime DateAchat { get; set; }
        public double Price { get; set; }
        public int ProductFK { get; set; }
        public int ClientFK { get; set; }
        //prop de navigation
        //[ForeignKey("ClientFK")]
        public virtual Client Client { get; set; }
        public virtual Product Product { get; set; }
    }
}
