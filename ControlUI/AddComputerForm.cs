using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlLibrary;

namespace ControlUI
{
    public partial class AddComputerForm : Form
    {
        public AddComputerForm()
        {
            InitializeComponent();
            WireUpLists();
        }

        private void WireUpLists()
        {
            computersListBox.DataSource = GlobalConfig.Connections.GetComputers_All();
            computersListBox.DisplayMember = "ComputerName";
        }

        private void addComputerButton_Click(object sender, EventArgs e)
        {
            if(ValidateForm())
            {
                ComputerModel c = new ComputerModel(hostInput.Text, macAddressInput.Text)
                {
                    Name = nameInput.Text
                };

                GlobalConfig.Connections.AddComputer(c);

                hostInput.Text = "";
                macAddressInput.Text = "";
                nameInput.Text = "";
                WireUpLists();
            }
            else
            {
                MessageBox.Show("Musíš vyplnit všechna pole a zadat MAC adresu ve správném tvaru.");
            }
        }

        private bool ValidateForm()
        {
            if(hostInput.Text.Length == 0)
            {
                return false;
            }
            if (macAddressInput.Text.Length == 0 || !macAddressInput.Text.IsMacAddress())
            {
                return false;
            }
            if (nameInput.Text.Length == 0)
            {
                return false;
            }
            return true;
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
    }
}
