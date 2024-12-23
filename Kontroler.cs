namespace Kapital
{
	public partial class Kontroler : Form
	{
		Form1 kapital;
		int[] pozicija;
		int na_potezu = 0;
		Random rng = new Random();

		public Kontroler()
		{
			InitializeComponent();
		}

		public void Nova_igra(Form1 kapital1, int broj_igraca)
		{
			kapital = kapital1;
			pozicija = new int[broj_igraca];
			na_potezu = rng.Next(broj_igraca);
			na_potezu_box.Text = kapital.ime[na_potezu].Text;
			na_potezu--;
		}

		private void sledeci_Click(object sender, EventArgs e)
		{
			polje.Text = "";
			polje.BackColor = Color.White;
			polje.ForeColor = Color.Black;
			kupi_deonicu.Visible = false;

			na_potezu++;
			if (na_potezu >= pozicija.Length)
				na_potezu -= pozicija.Length;
			na_potezu_box.Text = kapital.ime[na_potezu].Text;
			kapital.igrac_na_potezu = na_potezu;

			pozicija[na_potezu] += rng.Next(6) + rng.Next(6);
			if (pozicija[na_potezu] >= 40)
			{
				pozicija[na_potezu] -= 40;
				kapital.Dividenda(na_potezu + 1);
			}
			if (pozicija[na_potezu] < 0)
				;

			if (pozicija[na_potezu] % 10 == 3 || pozicija[na_potezu] % 10 == 7)
				polje.Text = "berza " + (pozicija[na_potezu] / 5 + 1);
			else if (pozicija[na_potezu] % 10 == 5)
			{
				polje.Text = "iznenađenje " + (pozicija[na_potezu] / 10 + 1);
				polje.BackColor = Color.Black;
				polje.ForeColor = Color.White;
			}
			else if (pozicija[na_potezu] == 0)
				polje.Text = "dividenda";
			else if (pozicija[na_potezu] % 10 == 0)
				polje.Text = pozicija[na_potezu] / 10 + ". ugao";
			else if (pozicija[na_potezu] % 5 != 0)
			{
				polje.BackColor = kapital.deonice[na_potezu, pozicija[na_potezu] / 5].BackColor;
				polje.ForeColor = kapital.deonice[na_potezu, pozicija[na_potezu] / 5].ForeColor;
				if (kapital.novac[na_potezu].compare(kapital.cena_deonice(pozicija[na_potezu] / 5)) >= 0
					&& kapital.deonice[na_potezu, pozicija[na_potezu] / 5].compare(16) < 0)
					kupi_deonicu.Visible = true;
				switch (pozicija[na_potezu] / 5)
				{
					case 0:
						polje.Text = "prehrambena";
						break;
					case 1:
						polje.Text = "igračaka";
						break;
					case 2:
						polje.Text = "odeće";
						break;
					case 3:
						polje.Text = "obuće";
						break;
					case 4:
						polje.Text = "nameštaja";
						break;
					case 5:
						polje.Text = "elektrike";
						break;
					case 6:
						polje.Text = "auto";
						break;
					case 7:
						polje.Text = "nafte";
						break;

				}
			}
		}

		private void na_tabli_Click(object sender, EventArgs e)
		{
			Hide();
		}

		private void kupi_deonicu_Click(object sender, EventArgs e)
		{
			kapital.Kupi_deonicu(pozicija[na_potezu] / 5 + 1);
			kupi_deonicu.Visible = false;
			sledeci.PerformClick();
		}
	}
}
