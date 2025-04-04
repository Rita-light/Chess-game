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
            this.lblTxt = new System.Windows.Forms.Label();
            this.pnlEchiquier = new System.Windows.Forms.Panel();
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
            // lblTxt
            // 
            this.lblTxt.AutoSize = true;
            this.lblTxt.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxt.Location = new System.Drawing.Point(21, 10);
            this.lblTxt.Name = "lblTxt";
            this.lblTxt.Size = new System.Drawing.Size(210, 26);
            this.lblTxt.TabIndex = 0;
            this.lblTxt.Text = "Message aux joueurs";
            // 
            // pnlEchiquier
            // 
            this.pnlEchiquier.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlEchiquier.Location = new System.Drawing.Point(27, 53);
            this.pnlEchiquier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlEchiquier.Name = "pnlEchiquier";
            this.pnlEchiquier.Size = new System.Drawing.Size(400, 400);
            this.pnlEchiquier.TabIndex = 1;
            this.pnlEchiquier.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlEchequier_Paint);
            this.pnlEchiquier.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlEchiquier_MouseClick);
            // 
            // btnDemarrerPartie
            // 
            this.btnDemarrerPartie.Location = new System.Drawing.Point(27, 466);
            this.btnDemarrerPartie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDemarrerPartie.Name = "btnDemarrerPartie";
            this.btnDemarrerPartie.Size = new System.Drawing.Size(400, 26);
            this.btnDemarrerPartie.TabIndex = 2;
            this.btnDemarrerPartie.Text = "Jouer";
            this.btnDemarrerPartie.UseVisualStyleBackColor = true;
            this.btnDemarrerPartie.Click += new System.EventHandler(this.btnDemarrerPartie_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPointBlanc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblNomBlanc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(27, 505);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(169, 91);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Joueur Blanc";
            // 
            // lblPointBlanc
            // 
            this.lblPointBlanc.AutoSize = true;
            this.lblPointBlanc.Location = new System.Drawing.Point(76, 62);
            this.lblPointBlanc.Name = "lblPointBlanc";
            this.lblPointBlanc.Size = new System.Drawing.Size(16, 17);
            this.lblPointBlanc.TabIndex = 3;
            this.lblPointBlanc.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Point :";
            // 
            // lblNomBlanc
            // 
            this.lblNomBlanc.AutoSize = true;
            this.lblNomBlanc.Location = new System.Drawing.Point(76, 32);
            this.lblNomBlanc.Name = "lblNomBlanc";
            this.lblNomBlanc.Size = new System.Drawing.Size(0, 17);
            this.lblNomBlanc.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nom : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblPointNoir);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblJoueurNoir);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(258, 505);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(169, 91);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Joueur Noir";
            // 
            // lblPointNoir
            // 
            this.lblPointNoir.AutoSize = true;
            this.lblPointNoir.Location = new System.Drawing.Point(84, 62);
            this.lblPointNoir.Name = "lblPointNoir";
            this.lblPointNoir.Size = new System.Drawing.Size(16, 17);
            this.lblPointNoir.TabIndex = 3;
            this.lblPointNoir.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "Point : ";
            // 
            // lblJoueurNoir
            // 
            this.lblJoueurNoir.AutoSize = true;
            this.lblJoueurNoir.Location = new System.Drawing.Point(84, 32);
            this.lblJoueurNoir.Name = "lblJoueurNoir";
            this.lblJoueurNoir.Size = new System.Drawing.Size(0, 17);
            this.lblJoueurNoir.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Nom :";
            // 
            // PlateauGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 607);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDemarrerPartie);
            this.Controls.Add(this.pnlEchiquier);
            this.Controls.Add(this.lblTxt);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PlateauGUI";
            this.Text = "PlateauGUI";
            this.Load += new System.EventHandler(this.PlateauGUI_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTxt;
        private System.Windows.Forms.Panel pnlEchiquier;
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