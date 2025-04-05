using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;


namespace Chess
{
    public partial class PlateauGUI : Form
    {
        private FenetrePrincipale fenetrePrincipale;
        private int partieID;
        Graphics myGraph;
        int CaseSourceX = -1; 
        int CaseSourceY = -1;
        public PlateauGUI(FenetrePrincipale fenetrePrincipale, int partieID)
        {
            InitializeComponent();
            this.fenetrePrincipale = fenetrePrincipale;
            this.partieID = partieID;
            
        }
        
        public int PartieID
        {
            get { return partieID; }
        }
        
        private void pnlEchequier_Paint(object sender, PaintEventArgs e)
        {

            myGraph = pnlEchiquier.CreateGraphics();
            SolidBrush myBrush = new SolidBrush(Color.Chocolate);
            int sizeW = pnlEchiquier.Width;
            int sizeH = pnlEchiquier.Height;

            // Dessine l'échiquier...
            myGraph.DrawRectangle(new Pen(Color.Chocolate), 0, 0, sizeW, sizeH);
            for (int c = 0; c < 8; c++)
            for (int r = c % 2 == 0 ? 1 : 0; r < 8; r += 2)
                myGraph.FillRectangle(myBrush, r * sizeW/8, c *sizeH/8,sizeW/8, sizeH/8);

        }
        
        private void PlateauGUI_Load(object sender, EventArgs e)
        {
            var (nomBlanc, nomNoir) = fenetrePrincipale.ObtenirNomJoueur();
            
            lblNomBlanc.Text = $@"{nomBlanc}";
            lblJoueurNoir.Text = $@"{nomNoir}";
        }
        
        private void AfficherPieces(Graphics graphics, string plateauString, int tailleX, int tailleY)
        {
            char[] piece = plateauString.ToCharArray();
            
            for (int ligne = 0; ligne < 8; ligne++)
            {
                for (int colonne = 0; colonne < 8; colonne++)
                {
                    char symbole = piece[colonne * 8 + ligne]; 
                    if (symbole == '-') continue; 

                    Bitmap imagePiece = GetImagePiece(symbole); 
                    if (imagePiece != null)
                    {
                        imagePiece.MakeTransparent(imagePiece.GetPixel(1, 1));
                        graphics.DrawImage(imagePiece, colonne * tailleX, ligne * tailleY, tailleX, tailleY);
                    }
                }
            }
        }
        
        private Bitmap GetImagePiece(char symbole)
        {
            switch (symbole)
            {
                case 'p':
                    return  new Bitmap("pionn.bmp");
                    
                case 'P':
                    return new Bitmap("pionb.bmp");
                case 't':
                    return new Bitmap("tourn.bmp");
                case 'T':
                    return new Bitmap("tourb.bmp");
                case 'c':
                    return new Bitmap("cavaliern.bmp");
                case 'C':
                    return new Bitmap("cavalierb.bmp");
                case 'f':
                    return new Bitmap("foun.bmp");
                case 'F':
                    return new Bitmap("foub.bmp");
                case 'q':
                    return new Bitmap("reinen.bmp");
                case 'Q':
                    return new Bitmap("reineb.bmp");
                case 'r':
                    return new Bitmap("roin.bmp");
                case 'R':
                     return new Bitmap("roib.bmp");
            }

            return null;
        }

        private void btnDemarrerPartie_Click(object sender, EventArgs e)
        {
            //throw new System.NotImplementedException();
            AfficherPieces(myGraph, fenetrePrincipale.ObtenirPlateauActuel(partieID), pnlEchiquier.Width/8, pnlEchiquier.Height/8);
            btnDemarrerPartie.Enabled = false;
            AfficherMessage("Tour du joueur Blanc");
        }
        
        private void pnlEchiquier_MouseClick(object sender, MouseEventArgs e)
        {
            // Calculer la taille d'une case en fonction de la taille du plateau
            int tailleX = pnlEchiquier.Width / 8;
            int tailleY = pnlEchiquier.Height / 8;

            // Calculer les coordonnées de la case cliquée
            int caseX = e.X / tailleX;
            int caseY = e.Y / tailleY;

            if (btnDemarrerPartie.Enabled == false)
            {
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
                
                    Boolean coupAppliquer = fenetrePrincipale.jouerCoup(CaseSourceX, CaseSourceY, caseX, caseY, partieID);
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
           
        }
        
        public void MettreAJourPlateau()
        {
            AfficherPieces(myGraph, fenetrePrincipale.ObtenirPlateauActuel(partieID), pnlEchiquier.Width/8, pnlEchiquier.Height/8);
            var (pointBlanc, pointNoir) = fenetrePrincipale.ObtenirPoint();
            lblPointBlanc.Text = $@"{pointBlanc}";
            lblPointNoir.Text = $@"{pointNoir}";
        }
        
        public void AfficherMessageErreur(string message)
        {
            // Mettre à jour le texte du label avec le message d'erreur
            lblTxt.Text = message;
            // Vous pouvez aussi personnaliser la couleur ou d'autres propriétés si nécessaire
            lblTxt.ForeColor = Color.Red;  // Exemple : afficher le texte en rouge
        }
        
        public void AfficherMessage(string message)
        {
            // Mettre à jour le texte du label avec le message d'erreur
            lblTxt.Text = message;
            // Vous pouvez aussi personnaliser la couleur ou d'autres propriétés si nécessaire
            lblTxt.ForeColor = Color.MidnightBlue;  // Exemple : afficher le texte en rouge
        }
        
        private void btnAbandon_Click(object sender, EventArgs a)
        {
            // Afficher une boîte de dialogue pour demander l'ID du joueur
            string input = DemanderIDJoueur();

            // Vérifier si l'utilisateur a fourni un ID valide
            if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int joueurID))
            {
                
                var confirmation = MessageBox.Show(
                    $"Le joueur avec l'ID {joueurID} va abandonner. Confirmez-vous ?",
                    "Confirmation Abandon",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmation == DialogResult.Yes)
                {
                    bool fermer = fenetrePrincipale.AbandonnerPartie(joueurID, partieID);
                    if (fermer)
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Abandon annulé.", "Action Annulée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Si l'ID est invalide ou si aucune entrée n'a été fournie
                MessageBox.Show("ID invalide ou abandon annulé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public string DemanderIDJoueur()
        {
            // Créer une fenêtre de dialogue personnalisée
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Abandonner Partie",
                StartPosition = FormStartPosition.CenterScreen
            };

            Label textLabel = new Label()
            {
                Left = 20,
                Top = 20,
                Text = "Entrez l'ID du joueur :",
                AutoSize = true
            };

            TextBox inputBox = new TextBox()
            {
                Left = 20,
                Top = 50,
                Width = 240
            };

            Button confirmButton = new Button()
            {
                Text = "Confirmer",
                Left = 20,
                Width = 100,
                Top = 80,
                DialogResult = DialogResult.OK
            };

            Button cancelButton = new Button()
            {
                Text = "Annuler",
                Left = 140,
                Width = 100,
                Top = 80,
                DialogResult = DialogResult.Cancel
            };

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirmButton);
            prompt.Controls.Add(cancelButton);

            prompt.AcceptButton = confirmButton;
            prompt.CancelButton = cancelButton;

            DialogResult result = prompt.ShowDialog();

            if (result == DialogResult.OK)
            {
                return inputBox.Text; 
            }

            return null; 
        }
    }

}