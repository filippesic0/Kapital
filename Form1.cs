//using FormSerialisation;

namespace Kapital
{
	public partial class Form1 : Form
	{
		Kontroler kontroler;
		public Control[] ime;
		public Control[] novac;
		Control[] dodaj_novac;
		Control[] trenutna_dividenda;
		public Control[,] deonice;
		Control[,,] kompanija;//0 proizvodnja, 1 veleprodaja, 2 maloprodaja
		Control[,] korporacija;
		Control[,] kontinent;
		public Control[] Bdeonice;//b znaci dugme, za razliku od textbox-ova iznad.
		Control[,] Bkompanija;
		Control[] Bkorporacija;
		Control[] Bkontinent;
		Control[] kupi;
		Control[] prodaj;
		Control[] uzmi;
		Control[] izgubi;
		public Control[] dividenda;
		public int igrac_na_potezu;
		int napadnut_igrac;
		int pritisnuto_dugme;//0 kupi, 1 prodaj, 2 uzmi, 3 izgubi, 4 dividenda
		bool[] kradja_kompanije;
		bool[] kradja_korporacije;
		int broj_igraca = 6;
		int pritisunti_kontinent = -1;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			ime = new GroupBox[6];
			novac = new TextBox[6];
			dodaj_novac = new TextBox[6];
			trenutna_dividenda = new TextBox[6];
			deonice = new TextBox[6, 8];
			kompanija = new TextBox[6, 8, 3];
			korporacija = new TextBox[6, 8];
			kontinent = new TextBox[6, 6];
			Bdeonice = new Button[8];
			Bkompanija = new Button[8, 3];
			Bkorporacija = new Button[8];
			Bkontinent = new Button[8];
			kupi = new Button[6];
			prodaj = new Button[6];
			uzmi = new Button[6];
			izgubi = new Button[6];
			dividenda = new Button[6];
			kradja_kompanije = new bool[8];
			kradja_korporacije = new bool[8];

			string name;
			for (int igrac = 0; igrac < 6; igrac++)
			{
				for (int industrija = 0; industrija < 8; industrija++)
				{
					name = "deonice" + (igrac + 1) + (industrija + 1);
					deonice[igrac, industrija] = this.Controls.Find(name, true)[0];
					name = "proizvodnja" + (igrac + 1) + (industrija + 1);
					kompanija[igrac, industrija, 0] = this.Controls.Find(name, true)[0];
					name = "veleprodaja" + (igrac + 1) + (industrija + 1);
					kompanija[igrac, industrija, 1] = this.Controls.Find(name, true)[0];
					name = "maloprodaja" + (igrac + 1) + (industrija + 1);
					kompanija[igrac, industrija, 2] = this.Controls.Find(name, true)[0];
					name = "korporacija" + (igrac + 1) + (industrija + 1);
					korporacija[igrac, industrija] = this.Controls.Find(name, true)[0];
				}
				for (int kont = 0; kont < 6; kont++)
				{
					name = "kontinent" + (igrac + 1) + (kont + 1);
					kontinent[igrac, kont] = this.Controls.Find(name, true)[0];
				}
				name = "igrac" + (igrac + 1);
				ime[igrac] = this.Controls.Find(name, true)[0];
				name = "novac" + (igrac + 1);
				novac[igrac] = this.Controls.Find(name, true)[0];
				name = "trenutna_dividenda" + (igrac + 1);
				trenutna_dividenda[igrac] = this.Controls.Find(name, true)[0];
				name = "kupi" + (igrac + 1);
				kupi[igrac] = this.Controls.Find(name, true)[0];
				name = "prodaj" + (igrac + 1);
				prodaj[igrac] = this.Controls.Find(name, true)[0];
				name = "uzmi" + (igrac + 1);
				uzmi[igrac] = this.Controls.Find(name, true)[0];
				name = "izgubi" + (igrac + 1);
				izgubi[igrac] = this.Controls.Find(name, true)[0];
				name = "dividenda" + (igrac + 1);
				dividenda[igrac] = this.Controls.Find(name, true)[0];
				name = "dodaj_novac" + (igrac + 1);
				dodaj_novac[igrac] = this.Controls.Find(name, true)[0];
			}
			for (int industrija = 0; industrija < 8; industrija++)
			{
				name = "deonice" + (industrija + 1);
				Bdeonice[industrija] = this.Controls.Find(name, true)[0];
				name = "proizvodnja" + (industrija + 1);
				Bkompanija[industrija, 0] = this.Controls.Find(name, true)[0];
				name = "veleprodaja" + (industrija + 1);
				Bkompanija[industrija, 1] = this.Controls.Find(name, true)[0];
				name = "maloprodaja" + (industrija + 1);
				Bkompanija[industrija, 2] = this.Controls.Find(name, true)[0];
				name = "korporacija" + (industrija + 1);
				Bkorporacija[industrija] = this.Controls.Find(name, true)[0];
				kradja_kompanije[industrija] = false;
				kradja_korporacije[industrija] = false;
			}
			for (int kont = 0; kont < 6; kont++)
			{
				name = "kontinent" + (kont + 1);
				Bkontinent[kont] = this.Controls.Find(name, true)[0];
			}
			//	FormSerialisor.Serialise(this, Application.StartupPath + @"\Nova_igra.xml");
			//	FormSerialisor.Deserialise(this, Application.StartupPath + @"\Trenutno_stanje.xml");
			set_width();

