using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVisite.model
{
    public class DB
    {
        public List<Client> Clients { get; set; }

        public DB()
        {
            Clients = new List<Client>();
            Clients.Add(new Client(1, "Ali"     , 10, 5));
            Clients.Add(new Client(2, "Omar"    , 8, -3));
            Clients.Add(new Client(3, "Rachida" , 5, 2));
            Clients.Add(new Client(4, "Karima"  , 1, 8));
            Clients.Add(new Client(5, "Allal"   , 0, 3));
        }

        public Client FindById(int id)
        {
            return Clients.Where(c => c.Id == id).FirstOrDefault();
        } 

    }
}
