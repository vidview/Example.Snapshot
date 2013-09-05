using System;
using Forms = System.Windows.Forms;
using Settings = Kean.Platform.Settings;
using Vidhance = Imint.Vidhance;
using Example.SnapshotToolbar.Extension;

namespace Example.SnapshotToolbar
{
	public class Viewer : 
		Forms.UserControl
	{
		Imint.Vidview.Viewer vidview;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private Kean.Core.Uri.Locator locator;
		private System.Windows.Forms.Button snapshot;
		private System.Windows.Forms.CheckBox checkBox1;

		public Viewer()
		{
			this.InitializeComponent();
			this.vidview.Started += () =>
			{
				// We need to make sure components are initialized before hooking the buttons up, 
				// or we'll get NREs if any dll or valid license for those components is missing.
				if (this.vidview.Snapshot != null)
				{
					this.snapshot.Click += (object sender, EventArgs e) =>
					{
						if (this.vidview.Snapshot.Capture("original", this.locator = "file:///$(Pictures)snapshot-$(Time:mmssfff).png") && this.checkBox1.Checked)
							System.Diagnostics.Process.Start(locator.PlatformPath);
					};
				}
				// When the Vidview viewer is closed force shutdown of the full application.
				this.vidview.Closed += System.Windows.Forms.Application.Exit;
				// When the Vidview viewer is fully initialized open test://photo. In case of errors shut down the viewer and the application.
				if (!(this.vidview.Media != null && this.vidview.Media.Open("test://photo")))
					this.vidview.Close();
			};
		}

		void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Viewer));
			this.vidview = new Imint.Vidview.Viewer();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.snapshot = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// vidview
			// 
			this.vidview.Asynchronous = Kean.Platform.Settings.Asynchronous.None;
			this.vidview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.vidview.Location = new System.Drawing.Point(3, 16);
			this.vidview.Name = "vidview";
			this.vidview.Size = new System.Drawing.Size(144, 131);
			this.vidview.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.vidview, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.252669F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.74733F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(150, 150);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.snapshot);
			this.flowLayoutPanel1.Controls.Add(this.checkBox1);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(144, 7);
			this.flowLayoutPanel1.TabIndex = 1;
			// 
			// snapshot
			// 
			this.snapshot.Image = ((System.Drawing.Image)(resources.GetObject("snapshot.Image")));
			this.snapshot.Location = new System.Drawing.Point(3, 3);
			this.snapshot.Name = "snapshot";
			this.snapshot.Size = new System.Drawing.Size(38, 38);
			this.snapshot.TabIndex = 0;
			this.snapshot.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Dock = Forms.DockStyle.Fill;
			this.checkBox1.Location = new System.Drawing.Point(47, 3);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(38, 38);
			this.checkBox1.TabIndex = 1;
			this.checkBox1.Text = "Open";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// Viewer
			// 
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "Viewer";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

	}
}