			otvori_kontroler.PerformClick();
		}

		private void Cancel()
		{
			for (int industrija = 0; industrija < 8; industrija++)
			{
				Bdeonice[industrija].Enabled = false;
				Bdeonice[industrija].Visible = true;
				for (int igrac = 0; igrac < 6; igrac++)
				{
					Bkorporacija[industrija].Visible = false;
					break;
				}
				if (Bkorporacija[industrija].Visible)
				{
					Bkorporacija[industrija].Enabled = false;
					for (int komp = 0; komp < 3; komp++)
						Bkompanija[industrija, komp].Visible = false;
					continue;
				}

				for (int komp = 0; komp < 3; komp++)
				{
					for (int igrac = 0; igrac < 6; igrac++)
						if (kompanija[igrac, industrija, komp].Visible)
						{
							Bkompanija[industrija, komp].Visible = false;
							break;
						}
					if (Bkompanija[industrija, komp].Visible)
						Bkompanija[industrija, komp].Enabled = false;
				}
				kradja_kompanije[industrija] = false;
				kradja_korporacije[industrija] = false;
			}
			for (int kont = 0; kont < 6; kont++)
			{
				Bkontinent[kont].Visible = false;
			}
			for (int igrac = 0; igrac < 6; igrac++)
			{
				kupi[igrac].Visible = true;
				prodaj[igrac].Visible = true;
				uzmi[igrac].Visible = true;
				izgubi[igrac].Visible = true;
				dividenda[igrac].Visible = true;
			}
			cancel.Visible = false;
			brani.Visible = false;
			nebrani.Visible = false;
			dodajnovac.Visible = true;
			oduzminovac.Visible = true;
			skok_proizvodnje.Visible = true;
			lose_poslovanje.Visible = true;
			pritisnuto_dugme = 0;
			pritisunti_kontinent = -1;

			//	FormSerialisor.Serialise(this, Application.StartupPath + @"\Trenutno_stanje.xml");
		}

		private void Kupi(int igrac)
		{
			if (!uzmi[0].Visible && !uzmi[1].Visible)//kupovina deonica od igraca po izboru
			{
				igrac--;
				for (int industrija = 0; industrija < 8; industrija++)
				{
					int sum = 0;
					for (int igrac1 = 0; igrac1 < 6; igrac1++)
						sum += int.Parse(deonice[igrac1, industrija].Text);
					if (sum > 16)
					{
						deonice[igrac, industrija].minus(1);
						novac[igrac].plus(cena_deonice(industrija));
						break;
					}
				}
				pritisnuto_dugme = 0;
				Cancel();
				return;
			}

			igrac--;
			igrac_na_potezu = igrac;

			if (pritisnuto_dugme >= 10)//Igrac bira od koga ce da kupi deonicu; prva cifra broja je 1.
			{
				pritisnuto_dugme -= 10;//Druga cifra broja je industrija.
				deonice[igrac_na_potezu, pritisnuto_dugme].minus(1);
				novac[igrac_na_potezu].plus(cena_deonice(pritisnuto_dugme));
				Cancel();
				return;
			}

			pritisnuto_dugme = 0;
			for (int industrija = 0; industrija < 8; industrija++)//kupovina deonica
			{
				if (novac[igrac_na_potezu].compare(cena_deonice(industrija)) >= 0)
					Bdeonice[industrija].Enabled = true;
				for (int komp = 0; komp < 3; komp++)
					if (kompanija[igrac_na_potezu, industrija, komp].Visible && kompanija[igrac_na_potezu, industrija, komp].Text.Equals(""))
					{
						Bkompanija[industrija, komp].Visible = true;
						Bkompanija[industrija, komp].Enabled = true;
					}
			}

			for (int kont = 0; kont < 6; kont++)//kupovina kontinenata
			{
				int broj_korporacija = 0;
				for (int industrija = 0; industrija < 8; industrija++)
					if (korporacija[igrac, industrija].Visible)
						broj_korporacija++;
				if (kontinent[igrac, kont].Text.Length / 2 < broj_korporacija)
					if (novac[igrac].compare(cena_kontinenta(kont)) >= 0)
						Bkontinent[kont].Visible = true;
			}

			for (igrac = 0; igrac < 6; igrac++)
			{
				kupi[igrac].Visible = false;
				prodaj[igrac].Visible = false;
				uzmi[igrac].Visible = false;
				izgubi[igrac].Visible = false;
				dividenda[igrac].Visible = false;
			}
			cancel.Visible = true;
			dodajnovac.Visible = false;
			oduzminovac.Visible = false;
			skok_proizvodnje.Visible = false;
			lose_poslovanje.Visible = false;
		}

