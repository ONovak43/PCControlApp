namespace ControlUI
{
    partial class AddComputer
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
            this.macAddressLabel = new System.Windows.Forms.Label();
            this.hostLabel = new System.Windows.Forms.Label();
            this.hostInput = new System.Windows.Forms.TextBox();
            this.macAddressInput = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // macAddressLabel
            // 
            this.macAddressLabel.AutoSize = true;
            this.macAddressLabel.Location = new System.Drawing.Point(12, 74);
            this.macAddressLabel.Name = "macAddressLabel";
            this.macAddressLabel.Size = new System.Drawing.Size(126, 30);
            this.macAddressLabel.TabIndex = 0;
            this.macAddressLabel.Text = "MAC adresa";
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.Location = new System.Drawing.Point(12, 28);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(56, 30);
            this.hostLabel.TabIndex = 1;
            this.hostLabel.Text = "Host";
            // 
            // hostInput
            // 
            this.hostInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hostInput.Location = new System.Drawing.Point(159, 28);
            this.hostInput.Name = "hostInput";
            this.hostInput.Size = new System.Drawing.Size(233, 35);
            this.hostInput.TabIndex = 2;
            // 
            // macAddressInput
            // 
            this.macAddressInput.Location = new System.Drawing.Point(159, 74);
            this.macAddressInput.Name = "macAddressInput";
            this.macAddressInput.Size = new System.Drawing.Size(233, 35);
            this.macAddressInput.TabIndex = 3;
            // 
            // addButton
            // 
            this.addButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.addButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.addButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.addButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Location = new System.Drawing.Point(111, 133);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(207, 41);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Přidat počítač";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // AddComputer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(416, 186);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.macAddressInput);
            this.Controls.Add(this.hostInput);
            this.Controls.Add(this.hostLabel);
            this.Controls.Add(this.macAddressLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "AddComputer";
            this.Text = "Přidat počítač";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label macAddressLabel;
        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.TextBox hostInput;
        private System.Windows.Forms.TextBox macAddressInput;
        private System.Windows.Forms.Button addButton;
    }
}