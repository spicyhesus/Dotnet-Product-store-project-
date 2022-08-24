using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStore.Domain.Entities
{
    public class Biological:Product
    {
        public string LabName { get; set; }
        public override string GetMyType()
        {
            return "Biological";
        }
    }
}