		private void Uzmi(int igrac)
		{
			igrac--;
			igrac_na_potezu = igrac;
			pritisnuto_dugme = 1;

			//preuzimanje korporacije
			for (int industrija = 0; industrija < 8; industrija++)
			{
				int objekti = 0;
				for (int komp = 0; komp < 3; komp++)
					if (kompanija[igrac, industrija, komp].Visible)
						if (kompanija[igrac, industrija, komp].Text.Equals("OB"))
							objekti++;
				if (deonice[igrac, industrija].compare(5) >= 0 && objekti == 3)
				{
					Bkorporacija[industrija].Visible = true;
					Bkorporacija[industrija].Enabled = true;
				}
			}

			//kradja korporacije
			for (napadnut_igrac = 0; napadnut_igrac < 6; napadnut_igrac++)
			{
				if (napadnut_igrac == igrac)
					continue;
				for (int industrija = 0; industrija < 8; industrija++)
					if (korporacija[napadnut_igrac, industrija].Visible)
						if (deonice[igrac, industrija].compare(10) >= 0)
						{
							Bkorporacija[industrija].Visible = true;
							Bkorporacija[industrija].Enabled = true;
							kradja_korporacije[industrija] = true;
						}
			}

			//preuzimanje kompanije
			for (int industrija = 0; industrija < 8; industrija++)
			{
				bool ind = !Bkorporacija[industrija].Visible;
				if (Bdeonice[industrija].compare(0) > 0)
					Bdeonice[industrija].Enabled = true;
				if (deonice[igrac_na_potezu, industrija].compare(3) >= 0)//Moze da se preuzme kompanija.
				{
					for (int komp = 0; komp < 3; komp++)
						if (Bkompanija[industrija, komp].Visible)
						{
							Bkompanija[industrija, komp].Enabled = true;
							ind = false;
						}
					//Da li postoji korporacija:
					for (napadnut_igrac = 0; napadnut_igrac < 6; napadnut_igrac++)
						if (korporacija[napadnut_igrac, industrija].Visible)
						{
							ind = false;
							break;
						}
					if (ind)//Sve kompanije su preuzete, pa mogu da se kradu.
					{
						for (int komp = 0; komp < 3; komp++)
							if (!kompanija[igrac, industrija, komp].Visible)
								Bkompanija[industrija, komp].Visible = true;
						kradja_kompanije[industrija] = true;
					}
				}
			}

			for (igrac = 0; igrac < 6; igrac++)
			{
				kupi[igrac].Visible = false;
				prodaj[igrac].Visible = false;
				uzmi[igrac].Visible = false;
				izgubi[igrac].Visible = false;
				dividenda[igrac].Visible = false;
			}
			cancel.Visible = true;
			dodajnovac.Visible = false;
			oduzminovac.Visible = false;
			skok_proizvodnje.Visible = false;
			lose_poslovanje.Visible = false;
		}

		public void Kupi_deonicu(int industrija)
		{
			industrija--;

			if (pritisnuto_dugme == 100)//skok proizvodnje
			{
				for (int igrac = 0; igrac < 6; igrac++)
					if (korporacija[igrac, industrija].Visible)
						novac[igrac].plus(50000);
					else
						for (int i = 0; i < 3; i++)
							if (kompanija[igrac, industrija, i].Visible)
								novac[igrac].plus(10000);
				Cancel();
				return;
			}
			if (pritisnuto_dugme == 101)//lose poslovanje
			{
				Bdeonice[industrija].Text = "16";
				for (int igrac = 0; igrac < 6; igrac++)
				{
					if (deonice[igrac, industrija].compare(0) > 0)
					{
						deonice[igrac, industrija].minus(1);
						Bdeonice[industrija].minus(int.Parse(deonice[igrac, industrija].Text));
					}
				}
				Cancel();
				return;
			}

			if (deonice[igrac_na_potezu, industrija].compare(16) >= 0)
				Cancel();

			if (pritisnuto_dugme < 2)//kupovina/uzimanje deonica
			{
				deonice[igrac_na_potezu, industrija].plus(1);
				if (pritisnuto_dugme == 0)
					novac[igrac_na_potezu].minus(cena_deonice(industrija));
				if (Bdeonice[industrija].compare(0) == 0)//kupovina deonica od drugog igraca jer nema u banci
				{
					if (pritisnuto_dugme != 0)
						Cancel();
					int min = 16;
					List<int> ind = new();
					for (int igrac = 0; igrac < 6; igrac++)
						if (igrac != igrac_na_potezu)
							if (deonice[igrac, industrija].compare(min) <= 0 && deonice[igrac, industrija].compare(0) > 0)
							{
								if (deonice[igrac, industrija].compare(min) < 0)
									ind.Clear();
								min = int.Parse(deonice[igrac, industrija].Text);
								ind.Add(igrac);
							}
					if (ind.Count == 1)
					{
						deonice[ind[0], industrija].minus(1);
						novac[ind[0]].plus(cena_deonice(industrija));
					}
					else
					{
						pritisnuto_dugme = 10 + industrija;
						for (industrija = 0; industrija < 8; industrija++)
							Bdeonice[industrija].Enabled = false;
						for (int igrac = 0; igrac < 6; igrac++)
						{
							kupi[igrac].Visible = false;
							uzmi[igrac].Visible = false;
							prodaj[igrac].Visible = false;
							izgubi[igrac].Visible = false;
							dividenda[igrac].Visible = false;
						}
						cancel.Visible = false;
						skok_proizvodnje.Visible = false;
						lose_poslovanje.Visible = false;
						dodajnovac.Visible = false;
						oduzminovac.Visible = false;
						foreach (int igrac in ind)
							kupi[igrac].Visible = true;
						return;
					}
				}
				else
					Bdeonice[industrija].minus(1);

				Cancel();
			}
			else//prodaja/gubitak deonica
			{
				deonice[igrac_na_potezu, industrija].minus(1);
				if (pritisnuto_dugme == 2)
					novac[igrac_na_potezu].plus(cena_deonice(industrija));
				Bdeonice[industrija].plus(1);
				Prodaj(igrac_na_potezu + 1);
			}
		}

