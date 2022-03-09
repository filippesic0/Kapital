namespace Kapital
{
	partial class Pocetak
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
			this.igrac1 = new System.Windows.Forms.TextBox();
			this.igrac2 = new System.Windows.Forms.TextBox();
			this.igrac3 = new System.Windows.Forms.TextBox();
			this.igrac6 = new System.Windows.Forms.TextBox();
			this.igrac5 = new System.Windows.Forms.TextBox();
			this.igrac4 = new System.Windows.Forms.TextBox();
			this.ok = new System.Windows.Forms.Button();
			this.cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// igrac1
			// 
			this.igrac1.BackColor = System.Drawing.Color.White;
			this.igrac1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.igrac1.Location = new System.Drawing.Point(12, 12);
			this.igrac1.Name = "igrac1";
			this.igrac1.Size = new System.Drawing.Size(176, 36);
			this.igrac1.TabIndex = 65;
			this.igrac1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// igrac2
			// 
			this.igrac2.BackColor = System.Drawing.Color.White;
			this.igrac2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.igrac2.Location = new System.Drawing.Point(12, 54);
			this.igrac2.Name = "igrac2";
			this.igrac2.Size = new System.Drawing.Size(176, 36);
			this.igrac2.TabIndex = 66;
			this.igrac2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// igrac3
			// 
			this.igrac3.BackColor = System.Drawing.Color.White;
			this.igrac3.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.igrac3.Location = new System.Drawing.Point(12, 96);
			this.igrac3.Name = "igrac3";
			this.igrac3.Size = new System.Drawing.Size(176, 36);
			this.igrac3.TabIndex = 67;
			this.igrac3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// igrac6
			// 
			this.igrac6.BackColor = System.Drawing.Color.White;
			this.igrac6.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.igrac6.Location = new System.Drawing.Point(12, 222);
			this.igrac6.Name = "igrac6";
			this.igrac6.Size = new System.Drawing.Size(176, 36);
			this.igrac6.TabIndex = 70;
			this.igrac6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// igrac5
			// 
			this.igrac5.BackColor = System.Drawing.Color.White;
			this.igrac5.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.igrac5.Location = new System.Drawing.Point(12, 180);
			this.igrac5.Name = "igrac5";
			this.igrac5.Size = new System.Drawing.Size(176, 36);
			this.igrac5.TabIndex = 69;
			this.igrac5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// igrac4
			// 
			this.igrac4.BackColor = System.Drawing.Color.White;
			this.igrac4.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.igrac4.Location = new System.Drawing.Point(12, 138);
			this.igrac4.Name = "igrac4";
			this.igrac4.Size = new System.Drawing.Size(176, 36);
			this.igrac4.TabIndex = 68;
			this.igrac4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ok
			// 
			this.ok.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.ok.Location = new System.Drawing.Point(12, 264);
			this.ok.Name = "ok";
			this.ok.Size = new System.Drawing.Size(176, 36);
			this.ok.TabIndex = 71;
			this.ok.Text = "Nova igra";
			this.ok.UseVisualStyleBackColor = true;
			this.ok.Click += new System.EventHandler(this.ok_Click);
			// 
			// cancel
			// 
			this.cancel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.cancel.Location = new System.Drawing.Point(12, 306);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(176, 36);
			this.cancel.TabIndex = 72;
			this.cancel.Text = "Nazad";
			this.cancel.UseVisualStyleBackColor = true;
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			// 
			// Pocetak
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(200, 354);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.ok);
			this.Controls.Add(this.igrac6);
			this.Controls.Add(this.igrac5);
			this.Controls.Add(this.igrac4);
			this.Controls.Add(this.igrac3);
			this.Controls.Add(this.igrac2);
			this.Controls.Add(this.igrac1);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(216, 393);
			this.MinimumSize = new System.Drawing.Size(216, 393);
			this.Name = "Pocetak";
			this.Text = "Unesi imena igraca";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private TextBox igrac1;
		private TextBox igrac2;
		private TextBox igrac3;
		private TextBox igrac6;
		private TextBox igrac5;
		private TextBox igrac4;
		private Button ok;
		private Button cancel;
	}
}