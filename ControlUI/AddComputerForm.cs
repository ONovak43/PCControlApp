﻿using ControlLibrary;
using ControlLibrary.Wrapper;
using System;
using System.Windows.Forms;

namespace ControlUI
{
    public partial class AddComputerForm : Form
    {
        private int _selectedContextMenuItem;

        public AddComputerForm()
        {
            InitializeComponent();
            WireUpLists();
        }

        private void addComputerButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                MacAddress macAddress = new MacAddress(macAddressInput.Text);

                ComputerModel c = new ComputerModel(nameInput.Text, hostInput.Text, macAddress);

                GlobalConfig.Connections.AddComputer(c);

                nameInput.Text = "";
                hostInput.Text = "";
                macAddressInput.Text = "";

                WireUpLists();
            }
            else
            {
                MessageBox.Show("Zkontroluj, zda si vyplnil všechna pole, zadal MAC adresu ve správném tvaru a nepoužil v žádném vstupu čárku (,).");
            }
        }

        private void removeComputer_Click(object sender, EventArgs e)
        {
            ComputerModel c = (ComputerModel)computersListBox.SelectedItem;

            DialogResult dialogResult = MessageBox.Show($"Jste si jisti, že chcete odstranit počítač \"{ c.Name }\"?", $"Odstranění počítače { c.Name }", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes && c != null)
            {
                GlobalConfig.Connections.RemoveComputer(c);

                WireUpLists();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ComputerModel c = (ComputerModel)computersListBox.Items[_selectedContextMenuItem];

            Clipboard.SetText(c.ComputerName);
        }

        private void computersListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && computersListBox.IndexFromPoint(e.Location) != ListBox.NoMatches)
            {
                _selectedContextMenuItem = computersListBox.IndexFromPoint(e.Location);
                computerContextMenu.Show(Cursor.Position);
            }
        }

        private void WireUpLists()
        {
            computersListBox.DataSource = GlobalConfig.Connections.GetComputers_All();
            computersListBox.DisplayMember = "ComputerName";
        }

        private bool ValidateForm()
        {
            try
            {
                MacAddress macAddress = new MacAddress(macAddressInput.Text);
            }
            catch (ArgumentException)
            {
                return false;
            }

            if (nameInput.Text.Length == 0 || hostInput.Text.Length == 0 || nameInput.Text.Contains(",") || hostInput.Text.Contains(","))
            {
                return false;
            }

            return true;
        }
    }
}