		public int cena_deonice(int industrija)
		{
			int cena = 0;
			int igrac;
			industrija++;
			if (industrija == 7)
				cena = 16000;
			else if (industrija == 8)
				cena = 20000;
			else
				cena = industrija * 2000;
			industrija--;

			bool ima_korporaciju = false;
			for (igrac = 0; igrac < 6; igrac++)//ko ima tu korporaciju
				if (korporacija[igrac, industrija].Visible)
				{
					ima_korporaciju = true;
					break;
				}
			if (ima_korporaciju)
			{
				cena += cena / 2;
				for (int kont = 0; kont < 6; kont++)
					if (kontinent[igrac, kont].Text.Contains(Skracenica_industrije(industrija)))
						cena += (6 - kont) * 2000;
			}
			return cena;
		}

		private int cena_objekta(int industrija)
		{
			industrija += 2;
			industrija /= 2;
			return industrija * 5000;
		}

		private int cena_kontinenta(int kont)
		{
			return (6 - kont) * 100000;
		}

		private void Preuzmi_kompaniju(int industrija, int komp)//Ovde se pokriva i kupovina i prodaja objekta.
		{
			industrija--;

			if (kompanija[igrac_na_potezu, industrija, komp].Visible)//kupovina i prodaja objekta
			{
				if (pritisnuto_dugme == 0)//kupovina objekta
				{
					kompanija[igrac_na_potezu, industrija, komp].Text = "OB";
					novac[igrac_na_potezu].minus(cena_objekta(industrija));
				}
				else if (pritisnuto_dugme == 2)//prodaja objekta
				{
					kompanija[igrac_na_potezu, industrija, komp].Text = "";
					novac[igrac_na_potezu].plus(cena_objekta(industrija));
				}
				Izracunaj_dividendu(igrac_na_potezu);
				Cancel();
				return;
			}

			deonice[igrac_na_potezu, industrija].minus(3);
			Bdeonice[industrija].plus(3);
			if (!kradja_kompanije[industrija])
			{
				Bkompanija[industrija, komp].Visible = false;
				kompanija[igrac_na_potezu, industrija, komp].Visible = true;
				Izracunaj_dividendu(igrac_na_potezu);
				Cancel();
				return;
			}
			//kradja kompanije
			for (napadnut_igrac = 0; napadnut_igrac < 6; napadnut_igrac++)
			{
				if (kompanija[napadnut_igrac, industrija, komp].Visible)
					break;
			}
			if (deonice[napadnut_igrac, industrija].compare(3) >= 0)
			{
				brani.Visible = true;
				nebrani.Visible = true;
				cancel.Visible = false;
				napadnut_igrac += industrija * 10;//Druga cifra je industrija.
				napadnut_igrac += komp * 100;
			}
			else
			{
				napadnut_igrac += industrija * 10;//Druga cifra je industrija.
				napadnut_igrac += komp * 100;
				ne_brani();
			}
		}

		private string Skracenica_industrije(int industrija)
		{
			switch (industrija)
			{
				case 0:
					return "HR";
				case 1:
					return "IG";
				case 2:
					return "OD";
				case 3:
					return "OB";
				case 4:
					return "NM";
				case 5:
					return "EL";
				case 6:
					return "AU";
				default:
					return "NF";
			}
		}

		private void Preuzmi_korporaciju(int industrija)
		{
			industrija--;
			if (pritisunti_kontinent >= 0)//kupovina kontinenta, bira se industrija za koju se kupuje
			{
				Kupi_kontinent_2(industrija, false);
				return;
			}

			if (!kradja_korporacije[industrija])
			{
				deonice[igrac_na_potezu, industrija].minus(5);
				Bdeonice[industrija].plus(5);
				for (int komp = 0; komp < 3; komp++)
				{
					kompanija[igrac_na_potezu, industrija, komp].Visible = false;
					for (int igrac = 0; igrac < 6; igrac++)
						kompanija[igrac, industrija, komp].Text = "";
					Bkompanija[industrija, komp].Visible = false;
				}
				korporacija[igrac_na_potezu, industrija].Visible = true;
				for (int kont = 0; kont < 6; kont++)
					kontinent[igrac_na_potezu, kont].Visible = true;
				Izracunaj_dividendu(igrac_na_potezu);
				Cancel();
				return;
			}

			//kradja korporacije
			deonice[igrac_na_potezu, industrija].minus(10);
			for (int kont = 0; kont < 6; kont++)//prodaja svih kontinenata
				if (kontinent[napadnut_igrac, kont].Text.Length > 1)
				{
					kontinent[napadnut_igrac, kont].Text += " ";
					kontinent[napadnut_igrac, kont].Text =
						kontinent[napadnut_igrac, kont].Text.Replace(Skracenica_industrije(industrija) + " ", "").Trim();
					novac[napadnut_igrac].plus(cena_kontinenta(kont));
				}
			Bdeonice[industrija].plus(10);
			for (napadnut_igrac = 0; napadnut_igrac < 6; napadnut_igrac++)
			{
				if (korporacija[napadnut_igrac, industrija].Visible)
					break;
			}
			korporacija[napadnut_igrac, industrija].Visible = false;
			//Ako napadnuti igrac nema drugu korporaciju, sakrivaju se informacije o kontinentima:
			bool ima_korporaciju = false;
			for (int i = 0; i < 6; i++)//ko ima tu korporaciju
				if (korporacija[napadnut_igrac, i].Visible)
				{
					ima_korporaciju = true;
					break;
				}
			if (!ima_korporaciju)
				for (int kont = 0; kont < 6; kont++)
					kontinent[napadnut_igrac, kont].Visible = false;
			korporacija[igrac_na_potezu, industrija].Visible = true;
			for (int kont = 0; kont < 6; kont++)
				kontinent[igrac_na_potezu, kont].Visible = true;
			Izracunaj_dividendu(napadnut_igrac);
			Izracunaj_dividendu(igrac_na_potezu);
			Cancel();
		}

