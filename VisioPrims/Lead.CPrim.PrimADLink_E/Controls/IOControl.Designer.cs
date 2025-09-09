namespace Lead.CPrim.PrimADLink_E.Controls
{
    partial class IOControl
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
            this.components = new System.ComponentModel.Container();
            this.tablePanelControl = new System.Windows.Forms.TableLayoutPanel();
            this.tmrCycle = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tablePanelControl
            // 
            this.tablePanelControl.AutoScroll = true;
            this.tablePanelControl.ColumnCount = 1;
            this.tablePanelControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanelControl.Location = new System.Drawing.Point(0, 0);
            this.tablePanelControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tablePanelControl.Name = "tablePanelControl";
            this.tablePanelControl.RowCount = 1;
            this.tablePanelControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanelControl.Size = new System.Drawing.Size(933, 637);
            this.tablePanelControl.TabIndex = 0;
            // 
            // tmrCycle
            // 
            this.tmrCycle.Tick += new System.EventHandler(this.TmrCycle_Tick);
            // 
            // IOControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(933, 637);
            this.Controls.Add(this.tablePanelControl);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "IOControl";
            this.Text = "IOControl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IOControl_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tablePanelControl;
        private System.Windows.Forms.Timer tmrCycle;
    }
}