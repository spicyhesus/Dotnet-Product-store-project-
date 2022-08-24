using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStore.Domain.Entities
{
    public abstract class Concept
    {
        public abstract string GetDetails();
        public void Test()
        {
            Console.WriteLine("Test !!");
        }
        public virtual void Test2()
        {
            //implémentation
            Console.WriteLine("test 2!");
        }

    }
}
