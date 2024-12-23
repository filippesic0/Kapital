//using FormSerialisation;

namespace Kapital
{
	public partial class Pocetak : Form
	{
		Control[] igrac;
		Form1 kapital;
		Kontroler kontroler;

		public Pocetak(Form1 kapital1, Kontroler kontroler1, Control[] igraci)
		{
			InitializeComponent();
			kapital = kapital1;
			kontroler = kontroler1;
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
				imena[i] = igrac[i].Text;
			//	FormSerialisor.Deserialise(kapital, Application.StartupPath + @"\Nova_igra.xml");
			kapital.Nova_igra(imena);
			int broj_igraca = 6;
			for (int igrac = 0; igrac < broj_igraca; igrac++)
				if (imena[igrac].Equals(""))
				{
					broj_igraca--;
					igrac--;
				}
			kontroler.Nova_igra(kapital, broj_igraca);
			kapital.Show();
			kontroler.Show();
			Close();
		}

		private void cancel_Click(object sender, EventArgs e)
		{
			kapital.Show();
			kontroler.Show();
			Hide();
		}
	}
}
