using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class PlateauGUI : Form
    {
        private FenetrePrincipale fenetrePrincipale;
        public PlateauGUI(FenetrePrincipale fenetrePrincipale)
        {
            InitializeComponent();
            this.fenetrePrincipale = fenetrePrincipale;
            

        }
        private void pnlEchequier_Paint(object sender, PaintEventArgs e)
        {

            Graphics myGraph = pnlEchequier.CreateGraphics();
            SolidBrush myBrush = new SolidBrush(Color.Chocolate);
            int size_W = pnlEchequier.Width;
            int size_H = pnlEchequier.Height;

            // Dessine l'échiquier...
            myGraph.DrawRectangle(new Pen(Color.Chocolate), 0, 0, size_W, size_H);
            for (int c = 0; c < 8; c++)
            for (int r = c % 2 == 0 ? 1 : 0; r < 8; r += 2)
                myGraph.FillRectangle(myBrush, r * size_W/8, c *size_H/8,size_W/8, size_H/8);

        }
        
        /*private void pnlEchequier_Paint(object sender, PaintEventArgs e)
        {
            Graphics myGraph = e.Graphics;
            int tileSize = 33; // Taille d'une case
            int boardSize = tileSize * 8; // 400 pixels exactement

            // Dessine l'échiquier avec un léger décalage pour éviter de déborder
            myGraph.DrawRectangle(new Pen(Color.Chocolate), 0, 0, boardSize - 1, boardSize - 1);

            Brush myBrush = new SolidBrush(Color.Black);
            for (int c = 0; c < 8; c++)
            for (int r = (c % 2 == 0 ? 1 : 0); r < 8; r += 2)
                myGraph.FillRectangle(myBrush, r * tileSize, c * tileSize, tileSize, tileSize);
        }*/

        private void PlateauGUI_Load(object sender, EventArgs e)
        {
            var partieActuelle = fenetrePrincipale.ObtenirPartieActuelle();
            
            lblNomBlanc.Text = $"{partieActuelle.JoueurBlanc.Nom}";
            lblJoueurNoir.Text = $"{partieActuelle.JoueurNoir.Nom}";
        }
    }

}