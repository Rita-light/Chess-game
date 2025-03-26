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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ID = new System.Windows.Forms.ColumnHeader();
            this.Nom = new System.Windows.Forms.ColumnHeader();
            this.lstJoueurs = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.NouveauJoueur = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Fermer = new System.Windows.Forms.Button();
            this.newJoueur = new System.Windows.Forms.TextBox();
            this.btnNouvellePart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ID
            // 
            this.ID.Text = "Joueur ID";
            this.ID.Width = 100;
            // 
            // Nom
            // 
            this.Nom.Text = "Nom";
            this.Nom.Width = 200;
            // 
            // lstJoueurs
            // 
            this.lstJoueurs.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lstJoueurs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ID, this.Nom });
            this.lstJoueurs.HideSelection = false;
            this.lstJoueurs.Location = new System.Drawing.Point(21, 106);
            this.lstJoueurs.Name = "lstJoueurs";
            this.lstJoueurs.Size = new System.Drawing.Size(268, 374);
            this.lstJoueurs.TabIndex = 0;
            this.lstJoueurs.UseCompatibleStateImageBehavior = false;
            this.lstJoueurs.View = System.Windows.Forms.View.Details;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nom Joueur :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // NouveauJoueur
            // 
            this.NouveauJoueur.Location = new System.Drawing.Point(334, 194);
            this.NouveauJoueur.Name = "NouveauJoueur";
            this.NouveauJoueur.Size = new System.Drawing.Size(286, 70);
            this.NouveauJoueur.TabIndex = 6;
            this.NouveauJoueur.Text = "Nouveau Joueur";
            this.NouveauJoueur.UseVisualStyleBackColor = true;
            this.NouveauJoueur.Click += new System.EventHandler(this.NouveauJoueur_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label4.Location = new System.Drawing.Point(21, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 36);
            this.label4.TabIndex = 7;
            this.label4.Text = "Liste de joueurs";
            // 
            // Fermer
            // 
            this.Fermer.Location = new System.Drawing.Point(474, 382);
            this.Fermer.Name = "Fermer";
            this.Fermer.Size = new System.Drawing.Size(146, 70);
            this.Fermer.TabIndex = 8;
            this.Fermer.Text = "Fermer";
            this.Fermer.UseVisualStyleBackColor = true;
            // 
            // newJoueur
            // 
            this.newJoueur.Location = new System.Drawing.Point(437, 137);
            this.newJoueur.Name = "newJoueur";
            this.newJoueur.Size = new System.Drawing.Size(183, 22);
            this.newJoueur.TabIndex = 10;
            // 
            // btnNouvellePart
            // 
            this.btnNouvellePart.Location = new System.Drawing.Point(334, 382);
            this.btnNouvellePart.Name = "btnNouvellePart";
            this.btnNouvellePart.Size = new System.Drawing.Size(123, 70);
            this.btnNouvellePart.TabIndex = 11;
            this.btnNouvellePart.Text = "Nouvelle Partie";
            this.btnNouvellePart.UseVisualStyleBackColor = true;
            this.btnNouvellePart.Click += new System.EventHandler(this.btnNouvellePart_Click);
            // 
            // SelectionnerJoueurGUI
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(653, 515);
            this.Controls.Add(this.btnNouvellePart);
            this.Controls.Add(this.newJoueur);
            this.Controls.Add(this.Fermer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NouveauJoueur);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstJoueurs);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "SelectionnerJoueurGUI";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnNouvellePart;

        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Nom;
        private System.Windows.Forms.ListView lstJoueurs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button NouveauJoueur;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Fermer;
        private System.Windows.Forms.TextBox newJoueur;

        #endregion

        private System.Windows.Forms.ListView listView1;
    }
}

