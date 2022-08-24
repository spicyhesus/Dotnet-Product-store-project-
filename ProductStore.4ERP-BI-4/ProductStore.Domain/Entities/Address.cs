using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStore.Domain.Entities
{
    [Owned]
    public class Address
    {
        public string City { get; set; }
        public string StreetAddress { get; set; }
    }
}
