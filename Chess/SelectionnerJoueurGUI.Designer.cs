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
            this.listViewJoueurs = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ValiderJoeur = new System.Windows.Forms.Button();
            this.NouveauJoueur = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Fermer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJoueurBlanc = new System.Windows.Forms.TextBox();
            this.txtJoueurNoir = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ID
            // 
            this.ID.Text = "Joueur ID";
            // 
            // Nom
            // 
            this.Nom.Text = "Nom";
            this.Nom.Width = 200;
            // 
            // listViewJoueurs
            // 
            this.listViewJoueurs.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listViewJoueurs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.ID, this.Nom });
            this.listViewJoueurs.HideSelection = false;
            this.listViewJoueurs.Location = new System.Drawing.Point(21, 106);
            this.listViewJoueurs.Name = "listViewJoueurs";
            this.listViewJoueurs.Size = new System.Drawing.Size(268, 374);
            this.listViewJoueurs.TabIndex = 0;
            this.listViewJoueurs.UseCompatibleStateImageBehavior = false;
            this.listViewJoueurs.View = System.Windows.Forms.View.Details;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "JoeurBlanc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "JoeurNoir";
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
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label4.Location = new System.Drawing.Point(21, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 36);
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
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(334, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 62);
            this.label1.TabIndex = 9;
            this.label1.Text = "Selectionner Joueur";
            // 
            // txtJoueurBlanc
            // 
            this.txtJoueurBlanc.Location = new System.Drawing.Point(437, 137);
            this.txtJoueurBlanc.Name = "txtJoueurBlanc";
            this.txtJoueurBlanc.Size = new System.Drawing.Size(183, 22);
            this.txtJoueurBlanc.TabIndex = 10;
            // 
            // txtJoueurNoir
            // 
            this.txtJoueurNoir.Location = new System.Drawing.Point(437, 205);
            this.txtJoueurNoir.Name = "txtJoueurNoir";
            this.txtJoueurNoir.Size = new System.Drawing.Size(183, 22);
            this.txtJoueurNoir.TabIndex = 11;
            // 
            // SelectionnerJoueurGUI
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(653, 515);
            this.Controls.Add(this.txtJoueurNoir);
            this.Controls.Add(this.txtJoueurBlanc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Fermer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NouveauJoueur);
            this.Controls.Add(this.ValiderJoeur);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listViewJoueurs);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "SelectionnerJoueurGUI";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtJoueurBlanc;
        private System.Windows.Forms.TextBox txtJoueurNoir;

        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Nom;
        private System.Windows.Forms.ListView listViewJoueurs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ValiderJoeur;
        private System.Windows.Forms.Button NouveauJoueur;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Fermer;

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
    }
}

