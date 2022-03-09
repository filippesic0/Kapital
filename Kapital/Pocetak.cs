namespace Kapital
{
	public partial class Pocetak : Form
	{
		Control[] igrac;
		Form1 kapital;

		public Pocetak(Form1 kapital1, Control[] igraci)
		{
			InitializeComponent();
			kapital = kapital1;
			igrac = new TextBox[6];
			for (int i = 0; i < 6; i++)
			{
				string name = "igrac" + (i + 1);
				igrac[i] = this.Controls.Find(name, true)[0];
				igrac[i].Text = igraci[i].Text;
			}
		}

		private void ok_Click(object sender, EventArgs e)
		{
			string[] imena = new string[6];
			for (int i = 0; i < 6; i++)
			{
				imena[i] = igrac[i].Text;
			}
			kapital.Nova_igra(imena);
			kapital.Show();
			this.Close();
		}

		private void cancel_Click(object sender, EventArgs e)
		{
			kapital.Show();
			this.Close();
		}
	}
}
