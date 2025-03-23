using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chess.Modèles;

namespace Chess
{
    public partial class PlateauGUI : Form
    {
        private FenetrePrincipale fenetrePrincipale;
        private Graphics myGraph;
        private int CaseSourceX = -1;
        private int CaseSourceY = -1;
        public PlateauGUI(FenetrePrincipale fenetrePrincipale)
        {
            InitializeComponent();
            this.fenetrePrincipale = fenetrePrincipale;
            

        }
        private void pnlEchequier_Paint(object sender, PaintEventArgs e)
        {

            myGraph = pnlEchiquier.CreateGraphics();
            SolidBrush myBrush = new SolidBrush(Color.Chocolate);
            int size_W = pnlEchiquier.Width;
            int size_H = pnlEchiquier.Height;

            // Dessine l'échiquier...
            myGraph.DrawRectangle(new Pen(Color.Chocolate), 0, 0, size_W, size_H);
            for (int c = 0; c < 8; c++)
            for (int r = c % 2 == 0 ? 1 : 0; r < 8; r += 2)
                myGraph.FillRectangle(myBrush, r * size_W/8, c *size_H/8,size_W/8, size_H/8);

        }
        
        
        
        

        private void PlateauGUI_Load(object sender, EventArgs e)
        {
            var partieActuelle = fenetrePrincipale.ObtenirPartieActuelle();
            
            lblNomBlanc.Text = $"{partieActuelle.JoueurBlanc.Nom}";
            lblJoueurNoir.Text = $"{partieActuelle.JoueurNoir.Nom}";
        }
        
        
        
        private void AfficherPieces(Graphics graphics, Plateau plateau, int tailleX, int tailleY)
        {
            for (int ligne = 0; ligne < 8; ligne++)
            {
                for (int colonne = 0; colonne < 8; colonne++)
                {
                    Position position = new Position(colonne, ligne);
                    Piece piece = plateau.GetPiece(position);
                    if (piece == null) continue;

                    Bitmap imagePiece = GetImagePiece(piece);
                    
                    if (imagePiece != null)
                    {
                        imagePiece.MakeTransparent(imagePiece.GetPixel(1, 1));
                        graphics.DrawImage(imagePiece, colonne * tailleX, ligne * tailleY, tailleX, tailleY);
                    }
                    
                }
            }
        }
        
        private Bitmap GetImagePiece(Piece piece)
        {
            if (piece.Type is TypePiece.Tour) return piece.IsWhite ? new Bitmap("tourb.bmp") : new Bitmap("tourn.bmp");
            if (piece.Type is TypePiece.Cavalier) return piece.IsWhite ? new Bitmap("cavalierb.bmp") : new Bitmap("cavaliern.bmp");
            if (piece.Type is TypePiece.Fou) return piece.IsWhite ? new Bitmap("foub.bmp") : new Bitmap("foun.bmp");
            if (piece.Type is TypePiece.Reine) return piece.IsWhite ? new Bitmap("reineb.bmp") : new Bitmap("reinen.bmp");
            if (piece.Type is TypePiece.Roi) return piece.IsWhite ? new Bitmap("roib.bmp") : new Bitmap("roin.bmp");
            if (piece.Type is TypePiece.Pion) return piece.IsWhite ? new Bitmap("pionb.bmp") : new Bitmap("pionn.bmp");

            return null;
        }


        private void btnDemarrerPartie_Click(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
            AfficherPieces(myGraph, fenetrePrincipale.ObtenirPlateauActuel(), pnlEchiquier.Width/8, pnlEchiquier.Height/8);
            btnDemarrerPartie.Enabled = false;
        }
        
        private void pnlEchiquier_MouseClick(object sender, MouseEventArgs e)
        {
            
            // Calculer la taille d'une case en fonction de la taille du plateau
            int tailleX = pnlEchiquier.Width / 8;
            int tailleY = pnlEchiquier.Height / 8;

            // Calculer les coordonnées de la case cliquée
            int caseX = e.X / tailleX;
            int caseY = e.Y / tailleY;
            
            // S'il s'agit de la même case de départ...
            if ((this.CaseSourceX == caseX) && (this.CaseSourceY == caseY))
            {
                myGraph.DrawRectangle(new Pen(Color.Chocolate, 2), this.CaseSourceX * tailleX, this.CaseSourceY * tailleY, tailleX, tailleY);
                this.CaseSourceX = this.CaseSourceY = -1;
            }
            // S'il n'y a pas de case départ sélectionnée...
            else if ((this.CaseSourceX == -1) && (this.CaseSourceY == -1))
            {
                this.CaseSourceX = caseX;
                this.CaseSourceY = caseY;
                myGraph.DrawRectangle(new Pen(Color.DarkGreen, 2), this.CaseSourceX * tailleX, this.CaseSourceY * tailleY, tailleX, tailleY);
            }
            // S'il s'agit de la case destination...
            else
            {
                myGraph.DrawRectangle(new Pen(Color.Chocolate, 2), this.CaseSourceX * tailleX, this.CaseSourceY * tailleY, tailleX, tailleY);
                
                //Code pour jouer coup......
                
                Position depart = new Position(this.CaseSourceX, this.CaseSourceY);
                Position destination = new Position(caseX, caseY);
                
                Boolean coupAppliquer = fenetrePrincipale.jouerCoup(depart, destination);
                Console.WriteLine($@"{coupAppliquer}");

                if (coupAppliquer)
                {   
                    pnlEchiquier.Refresh();
                    MettreAJourPlateau();
                }
                else
                {
                    Console.WriteLine("Erreur");
                }
                System.Threading.Thread.Sleep(1000);
                
                this.CaseSourceX = this.CaseSourceY = -1;
            }
            
            
            
        }
        
        public void MettreAJourPlateau()
        {
            AfficherPieces(myGraph, fenetrePrincipale.ObtenirPlateauActuel(), pnlEchiquier.Width/8, pnlEchiquier.Height/8);
        }


    }

}