		private void skok_proizvodnje_Click(object sender, EventArgs e)
		{
			lose_poslovanje.Visible = false;
			skok_proizvodnje.Visible = false;
			oduzminovac.Visible = false;
			dodajnovac.Visible = false;
			cancel.Visible = true;
			pritisnuto_dugme = 100;

			for (int industrija = 0; industrija < 8; industrija++)
				Bdeonice[industrija].Enabled = true;
		}

		private void lose_poslovanje_Click(object sender, EventArgs e)
		{
			lose_poslovanje.Visible = false;
			skok_proizvodnje.Visible = false;
			oduzminovac.Visible = false;
			dodajnovac.Visible = false;
			cancel.Visible = true;
			pritisnuto_dugme = 101;
			//za elementarne nepogode:
			for (int kont = 0; kont < 6; kont++)
			{
				for (int igrac = 0; igrac < 6; igrac++)
					if (kontinent[igrac, kont].Text.Length > 0)
						Bkontinent[kont].Visible = true;
			}

			for (int industrija = 0; industrija < 8; industrija++)
				Bdeonice[industrija].Enabled = true;
		}

		private void Kupi_kontinent(int kont)
		{
			kont--;

			if (pritisnuto_dugme >= 100)//elementarna nepogoda
			{
				for (int igrac = 0; igrac < 6; igrac++)
					if (kontinent[igrac, kont].Text.Length > 0)
						novac[igrac].minus(kontinent[igrac, kont].Text.Length / 2 * (6 - kont) * 5000);
				Cancel();
				return;
			}

			int broj_korporacija = 0;
			int industrija = 0;
			for (int i = 0; i < 8; i++)
				if (korporacija[igrac_na_potezu, i].Visible)
				{
					broj_korporacija++;
					industrija = i;
				}
			if (broj_korporacija == 1)
			{
				pritisunti_kontinent = kont;
				Kupi_kontinent_2(industrija, true);
			}
			else if (broj_korporacija > 1)
			{
				if (pritisnuto_dugme == 0)
				{
					for (industrija = 0; industrija < 8; industrija++)
					{
						if (korporacija[igrac_na_potezu, industrija].Visible &&
							!kontinent[igrac_na_potezu, kont].Text.Contains(Skracenica_industrije(industrija)))
						{
							Bkorporacija[industrija].Visible = true;
							Bkorporacija[industrija].Enabled = true;
						}
						Bdeonice[industrija].Enabled = false;
						for (int kompanija = 0; kompanija < 3; kompanija++)
							Bkompanija[industrija, kompanija].Enabled = false;
					}
					for (int k = 0; k < 6; k++)
						Bkontinent[k].Visible = false;
				}
				else if (pritisnuto_dugme == 2)
				{
					for (industrija = 0; industrija < 8; industrija++)
					{
						if (korporacija[igrac_na_potezu, industrija].Visible &&
							kontinent[igrac_na_potezu, kont].Text.Contains(Skracenica_industrije(industrija)))
						{
							Bkorporacija[industrija].Visible = true;
							Bkorporacija[industrija].Enabled = true;
						}
						Bdeonice[industrija].Enabled = false;
						for (int kompanija = 0; kompanija < 3; kompanija++)
							Bkompanija[industrija, kompanija].Enabled = false;
					}
					for (int k = 0; k < 6; k++)
						Bkontinent[k].Visible = false;
				}
				pritisunti_kontinent = kont;
			}
		}

		private void Kupi_kontinent_2(int industrija, bool jedna_korporacija)
		{
			if (pritisnuto_dugme == 0)//kupovina kontinenta
			{
				kontinent[igrac_na_potezu, pritisunti_kontinent].Text += " " + Skracenica_industrije(industrija);
				kontinent[igrac_na_potezu, pritisunti_kontinent].Text = kontinent[igrac_na_potezu, pritisunti_kontinent].Text.Trim();
				novac[igrac_na_potezu].minus(cena_kontinenta(pritisunti_kontinent));
				Cancel();
			}
			else if (pritisnuto_dugme == 2)//prodaja kontinenta
			{
				kontinent[igrac_na_potezu, pritisunti_kontinent].Text += " ";
				kontinent[igrac_na_potezu, pritisunti_kontinent].Text =
					kontinent[igrac_na_potezu, pritisunti_kontinent].Text.Replace(Skracenica_industrije(industrija) + " ", "").Trim();
				novac[igrac_na_potezu].plus(cena_kontinenta(pritisunti_kontinent) * 3 / 4);
				if (!jedna_korporacija)
					Cancel();
			}
			Izracunaj_dividendu(igrac_na_potezu);
		}

