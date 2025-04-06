using System.Windows.Forms;

namespace Chess
{
    public class PromotionForm : Form
    {
        public char Choix { get; private set; }

        public PromotionForm()
        {
            Text = "Choix de promotion";
            Width = 300;
            Height = 100;
            StartPosition = FormStartPosition.CenterParent;

            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Dock = DockStyle.Fill;
            Controls.Add(panel);

            Button dame = new Button { Text = "Dame (D)" };
            dame.Click += (s, e) => { Choix = 'D'; DialogResult = DialogResult.OK; Close(); };

            Button tour = new Button { Text = "Tour (T)" };
            tour.Click += (s, e) => { Choix = 'T'; DialogResult = DialogResult.OK; Close(); };

            Button fou = new Button { Text = "Fou (F)" };
            fou.Click += (s, e) => { Choix = 'F'; DialogResult = DialogResult.OK; Close(); };

            Button cavalier = new Button { Text = "Cavalier (C)" };
            cavalier.Click += (s, e) => { Choix = 'C'; DialogResult = DialogResult.OK; Close(); };

            panel.Controls.AddRange(new Control[] { dame, tour, fou, cavalier });
        }
    }

}