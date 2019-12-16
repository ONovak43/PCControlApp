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
            this.components = new System.ComponentModel.Container();
            this.nameLabel = new System.Windows.Forms.Label();
            this.hostInput = new System.Windows.Forms.TextBox();
            this.hostLabel = new System.Windows.Forms.Label();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.macAddressLabel = new System.Windows.Forms.Label();
            this.macAddressInput = new System.Windows.Forms.TextBox();
            this.addComputerButton = new System.Windows.Forms.Button();
            this.computersListBox = new System.Windows.Forms.ListBox();
            this.removeComputer = new System.Windows.Forms.Button();
            this.computerContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyComputerContextMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.computerContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nameLabel.Location = new System.Drawing.Point(12, 18);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(64, 25);
            this.nameLabel.TabIndex = 6;
            this.nameLabel.Text = "Název";
            // 
            // hostInput
            // 
            this.hostInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hostInput.Location = new System.Drawing.Point(139, 53);
            this.hostInput.MaxLength = 255;
            this.hostInput.Name = "hostInput";
            this.hostInput.Size = new System.Drawing.Size(204, 35);
            this.hostInput.TabIndex = 1;
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hostLabel.Location = new System.Drawing.Point(12, 59);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(50, 25);
            this.hostLabel.TabIndex = 7;
            this.hostLabel.Text = "Host";
            // 
            // nameInput
            // 
            this.nameInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameInput.Location = new System.Drawing.Point(139, 12);
            this.nameInput.MaxLength = 20;
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(204, 35);
            this.nameInput.TabIndex = 0;
            // 
            // macAddressLabel
            // 
            this.macAddressLabel.AutoSize = true;
            this.macAddressLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.macAddressLabel.Location = new System.Drawing.Point(12, 101);
            this.macAddressLabel.Name = "macAddressLabel";
            this.macAddressLabel.Size = new System.Drawing.Size(114, 25);
            this.macAddressLabel.TabIndex = 8;
            this.macAddressLabel.Text = "MAC adresa";
            // 
            // macAddressInput
            // 
            this.macAddressInput.Location = new System.Drawing.Point(139, 94);
            this.macAddressInput.MaxLength = 17;
            this.macAddressInput.Name = "macAddressInput";
            this.macAddressInput.Size = new System.Drawing.Size(204, 35);
            this.macAddressInput.TabIndex = 2;
            // 
            // addComputerButton
            // 
            this.addComputerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.addComputerButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.addComputerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.addComputerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.addComputerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addComputerButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addComputerButton.Location = new System.Drawing.Point(190, 141);
            this.addComputerButton.Name = "addComputerButton";
            this.addComputerButton.Size = new System.Drawing.Size(153, 41);
            this.addComputerButton.TabIndex = 3;
            this.addComputerButton.Text = "Přidat počítač";
            this.addComputerButton.UseVisualStyleBackColor = true;
            this.addComputerButton.Click += new System.EventHandler(this.addComputerButton_Click);
            // 
            // computersListBox
            // 
            this.computersListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.computersListBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.computersListBox.FormattingEnabled = true;
            this.computersListBox.ItemHeight = 21;
            this.computersListBox.Location = new System.Drawing.Point(364, 12);
            this.computersListBox.Name = "computersListBox";
            this.computersListBox.Size = new System.Drawing.Size(375, 170);
            this.computersListBox.TabIndex = 4;
            this.computersListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.computersListBox_MouseDown);
            // 
            // removeComputer
            // 
            this.removeComputer.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.removeComputer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.removeComputer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.removeComputer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeComputer.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.removeComputer.Location = new System.Drawing.Point(745, 12);
            this.removeComputer.Name = "removeComputer";
            this.removeComputer.Size = new System.Drawing.Size(114, 74);
            this.removeComputer.TabIndex = 5;
            this.removeComputer.Text = "Odstranit počítač";
            this.removeComputer.UseVisualStyleBackColor = true;
            this.removeComputer.Click += new System.EventHandler(this.removeComputer_Click);
            // 
            // computerContextMenu
            // 
            this.computerContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyComputerContextMenu});
            this.computerContextMenu.Name = "contextMenuStrip1";
            this.computerContextMenu.Size = new System.Drawing.Size(126, 26);
            this.computerContextMenu.Text = "Kopírovat MAC adresu";
            // 
            // copyComputerContextMenu
            // 
            this.copyComputerContextMenu.Name = "copyComputerContextMenu";
            this.copyComputerContextMenu.Size = new System.Drawing.Size(180, 22);
            this.copyComputerContextMenu.Text = "Kopírovat";
            this.copyComputerContextMenu.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // AddComputerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(866, 204);
            this.Controls.Add(this.hostInput);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.removeComputer);
            this.Controls.Add(this.computersListBox);
            this.Controls.Add(this.addComputerButton);
            this.Controls.Add(this.macAddressInput);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.hostLabel);
            this.Controls.Add(this.macAddressLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "AddComputerForm";
            this.Text = "Přidat počítač";
            this.computerContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label macAddressLabel;
        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.TextBox macAddressInput;
        private System.Windows.Forms.Button addComputerButton;
        private System.Windows.Forms.ListBox computersListBox;
        private System.Windows.Forms.Button removeComputer;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox hostInput;
        private System.Windows.Forms.ContextMenuStrip computerContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyComputerContextMenu;
    }
}