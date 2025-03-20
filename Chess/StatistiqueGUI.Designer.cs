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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colJoueurNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblVictoire = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDefaite = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblNull = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colJoueurNom,
            this.colScore});
            this.dataGridView1.Location = new System.Drawing.Point(12, 167);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(364, 487);
            this.dataGridView1.TabIndex = 0;
            // 
            // colJoueurNom
            // 
            this.colJoueurNom.HeaderText = "Joueur";
            this.colJoueurNom.MinimumWidth = 8;
            this.colJoueurNom.Name = "colJoueurNom";
            this.colJoueurNom.Width = 150;
            // 
            // colScore
            // 
            this.colScore.HeaderText = "Score Total";
            this.colScore.MinimumWidth = 8;
            this.colScore.Name = "colScore";
            this.colScore.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 20F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(230, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Statistiques";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNull);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblDefaite);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblVictoire);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblNom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(431, 370);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 284);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Détail Joueur";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Joueur :";
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(104, 47);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(40, 20);
            this.lblNom.TabIndex = 1;
            this.lblNom.Text = "nom";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Victoire :";
            // 
            // lblVictoire
            // 
            this.lblVictoire.AutoSize = true;
            this.lblVictoire.Location = new System.Drawing.Point(104, 96);
            this.lblVictoire.Name = "lblVictoire";
            this.lblVictoire.Size = new System.Drawing.Size(18, 20);
            this.lblVictoire.TabIndex = 3;
            this.lblVictoire.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Défaites : ";
            // 
            // lblDefaite
            // 
            this.lblDefaite.AutoSize = true;
            this.lblDefaite.Location = new System.Drawing.Point(104, 146);
            this.lblDefaite.Name = "lblDefaite";
            this.lblDefaite.Size = new System.Drawing.Size(18, 20);
            this.lblDefaite.TabIndex = 5;
            this.lblDefaite.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "Null : ";
            // 
            // lblNull
            // 
            this.lblNull.AutoSize = true;
            this.lblNull.Location = new System.Drawing.Point(104, 201);
            this.lblNull.Name = "lblNull";
            this.lblNull.Size = new System.Drawing.Size(18, 20);
            this.lblNull.TabIndex = 7;
            this.lblNull.Text = "0";
            // 
            // StatistiqueGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 686);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "StatistiqueGUI";
            this.Text = "StatistiqueGUI";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
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