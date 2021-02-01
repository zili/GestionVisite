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
        Personne Commercial;
        List<int> dejaVisité;
        List<Personne> ordre;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            grd.DataSource = db.Clients.Select(c => new { c.Id, c.Nom, c.Position.X, c.Position.Y }).ToList(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSaisirComm_Click(object sender, EventArgs e)
        {
            Commercial = new Personne(txtId.Text, txtNom.Text, txtX.Text, txtY.Text);
            dejaVisité  = new List<int>();
            ordre       = new List<Personne>();
            Visiter(Commercial, db.Clients);
            grdVisite.DataSource = ordre.Select(c => new { c.Id, c.Nom, c.Position.X, c.Position.Y }).ToList(); ;
            distanceLabel.Text = calculateDistanceTraveled().ToString()+" mètre";
        }

        private void Visiter(Personne commercial, List<Personne> clients)
        {
            Personne plusProche = trouverPlusProche(commercial, clients, dejaVisité);
            if(plusProche!=null)
            {
                ordre.Add(plusProche);
                dejaVisité.Add(plusProche.Id);
                Visiter(plusProche, clients);
            }
        }

        private Personne trouverPlusProche(Personne source, List<Personne> clients, List<int> dejaVisité)
        {
            Personne proche  = null;
            double   minDist =  double.MaxValue;

            foreach (Personne cli in clients)
            {
                if (!dejaVisité.Contains(cli.Id))
                {
                    double dist = Helper.Distance(source, cli);
                    if(dist < minDist)
                    {
                        minDist = dist;
                        proche = cli;
                    }

                }
            }
            return proche;
        }
        private double calculateDistanceTraveled()
        {
            return Enumerable.Range(0, (ordre.Count() - 1))
                .Select((index) => Helper.Distance(ordre[index], ordre[index + 1]))
                .Aggregate(Helper.Distance(Commercial,ordre[0]), (acc, x) => acc + x);
        }
    }
}