		private void brani_Click(object sender, EventArgs e)
		{
			napadnut_igrac %= 100;
			int industrija = napadnut_igrac / 10;
			napadnut_igrac %= 10;
			deonice[napadnut_igrac, industrija].minus(3);
			Bdeonice[industrija].plus(3);
			Cancel();
		}

		private void ne_brani()
		{
			int komp = napadnut_igrac / 100;
			napadnut_igrac %= 100;
			int industrija = napadnut_igrac / 10;
			napadnut_igrac %= 10;
			kompanija[napadnut_igrac, industrija, komp].Visible = false;
			kompanija[igrac_na_potezu, industrija, komp].Visible = true;
			if (kompanija[napadnut_igrac, industrija, komp].Text.Equals("OB"))
			{
				kompanija[igrac_na_potezu, industrija, komp].Text = "OB";
				kompanija[napadnut_igrac, industrija, komp].Text = "";
			}
			Izracunaj_dividendu(napadnut_igrac);
			Izracunaj_dividendu(igrac_na_potezu);
			Cancel();
		}

		private void Prodaj(int igrac)
		{
			igrac--;
			igrac_na_potezu = igrac;
			pritisnuto_dugme = 2;

			for (int industrija = 0; industrija < 8; industrija++)//prodaja objekata
			{
				if (deonice[igrac, industrija].compare(0) > 0)
					Bdeonice[industrija].Enabled = true;
				else
					Bdeonice[industrija].Enabled = false;
				for (int komp = 0; komp < 3; komp++)
					if (kompanija[igrac, industrija, komp].Text.Equals("OB"))
					{
						Bkompanija[industrija, komp].Visible = true;
						Bkompanija[industrija, komp].Enabled = true;
					}
			}

			for (int industrija = 0; industrija < 8; industrija++)//prodaja kontinenata
				if (korporacija[igrac, industrija].Visible)
					for (int kont = 0; kont < 6; kont++)
						if (kontinent[igrac, kont].Text.Length > 1)
							Bkontinent[kont].Visible = true;

			for (igrac = 0; igrac < 6; igrac++)
			{
				kupi[igrac].Visible = false;
				prodaj[igrac].Visible = false;
				uzmi[igrac].Visible = false;
				izgubi[igrac].Visible = false;
				dividenda[igrac].Visible = false;
			}
			cancel.Visible = true;
			dodajnovac.Visible = false;
			oduzminovac.Visible = false;
			skok_proizvodnje.Visible = false;
			lose_poslovanje.Visible = false;
		}

		private void Izgubi(int igrac)
		{
			igrac--;
			igrac_na_potezu = igrac;
			pritisnuto_dugme = 3;
			for (int industrija = 0; industrija < 8; industrija++)
			{
				if (deonice[igrac, industrija].compare(0) > 0)
					Bdeonice[industrija].Enabled = true;
			}

			for (igrac = 0; igrac < 6; igrac++)
			{
				kupi[igrac].Visible = false;
				prodaj[igrac].Visible = false;
				uzmi[igrac].Visible = false;
				izgubi[igrac].Visible = false;
				dividenda[igrac].Visible = false;
			}
			cancel.Visible = true;
			dodajnovac.Visible = false;
			oduzminovac.Visible = false;
			skok_proizvodnje.Visible = false;
			lose_poslovanje.Visible = false;
		}

		private void Izracunaj_dividendu(int igrac)
		{
			int dividenda = 0;
			for (int industrija = 0; industrija < 8; industrija++)
				if (korporacija[igrac, industrija].Visible)
					dividenda += (industrija * 1000 + 8000) * 4;
				else
					for (int komp = 0; komp < 3; komp++)
						if (kompanija[igrac, industrija, komp].Visible)
						{
							dividenda += industrija * 1000 + 7000;
							if (kompanija[igrac, industrija, komp].Text.Equals("OB"))
								dividenda += 1000;
						}

			for (int kont = 0; kont < 6; kont++)//racuna se samo jednom
				dividenda += kontinent[igrac, kont].Text.Length / 2 * (6 - kont) * 5000;

			trenutna_dividenda[igrac].Text = dividenda.ToString();
		}

		public void Dividenda(int igrac)
		{
			igrac--;
			novac[igrac].plus(int.Parse(trenutna_dividenda[igrac].Text));
		}

		private void kupi1_Click(object sender, EventArgs e)
		{
			Kupi(1);
		}

		private void kupi2_Click(object sender, EventArgs e)
		{
			Kupi(2);
		}

		private void kupi3_Click(object sender, EventArgs e)
		{
			Kupi(3);
		}

		private void kupi4_Click(object sender, EventArgs e)
		{
			Kupi(4);
		}

		private void kupi5_Click(object sender, EventArgs e)
		{
			Kupi(5);
		}

		private void kupi6_Click(object sender, EventArgs e)
		{
			Kupi(6);
		}

		private void prodaj1_Click(object sender, EventArgs e)
		{
			Prodaj(1);
		}

