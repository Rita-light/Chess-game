using System;
using System.Drawing;
using System.Windows.Forms;


namespace Chess
{
    public partial class PlateauGUI : Form
    {
        private FenetrePrincipale fenetrePrincipale;
        private int partieID;
        Graphics myGraph;
        int CaseSourceX = -1;
        int CaseSourceY = -1;
        private bool interactionsPermises = true;
        bool peutFermer = false;
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
                    myGraph.FillRectangle(myBrush, r * sizeW / 8, c * sizeH / 8, sizeW / 8, sizeH / 8);

        }

        private void PlateauGUI_Load(object sender, EventArgs e)
        {
            var (nomBlanc, nomNoir) = fenetrePrincipale.ObtenirNomJoueur();

            lblNomBlanc.Text = $@"{nomBlanc}";
            lblJoueurNoir.Text = $@"{nomNoir}";
        }

        /// <summary>
        /// Permet d'afficher les pièces sur le plateau
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="plateauString"></param>
        /// <param name="tailleX"></param>
        /// <param name="tailleY"></param>
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
                    return new Bitmap("pionn.bmp");

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
            AfficherPieces(myGraph, fenetrePrincipale.ObtenirPlateauActuel(partieID), pnlEchiquier.Width / 8, pnlEchiquier.Height / 8);
            btnDemarrerPartie.Enabled = false;
            AfficherMessage("Tour du joueur Blanc");
        }

        /// <summary>
        /// S'exécute losqu'on clique une case du plateau
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlEchiquier_MouseClick(object sender, MouseEventArgs e)
        {
            // Calculer la taille d'une case en fonction de la taille du plateau
            int tailleX = pnlEchiquier.Width / 8;
            int tailleY = pnlEchiquier.Height / 8;

            // Calculer les coordonnées de la case cliquée
            int caseX = e.X / tailleX;
            int caseY = e.Y / tailleY;

            if (btnDemarrerPartie.Enabled == false && interactionsPermises)
            {
                // S'il s'agit de la même case de départ...
                if ((CaseSourceX == caseX) && (CaseSourceY == caseY))
                {
                    myGraph.DrawRectangle(new Pen(Color.Chocolate, 2), CaseSourceX * tailleX, CaseSourceY * tailleY, tailleX, tailleY);
                    AfficherMessageErreur("vous avez cliquer la même case");
                    CaseSourceX = CaseSourceY = -1;
                }
                // S'il n'y a pas de case départ sélectionnée...
                else if ((CaseSourceX == -1) && (CaseSourceY == -1))
                {
                    CaseSourceX = caseX;
                    CaseSourceY = caseY;
                    myGraph.DrawRectangle(new Pen(Color.DarkGreen, 2), CaseSourceX * tailleX, CaseSourceY * tailleY, tailleX, tailleY);
                }
                // S'il s'agit de la case destination...
                else
                {
                    myGraph.DrawRectangle(new Pen(Color.Chocolate, 2), CaseSourceX * tailleX, CaseSourceY * tailleY, tailleX, tailleY);

                    //Code pour jouer coup......

                    Boolean coupAppliquer = fenetrePrincipale.jouerCoup(CaseSourceX, CaseSourceY, caseX, caseY, partieID);
                    Console.WriteLine($@"Coup appliqué : {coupAppliquer}");

                    if (coupAppliquer)
                    {
                        MettreAJourPlateau();
                    } 
                    
                    CaseSourceX = CaseSourceY = -1;
                }
            }

        }

        /// <summary>
        /// Met le plateau à jour
        /// </summary>
        public void MettreAJourPlateau()
        {
            pnlEchiquier.Refresh();

            AfficherPieces(myGraph, fenetrePrincipale.ObtenirPlateauActuel(partieID), pnlEchiquier.Width / 8, pnlEchiquier.Height / 8);
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

        /// <summary>
        /// S'excécute quand on demande l'abandon du jeu
        /// Demande l'ID du joeur qui anandonne et exécute l'abando de la partie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="a"></param>
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
                     fenetrePrincipale.AbandonnerPartie(joueurID, partieID);
                } 
                else
                {
                    MessageBox.Show("Abandon annulé.", "Action Annulée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } else
            {
                // Si l'ID est invalide ou si aucune entrée n'a été fournie
                MessageBox.Show("ID invalide ou abandon annulé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Crée une fenêre interactive pour demande l'ID du joueur voulant abandoner la partie
        /// </summary>
        /// <returns></returns>
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

        private void btnNulle_Click(object sender, EventArgs e)
        {
            // Afficher une fenêtre de confirmation
            var confirmation = MessageBox.Show(
                "Êtes-vous sûr de vouloir annuler la partie et la déclarer nulle ?",
                "Demande de Nulle",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmation == DialogResult.Yes)
            {
                // Transmettre la demande à FenetrePrincipale
                fenetrePrincipale.DemanderNulle(partieID);
            } else
            {
                MessageBox.Show(
                    "Demande de nulle annulée.",
                    "Action Annulée",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        /// <summary>
        /// Gère la fin d'une partie en demandant si les joueurs veulent fermer le plateau ou le laisser ouvert
        /// rend le plateau non cliquable
        /// </summary>
        public void GererFinPartie()
        {
            // Désactiver la capacité à cliquer sur le plateau
            interactionsPermises = false;
            peutFermer = true;
            MettreAJourPlateau();

            // Demander à l'utilisateur ce qu'il souhaite faire
            DialogResult result = MessageBox.Show(
                "La partie est terminée. Voulez-vous fermer le plateau ?",
                "Fin de Partie",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Fermer le plateau
                Close();
            }

        }
        private void PlateauGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!peutFermer)
            {
                MessageBox.Show("Vous ne pouvez pas fermer la fenêtre tant que la partie n'est pas terminée.",
                    "Fermeture interdite", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true; // Empêche la fermeture
            }
        }

    }

}