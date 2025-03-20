using System.ComponentModel;

namespace Chess
{
    partial class SelectionnerJoueurGUI
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView2 = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.JoeurBlanc = new System.Windows.Forms.TextBox();
            this.JoueurNoir = new System.Windows.Forms.TextBox();
            this.ValiderJoeur = new System.Windows.Forms.Button();
            this.NouveauJoueur = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Fermer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView2
            // 
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(21, 106);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(268, 374);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "JoeurBlanc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "JoeurNoir";
            // 
            // JoeurBlanc
            // 
            this.JoeurBlanc.Location = new System.Drawing.Point(443, 142);
            this.JoeurBlanc.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.JoeurBlanc.Name = "JoeurBlanc";
            this.JoeurBlanc.Size = new System.Drawing.Size(177, 26);
            this.JoeurBlanc.TabIndex = 3;
            // 
            // JoueurNoir
            // 
            this.JoueurNoir.Location = new System.Drawing.Point(443, 207);
            this.JoueurNoir.Name = "JoueurNoir";
            this.JoueurNoir.Size = new System.Drawing.Size(177, 26);
            this.JoueurNoir.TabIndex = 4;
            // 
            // ValiderJoeur
            // 
            this.ValiderJoeur.Location = new System.Drawing.Point(335, 271);
            this.ValiderJoeur.Name = "ValiderJoeur";
            this.ValiderJoeur.Size = new System.Drawing.Size(285, 54);
            this.ValiderJoeur.TabIndex = 5;
            this.ValiderJoeur.Text = "Valider";
            this.ValiderJoeur.UseVisualStyleBackColor = true;
            // 
            // NouveauJoueur
            // 
            this.NouveauJoueur.Location = new System.Drawing.Point(335, 377);
            this.NouveauJoueur.Name = "NouveauJoueur";
            this.NouveauJoueur.Size = new System.Drawing.Size(133, 70);
            this.NouveauJoueur.TabIndex = 6;
            this.NouveauJoueur.Text = "Nouveau Joueur";
            this.NouveauJoueur.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label4.Location = new System.Drawing.Point(211, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(287, 40);
            this.label4.TabIndex = 7;
            this.label4.Text = "Liste de joueurs";
            // 
            // Fermer
            // 
            this.Fermer.Location = new System.Drawing.Point(474, 377);
            this.Fermer.Name = "Fermer";
            this.Fermer.Size = new System.Drawing.Size(146, 70);
            this.Fermer.TabIndex = 8;
            this.Fermer.Text = "Fermer";
            this.Fermer.UseVisualStyleBackColor = true;
            // 
            // SelectionnerJoueurGUI
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(653, 515);
            this.Controls.Add(this.Fermer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NouveauJoueur);
            this.Controls.Add(this.ValiderJoeur);
            this.Controls.Add(this.JoueurNoir);
            this.Controls.Add(this.JoeurBlanc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView2);
            this.Name = "SelectionnerJoueurGUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox JoeurBlanc;
        private System.Windows.Forms.TextBox JoueurNoir;
        private System.Windows.Forms.Button ValiderJoeur;
        private System.Windows.Forms.Button NouveauJoueur;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Fermer;
    }
}

