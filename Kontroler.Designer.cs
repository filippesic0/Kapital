namespace Kapital
{
	partial class Kontroler
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
			this.sledeci = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.na_potezu_box = new System.Windows.Forms.TextBox();
			this.na_tabli = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.polje = new System.Windows.Forms.TextBox();
			this.kupi_deonicu = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// sledeci
			// 
			this.sledeci.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.sledeci.Location = new System.Drawing.Point(12, 171);
			this.sledeci.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.sledeci.Name = "sledeci";
			this.sledeci.Size = new System.Drawing.Size(201, 48);
			this.sledeci.TabIndex = 72;
			this.sledeci.Text = "Sledeći potez";
			this.sledeci.UseVisualStyleBackColor = true;
			this.sledeci.Click += new System.EventHandler(this.sledeci_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label1.Location = new System.Drawing.Point(81, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(132, 32);
			this.label1.TabIndex = 73;
			this.label1.Text = "Na potezu";
			// 
			// na_potezu_box
			// 
			this.na_potezu_box.BackColor = System.Drawing.Color.White;
			this.na_potezu_box.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.na_potezu_box.Location = new System.Drawing.Point(219, 13);
			this.na_potezu_box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.na_potezu_box.Name = "na_potezu_box";
			this.na_potezu_box.ReadOnly = true;
			this.na_potezu_box.Size = new System.Drawing.Size(201, 43);
			this.na_potezu_box.TabIndex = 75;
			this.na_potezu_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// na_tabli
			// 
			this.na_tabli.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.na_tabli.Location = new System.Drawing.Point(219, 171);
			this.na_tabli.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.na_tabli.Name = "na_tabli";
			this.na_tabli.Size = new System.Drawing.Size(201, 48);
			this.na_tabli.TabIndex = 76;
			this.na_tabli.Text = "Baca se na tabli";
			this.na_tabli.UseVisualStyleBackColor = true;
			this.na_tabli.Click += new System.EventHandler(this.na_tabli_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label2.Location = new System.Drawing.Point(12, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(201, 32);
			this.label2.TabIndex = 77;
			this.label2.Text = "Stali ste na polje";
			// 
			// polje
			// 
			this.polje.BackColor = System.Drawing.Color.White;
			this.polje.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.polje.Location = new System.Drawing.Point(219, 64);
			this.polje.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.polje.Name = "polje";
			this.polje.ReadOnly = true;
			this.polje.Size = new System.Drawing.Size(201, 43);
			this.polje.TabIndex = 78;
			this.polje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// kupi_deonicu
			// 
			this.kupi_deonicu.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.kupi_deonicu.Location = new System.Drawing.Point(12, 115);
			this.kupi_deonicu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.kupi_deonicu.Name = "kupi_deonicu";
			this.kupi_deonicu.Size = new System.Drawing.Size(408, 48);
			this.kupi_deonicu.TabIndex = 79;
			this.kupi_deonicu.Text = "Kupi deonicu";
			this.kupi_deonicu.UseVisualStyleBackColor = true;
			this.kupi_deonicu.Visible = false;
			this.kupi_deonicu.Click += new System.EventHandler(this.kupi_deonicu_Click);
			// 
			// Kontroler
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(432, 232);
			this.Controls.Add(this.kupi_deonicu);
			this.Controls.Add(this.polje);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.na_tabli);
			this.Controls.Add(this.na_potezu_box);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.sledeci);
			this.Name = "Kontroler";
			this.Text = "Kontroler";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Button sledeci;
		private Label label1;
		private Button na_tabli;
		private Label label2;
		private TextBox polje;
		private Button kupi_deonicu;
		private TextBox na_potezu_box;
	}
}