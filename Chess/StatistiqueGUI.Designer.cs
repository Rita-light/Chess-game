using System.ComponentModel;

namespace Chess
{
    partial class StatistiqueGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataScores = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblClassement = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNull = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDefaite = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblVictoire = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.JoueurID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJoueurNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Classement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataScores)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataScores
            // 
            this.dataScores.AllowUserToOrderColumns = true;
            this.dataScores.AllowUserToResizeColumns = false;
            this.dataScores.AllowUserToResizeRows = false;
            this.dataScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataScores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.JoueurID, this.colJoueurNom, this.colScore, this.Classement });
            this.dataScores.Location = new System.Drawing.Point(22, 133);
            this.dataScores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataScores.Name = "dataScores";
            this.dataScores.RowHeadersWidth = 62;
            this.dataScores.RowTemplate.Height = 28;
            this.dataScores.Size = new System.Drawing.Size(371, 390);
            this.dataScores.TabIndex = 0;
            this.dataScores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataScores_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 20F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(204, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Statistiques";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblClassement);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblNull);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblDefaite);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblVictoire);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblNom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(410, 296);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(217, 227);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Détail Joueur";
            // 
            // lblClassement
            // 
            this.lblClassement.Location = new System.Drawing.Point(111, 189);
            this.lblClassement.Name = "lblClassement";
            this.lblClassement.Size = new System.Drawing.Size(84, 23);
            this.lblClassement.TabIndex = 9;
            this.lblClassement.Text = "0";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(15, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Classement : ";
            // 
            // lblNull
            // 
            this.lblNull.AutoSize = true;
            this.lblNull.Location = new System.Drawing.Point(92, 161);
            this.lblNull.Name = "lblNull";
            this.lblNull.Size = new System.Drawing.Size(16, 17);
            this.lblNull.TabIndex = 7;
            this.lblNull.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "Null : ";
            // 
            // lblDefaite
            // 
            this.lblDefaite.AutoSize = true;
            this.lblDefaite.Location = new System.Drawing.Point(92, 117);
            this.lblDefaite.Name = "lblDefaite";
            this.lblDefaite.Size = new System.Drawing.Size(16, 17);
            this.lblDefaite.TabIndex = 5;
            this.lblDefaite.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Défaites : ";
            // 
            // lblVictoire
            // 
            this.lblVictoire.AutoSize = true;
            this.lblVictoire.Location = new System.Drawing.Point(92, 77);
            this.lblVictoire.Name = "lblVictoire";
            this.lblVictoire.Size = new System.Drawing.Size(16, 17);
            this.lblVictoire.TabIndex = 3;
            this.lblVictoire.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Victoire :";
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(92, 38);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(35, 17);
            this.lblNom.TabIndex = 1;
            this.lblNom.Text = "nom";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Joueur :";
            // 
            // JoueurID
            // 
            this.JoueurID.HeaderText = "ID Joueur";
            this.JoueurID.Name = "JoueurID";
            this.JoueurID.Width = 50;
            // 
            // colJoueurNom
            // 
            this.colJoueurNom.HeaderText = "Joueur";
            this.colJoueurNom.MinimumWidth = 8;
            this.colJoueurNom.Name = "colJoueurNom";
            this.colJoueurNom.Width = 110;
            // 
            // colScore
            // 
            this.colScore.HeaderText = "Score Total";
            this.colScore.MinimumWidth = 8;
            this.colScore.Name = "colScore";
            // 
            // Classement
            // 
            this.Classement.HeaderText = "Classement";
            this.Classement.Name = "Classement";
            // 
            // StatistiqueGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 549);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataScores);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "StatistiqueGUI";
            this.Text = "StatistiqueGUI";
            ((System.ComponentModel.ISupportInitialize)(this.dataScores)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridViewTextBoxColumn Classement;

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblClassement;

        private System.Windows.Forms.DataGridViewTextBoxColumn JoueurID;

        #endregion

        private System.Windows.Forms.DataGridView dataScores;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJoueurNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNull;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDefaite;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblVictoire;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label label2;
    }
}