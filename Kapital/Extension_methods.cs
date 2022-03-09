namespace Kapital
{
	public static class Extension_methods
	{
		public static void plus(this Control control, int broj)
		{
			control.Text = (int.Parse(control.Text) + broj).ToString();
		}

		public static void minus(this Control control, int broj)
		{
			control.Text = (int.Parse(control.Text) - broj).ToString();
		}

		public static int compare(this Control control, int broj)
		{
			if (int.Parse(control.Text) > broj)
				return 1;
			if (int.Parse(control.Text) < broj)
				return -1;
			return 0;
		}
	}
}
