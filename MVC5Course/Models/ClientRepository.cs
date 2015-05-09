using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ClientRepository : EFRepository<Client>, IClientRepository
	{
        public IQueryable<Client> All(string sGender)
        {
            if (sGender == "")
            {
                return All().Where(c => c.IsDelete == false);
            }
            else
            {
                return All().Where(c => c.IsDelete == false && c.Gender == sGender);
            }
        }

        public IQueryable<Client> SearchByCity(string sCity)
        {
            if (sCity == "")
            {
                return All();
            }
            else
            {
                return All().Where(c => c.City == sCity);
            }
        }

        public override IQueryable<Client> All()
        {
            return base.All().Where(c => c.IsDelete == false);
        }

        public Client Find(int id)
        {
            return this.All().Where(c => c.ClientId == id).FirstOrDefault();
        }

        public void Delete(Client client)
        {
            client.IsDelete = true;
        }
	}

	public  interface IClientRepository : IRepository<Client>
	{

	}
}