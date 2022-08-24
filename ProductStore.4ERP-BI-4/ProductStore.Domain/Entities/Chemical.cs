using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStore.Domain.Entities
{
    public class Chemical:Product
    {
        public Address Address { get; set; }
        public string LabName { get; set; }
        public override string GetDetails()
        {
            return base.GetDetails()+
                " City  = "+Address.City+
                " LabName = "+LabName+ 
                " StreetAddress = "+Address.StreetAddress;
        }
        public override string GetMyType()
        {
            //return base.GetMyType();
            return "Chemical";
        }
    }
}
