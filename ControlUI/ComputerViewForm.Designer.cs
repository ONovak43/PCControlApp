namespace ControlUI
{
    partial class ComputerViewForm
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
            this.computerListView = new System.Windows.Forms.ListView();
            this.computerIcon = new System.Windows.Forms.ImageList(this.components);
            this.startAll = new System.Windows.Forms.Button();
            this.stopAll = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // computerListView
            // 
            this.computerListView.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.computerListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.computerListView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.computerListView.HideSelection = false;
            this.computerListView.LargeImageList = this.computerIcon;
            this.computerListView.Location = new System.Drawing.Point(144, 12);
            this.computerListView.MultiSelect = false;
            this.computerListView.Name = "computerListView";
            this.computerListView.Size = new System.Drawing.Size(572, 466);
            this.computerListView.TabIndex = 0;
            this.computerListView.UseCompatibleStateImageBehavior = false;
            this.computerListView.DoubleClick += new System.EventHandler(this.computerList_DoubleClick);
            this.computerListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.computerList_KeyDown);
            // 
            // computerIcon
            // 
            this.computerIcon.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.computerIcon.ImageSize = new System.Drawing.Size(32, 32);
            this.computerIcon.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // startAll
            // 
            this.startAll.BackColor = System.Drawing.Color.White;
            this.startAll.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.startAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.startAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.startAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startAll.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startAll.Location = new System.Drawing.Point(12, 12);
            this.startAll.Name = "startAll";
            this.startAll.Size = new System.Drawing.Size(126, 38);
            this.startAll.TabIndex = 1;
            this.startAll.Text = "Zapnout vše";
            this.startAll.UseVisualStyleBackColor = false;
            this.startAll.Click += new System.EventHandler(this.startAll_Click);
            // 
            // stopAll
            // 
            this.stopAll.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.stopAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.stopAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.stopAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopAll.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.stopAll.Location = new System.Drawing.Point(12, 56);
            this.stopAll.Name = "stopAll";
            this.stopAll.Size = new System.Drawing.Size(126, 38);
            this.stopAll.TabIndex = 2;
            this.stopAll.Text = "Vypnout vše";
            this.stopAll.UseVisualStyleBackColor = true;
            this.stopAll.Click += new System.EventHandler(this.stopAll_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkLabel1.Location = new System.Drawing.Point(8, 457);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(120, 21);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Správa počítačů";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // ComputerViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(738, 501);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.stopAll);
            this.Controls.Add(this.startAll);
            this.Controls.Add(this.computerListView);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.MaximizeBox = false;
            this.Name = "ComputerViewForm";
            this.Text = "Ovládání počítačů v učebně";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView computerListView;
        private System.Windows.Forms.ImageList computerIcon;
        private System.Windows.Forms.Button startAll;
        private System.Windows.Forms.Button stopAll;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

