namespace Chess
{
    partial class PlateauGUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.pnlEchequier = new System.Windows.Forms.Panel();
            this.btnDemarrerPartie = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPointBlanc = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNomBlanc = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblPointNoir = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblJoueurNoir = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Message aux joueurs";
            // 
            // pnlEchequier
            // 
            this.pnlEchequier.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlEchequier.Location = new System.Drawing.Point(30, 66);
            this.pnlEchequier.Name = "pnlEchequier";
            this.pnlEchequier.Size = new System.Drawing.Size(400, 400);
            this.pnlEchequier.TabIndex = 1;
            this.pnlEchequier.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlEchequier_Paint);
            // 
            // btnDemarrerPartie
            // 
            this.btnDemarrerPartie.Location = new System.Drawing.Point(30, 488);
            this.btnDemarrerPartie.Name = "btnDemarrerPartie";
            this.btnDemarrerPartie.Size = new System.Drawing.Size(400, 33);
            this.btnDemarrerPartie.TabIndex = 2;
            this.btnDemarrerPartie.Text = "Jouer";
            this.btnDemarrerPartie.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPointBlanc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblNomBlanc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(30, 547);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 114);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Joueur Blanc";
            // 
            // lblPointBlanc
            // 
            this.lblPointBlanc.AutoSize = true;
            this.lblPointBlanc.Location = new System.Drawing.Point(86, 77);
            this.lblPointBlanc.Name = "lblPointBlanc";
            this.lblPointBlanc.Size = new System.Drawing.Size(18, 20);
            this.lblPointBlanc.TabIndex = 3;
            this.lblPointBlanc.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Point :";
            // 
            // lblNomBlanc
            // 
            this.lblNomBlanc.AutoSize = true;
            this.lblNomBlanc.Location = new System.Drawing.Point(86, 40);
            this.lblNomBlanc.Name = "lblNomBlanc";
            this.lblNomBlanc.Size = new System.Drawing.Size(0, 20);
            this.lblNomBlanc.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nom : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblPointNoir);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblJoueurNoir);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(240, 547);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(190, 114);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Joueur Noir";
            // 
            // lblPointNoir
            // 
            this.lblPointNoir.AutoSize = true;
            this.lblPointNoir.Location = new System.Drawing.Point(94, 77);
            this.lblPointNoir.Name = "lblPointNoir";
            this.lblPointNoir.Size = new System.Drawing.Size(18, 20);
            this.lblPointNoir.TabIndex = 3;
            this.lblPointNoir.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Point : ";
            // 
            // lblJoueurNoir
            // 
            this.lblJoueurNoir.AutoSize = true;
            this.lblJoueurNoir.Location = new System.Drawing.Point(94, 40);
            this.lblJoueurNoir.Name = "lblJoueurNoir";
            this.lblJoueurNoir.Size = new System.Drawing.Size(0, 20);
            this.lblJoueurNoir.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Nom :";
            // 
            // PlateauGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 675);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDemarrerPartie);
            this.Controls.Add(this.pnlEchequier);
            this.Controls.Add(this.label1);
            this.Name = "PlateauGUI";
            this.Text = "PlateauGUI";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlEchequier;
        private System.Windows.Forms.Button btnDemarrerPartie;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPointBlanc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNomBlanc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblPointNoir;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblJoueurNoir;
        private System.Windows.Forms.Label label6;
    }
}