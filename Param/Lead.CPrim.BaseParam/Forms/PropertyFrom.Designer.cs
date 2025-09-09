namespace Lead.CPrim.BaseParam
{
	public partial class PropertyFrom 
    {
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 35);
            this.propertyGrid1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(600, 465);
            this.propertyGrid1.TabIndex = 1;
            // 
            // PropertyFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.propertyGrid1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "PropertyFrom";
            this.RectColor = System.Drawing.Color.Gray;
            this.Style = Lead.CPrim.ProxyTools.SunnyUI.Style.UIStyle.Custom;
            this.StyleCustomMode = true;
            this.Text = "属性";
            this.TitleColor = System.Drawing.Color.Gray;
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 660, 698);
            this.Load += new System.EventHandler(this.PropertyFrom_Load);
            this.ResumeLayout(false);

		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private global::System.ComponentModel.IContainer components = null;

		private global::System.Windows.Forms.PropertyGrid propertyGrid1;
	}
}
