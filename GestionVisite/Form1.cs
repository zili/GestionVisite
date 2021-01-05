using GestionVisite.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionVisite
{
    public partial class Form1 : Form
    {
        DB db = new DB();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            Client rachida = db.FindById(3);

            grd.DataSource = db.Clients.Select(c => 
            new { 
                c.Id, 
                c.Nom, 
                c.Position.X, 
                c.Position.Y,
                dist = Helper.Distance(c, rachida)
            }).ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
