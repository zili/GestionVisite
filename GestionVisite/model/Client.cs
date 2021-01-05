using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVisite.model
{
    public class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public Geometry Position { get; set; }

        public Client()
        {

        }
        public Client(int id, string nom, double x, double y)
        {
            this.Id = id;
            this.Nom = nom;
            this.Position = new Geometry(x, y);
        }


    }
}
