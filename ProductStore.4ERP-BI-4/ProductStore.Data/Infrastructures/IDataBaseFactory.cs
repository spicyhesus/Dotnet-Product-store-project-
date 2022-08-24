using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStore.Data.Infrastructures
{
    public interface IDataBaseFactory : IDisposable
    {
        PSContext DataContext { get; }
    
    }
}
