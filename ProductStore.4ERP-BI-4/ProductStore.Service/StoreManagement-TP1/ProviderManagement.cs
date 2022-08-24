using ProductStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductStore.Service.StoreManagement_TP1
{
    public class ProviderManagement
    {
        #region TP1
        public bool SetIsApproved(Provider p)
        {
            if (p.Password.Equals(p.ConfirmPassword))
                return true;
            else return false;
        }
        public bool SetIsApproved2(Provider p)
        {
            return p.Password.Equals(p.ConfirmPassword);    
        }
        public bool SetIsApproved3(Provider p)
        {
            return p.Password.CompareTo(p.ConfirmPassword)==0;
        }
        public bool SetIsApproved(string Password,string ConfirmPassword)
        {
            return Password.CompareTo(ConfirmPassword) == 0;
        }
        #endregion TP1
        #region TP2
        public IEnumerable<Provider> GetProvidersByName(string name,List<Provider> myProviders)
        {
            //classique
            /*List<Provider> result = new List<Provider>();
            foreach (Provider p in myProviders)
            {
                if (p.UserName.Contains(name))
                    result.Add(p);
            }
            return result.AsEnumerable();*/
            //linq
            var query = from p in myProviders
                        where p.UserName.Contains(name)
                        select p;
            return query.AsEnumerable();
        }

        public Provider GetFirstProviderByName(string name,List<Provider> myProviders)
        {
            var query = from p in myProviders
                        where p.UserName.StartsWith(name)
                        select p;
            return query.FirstOrDefault();//First() génére une exception si la liste est vide
        }

        public Provider GetProviderById(int id,List<Provider> providers)
        {
            return(from p in providers
            where p.Id == id
            select p).SingleOrDefault();

        }
        #endregion TP2
    }
}