		private void prodaj2_Click(object sender, EventArgs e)
		{
			Prodaj(2);
		}

		private void prodaj3_Click(object sender, EventArgs e)
		{
			Prodaj(3);
		}

		private void prodaj4_Click(object sender, EventArgs e)
		{
			Prodaj(4);
		}

		private void prodaj5_Click(object sender, EventArgs e)
		{
			Prodaj(5);
		}

		private void prodaj6_Click(object sender, EventArgs e)
		{
			Prodaj(6);
		}

		private void uzmi1_Click(object sender, EventArgs e)
		{
			Uzmi(1);
		}

		private void uzmi2_Click(object sender, EventArgs e)
		{
			Uzmi(2);
		}

		private void uzmi3_Click(object sender, EventArgs e)
		{
			Uzmi(3);
		}

		private void uzmi4_Click(object sender, EventArgs e)
		{
			Uzmi(4);
		}

		private void uzmi5_Click(object sender, EventArgs e)
		{
			Uzmi(5);
		}

		private void uzmi6_Click(object sender, EventArgs e)
		{
			Uzmi(6);
		}

		private void izgubi1_Click(object sender, EventArgs e)
		{
			Izgubi(1);
		}

		private void izgubi2_Click(object sender, EventArgs e)
		{
			Izgubi(2);
		}

		private void izgubi3_Click(object sender, EventArgs e)
		{
			Izgubi(3);
		}

		private void izgubi4_Click(object sender, EventArgs e)
		{
			Izgubi(4);
		}

		private void izgubi5_Click(object sender, EventArgs e)
		{
			Izgubi(5);
		}

		private void izgubi6_Click(object sender, EventArgs e)
		{
			Izgubi(6);
		}

		private void dividenda1_Click(object sender, EventArgs e)
		{
			Dividenda(1);
		}

		private void dividenda2_Click(object sender, EventArgs e)
		{
			Dividenda(2);
		}

		private void dividenda3_Click(object sender, EventArgs e)
		{
			Dividenda(3);
		}

		private void dividenda4_Click(object sender, EventArgs e)
		{
			Dividenda(4);
		}

		private void dividenda5_Click(object sender, EventArgs e)
		{
			Dividenda(5);
		}

		private void dividenda6_Click(object sender, EventArgs e)
		{
			Dividenda(6);
		}

		private void deonice1_Click(object sender, EventArgs e)
		{
			Kupi_deonicu(1);
		}

		private void deonice2_Click(object sender, EventArgs e)
		{
			Kupi_deonicu(2);
		}

		private void deonice3_Click(object sender, EventArgs e)
		{
			Kupi_deonicu(3);
		}

		private void deonice4_Click(object sender, EventArgs e)
		{
			Kupi_deonicu(4);
		}

		private void deonice5_Click(object sender, EventArgs e)
		{
			Kupi_deonicu(5);
		}

		private void deonice6_Click(object sender, EventArgs e)
		{
			Kupi_deonicu(6);
		}

		private void deonice7_Click(object sender, EventArgs e)
		{
			Kupi_deonicu(7);
		}

		private void deonice8_Click(object sender, EventArgs e)
		{
			Kupi_deonicu(8);
		}

		private void cancel_Click(object sender, EventArgs e)
		{
			Cancel();
		}

		private void proizvodnja8_Click(object sender, EventArgs e)
		{
			Preuzmi_kompaniju(8, 0);
		}

		private void proizvodnja7_Click(object sender, EventArgs e)
		{
			Preuzmi_kompaniju(7, 0);
		}

		private void proizvodnja6_Click(object sender, EventArgs e)
		{
			Preuzmi_kompaniju(6, 0);
		}

		private void proizvodnja5_Click(object sender, EventArgs e)
		{
			Preuzmi_kompaniju(5, 0);
		}

		private void proizvodnja4_Click(object sender, EventArgs e)
		{
			Preuzmi_kompaniju(4, 0);
		}

		private void proizvodnja3_Click(object sender, EventArgs e)
		{
			Preuzmi_kompaniju(3, 0);
		}

		private void proizvodnja2_Click(object sender, EventArgs e)
		{
			Preuzmi_kompaniju(2, 0);
		}

		private void proizvodnja1_Click(object sender, EventArgs e)
		{
			Preuzmi_kompaniju(1, 0);
		}

		private void veleprodaja8_Click(object sender, EventArgs e)
		{
			Preuzmi_kompaniju(8, 1);
		}

		private void veleprodaja7_Click(object sender, EventArgs e)
		{
			Preuzmi_kompaniju(7, 1);
		}

		private void veleprodaja6_Click(object sender, EventArgs e)
		{
			Preuzmi_kompaniju(6, 1);
		}

		private void veleprodaja5_Click(object sender, EventArgs e)
		{
			Preuzmi_kompaniju(5, 1);
		}

		private void veleprodaja4_Click(object sender, EventArgs e)
		{
			Preuzmi_kompaniju(4, 1);
		}

		private void veleprodaja3_Click(object sender, EventArgs e)
		{
			Preuzmi_kompaniju(3, 1);
		}

		private void veleprodaja2_Click(object sender, EventArgs e)
		{
			Preuzmi_kompaniju(2, 1);
		}

