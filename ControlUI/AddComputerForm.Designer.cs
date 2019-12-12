namespace ControlUI
{
    partial class AddComputerForm
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
            this.addComputerButton = new System.Windows.Forms.Button();
            this.computersListBox = new System.Windows.Forms.ListBox();
            this.removeComputer = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameInput = new System.Windows.Forms.TextBox();
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
            this.hostLabel.Location = new System.Drawing.Point(12, 123);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(56, 30);
            this.hostLabel.TabIndex = 1;
            this.hostLabel.Text = "Host";
            // 
            // hostInput
            // 
            this.hostInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hostInput.Location = new System.Drawing.Point(188, 123);
            this.hostInput.Name = "hostInput";
            this.hostInput.Size = new System.Drawing.Size(249, 35);
            this.hostInput.TabIndex = 2;
            // 
            // macAddressInput
            // 
            this.macAddressInput.Location = new System.Drawing.Point(188, 74);
            this.macAddressInput.Name = "macAddressInput";
            this.macAddressInput.Size = new System.Drawing.Size(249, 35);
            this.macAddressInput.TabIndex = 3;
            // 
            // addComputerButton
            // 
            this.addComputerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.addComputerButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.addComputerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.addComputerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.addComputerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addComputerButton.Location = new System.Drawing.Point(126, 183);
            this.addComputerButton.Name = "addComputerButton";
            this.addComputerButton.Size = new System.Drawing.Size(207, 41);
            this.addComputerButton.TabIndex = 4;
            this.addComputerButton.Text = "Přidat počítač";
            this.addComputerButton.UseVisualStyleBackColor = true;
            this.addComputerButton.Click += new System.EventHandler(this.addComputerButton_Click);
            // 
            // computersListBox
            // 
            this.computersListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.computersListBox.FormattingEnabled = true;
            this.computersListBox.ItemHeight = 30;
            this.computersListBox.Location = new System.Drawing.Point(17, 271);
            this.computersListBox.Name = "computersListBox";
            this.computersListBox.Size = new System.Drawing.Size(420, 392);
            this.computersListBox.TabIndex = 5;
            // 
            // removeComputer
            // 
            this.removeComputer.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.removeComputer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.removeComputer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.removeComputer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeComputer.Location = new System.Drawing.Point(126, 687);
            this.removeComputer.Name = "removeComputer";
            this.removeComputer.Size = new System.Drawing.Size(207, 41);
            this.removeComputer.TabIndex = 6;
            this.removeComputer.Text = "Odstranit počítač";
            this.removeComputer.UseVisualStyleBackColor = true;
            this.removeComputer.Click += new System.EventHandler(this.removeComputer_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 30);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(162, 30);
            this.nameLabel.TabIndex = 7;
            this.nameLabel.Text = "Název v aplikaci";
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(188, 30);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(249, 35);
            this.nameInput.TabIndex = 8;
            // 
            // AddComputerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(449, 755);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.removeComputer);
            this.Controls.Add(this.computersListBox);
            this.Controls.Add(this.addComputerButton);
            this.Controls.Add(this.macAddressInput);
            this.Controls.Add(this.hostInput);
            this.Controls.Add(this.hostLabel);
            this.Controls.Add(this.macAddressLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "AddComputerForm";
            this.Text = "Přidat počítač";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label macAddressLabel;
        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.TextBox hostInput;
        private System.Windows.Forms.TextBox macAddressInput;
        private System.Windows.Forms.Button addComputerButton;
        private System.Windows.Forms.ListBox computersListBox;
        private System.Windows.Forms.Button removeComputer;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameInput;
    }
}