		private void veleprodaja1_Click(object sender, EventArgs e)
		{
			Preuzmi_kompaniju(1, 1);
		}

		private void maloprodaja8_Click(object sender, EventArgs e)
		{
			Preuzmi_kompaniju(8, 2);
		}

		private void maloprodaja7_Click(object sender, EventArgs e)
		{
			Preuzmi_kompaniju(7, 2);
		}

		private void maloprodaja6_Click(object sender, EventArgs e)
		{
			Preuzmi_kompaniju(6, 2);
		}

		private void maloprodaja5_Click(object sender, EventArgs e)
		{
			Preuzmi_kompaniju(5, 2);
		}

		private void maloprodaja4_Click(object sender, EventArgs e)
		{
			Preuzmi_kompaniju(4, 2);
		}

		private void maloprodaja3_Click(object sender, EventArgs e)
		{
			Preuzmi_kompaniju(3, 2);
		}

		private void maloprodaja2_Click(object sender, EventArgs e)
		{
			Preuzmi_kompaniju(2, 2);
		}

		private void maloprodaja1_Click(object sender, EventArgs e)
		{
			Preuzmi_kompaniju(1, 2);
		}

		private void nebrani_Click(object sender, EventArgs e)
		{
			ne_brani();
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void korporacija1_Click(object sender, EventArgs e)
		{
			Preuzmi_korporaciju(1);
		}

		private void korporacija2_Click(object sender, EventArgs e)
		{
			Preuzmi_korporaciju(2);
		}

		private void korporacija3_Click(object sender, EventArgs e)
		{
			Preuzmi_korporaciju(3);
		}

		private void korporacija4_Click(object sender, EventArgs e)
		{
			Preuzmi_korporaciju(4);
		}

		private void korporacija5_Click(object sender, EventArgs e)
		{
			Preuzmi_korporaciju(5);
		}

		private void korporacija6_Click(object sender, EventArgs e)
		{
			Preuzmi_korporaciju(6);
		}

		private void korporacija7_Click(object sender, EventArgs e)
		{
			Preuzmi_korporaciju(7);
		}

		private void korporacija8_Click(object sender, EventArgs e)
		{
			Preuzmi_korporaciju(8);
		}

		private void dodaj_novac_Click(object sender, EventArgs e)
		{
			for (int igrac = 0; igrac < 6; igrac++)
				if (int.TryParse(dodaj_novac[igrac].Text, out _))
				{
					novac[igrac].plus(int.Parse(dodaj_novac[igrac].Text) * 1000);
					dodaj_novac[igrac].Text = "";
				}
		}

		private void oduzmi_novac_Click(object sender, EventArgs e)
		{
			for (int igrac = 0; igrac < 6; igrac++)
				if (int.TryParse(dodaj_novac[igrac].Text, out _))
				{
					novac[igrac].minus(int.Parse(dodaj_novac[igrac].Text) * 1000);
					dodaj_novac[igrac].Text = "";
				}
		}

		private void kontinent1_Click(object sender, EventArgs e)
		{
			Kupi_kontinent(1);
			kontinent1.Visible = false;
		}

		private void kontinent2_Click(object sender, EventArgs e)
		{
			Kupi_kontinent(2);
			kontinent2.Visible = false;
		}

		private void kontinent3_Click(object sender, EventArgs e)
		{
			Kupi_kontinent(3);
			kontinent3.Visible = false;
		}

		private void kontinent4_Click(object sender, EventArgs e)
		{
			Kupi_kontinent(4);
			kontinent4.Visible = false;
		}

		private void kontinent5_Click(object sender, EventArgs e)
		{
			Kupi_kontinent(5);
			kontinent5.Visible = false;
		}

		private void kontinent6_Click(object sender, EventArgs e)
		{
			Kupi_kontinent(6);
			kontinent6.Visible = false;
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			//	FormSerialisor.Serialise(this, Application.StartupPath + @"\Trenutno_stanje.xml");
		}

		private void nova_igra_Click(object sender, EventArgs e)
		{
			//	FormSerialisor.Serialise(this, Application.StartupPath + @"\Trenutno_stanje.xml");
			kontroler = new();
			Pocetak pocetak = new(this, kontroler, ime);
			Cancel();
			pocetak.Show();
			this.Hide();
		}

		public void Nova_igra(string[] imena)
		{
			int prazna_imena = 0;
			broj_igraca = 6;
			for (int igrac = 0; igrac < broj_igraca; igrac++)
			{
				if (imena[igrac].Equals(""))
				{
					prazna_imena++;
					broj_igraca--;
					igrac--;
				}
				else
					ime[igrac].Text = imena[igrac];
			}
			set_width();
		}

		private void set_width()
		{
			MaximumSize = new System.Drawing.Size(0, 0);
			MinimumSize = new System.Drawing.Size(0, 0);
			Width = 1575;
			for (int igrac = 5; ime[igrac].Text.Equals("") && igrac >= 2; igrac--)
				Width -= 222;
			MaximumSize = new System.Drawing.Size(Width, Height);
			MinimumSize = new System.Drawing.Size(Width, Height);
		}

		private void otvori_kontroler_Click(object sender, EventArgs e)
		{
			if (kontroler == null)
			{
				kontroler = new Kontroler();
				kontroler.Nova_igra(this, broj_igraca);
			}
			kontroler.Show();
		}
	}
}