using ControlLibrary;
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

        private void WireUpLists()
        {
            computersListBox.DataSource = GlobalConfig.Connections.GetComputers_All();
            computersListBox.DisplayMember = "ComputerName";
        }

        private void addComputerButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                ComputerModel c = new ComputerModel(hostInput.Text, macAddressInput.Text)
                {
                    Name = nameInput.Text
                };

                GlobalConfig.Connections.AddComputer(c);

                nameInput.Text = "";
                hostInput.Text = "";
                macAddressInput.Text = "";                

                WireUpLists();
            }
            else
            {
                MessageBox.Show("Musíš vyplnit všechna pole a zadat MAC adresu ve správném tvaru.");
            }
        }

        private bool ValidateForm()
        {
            if (nameInput.Text.Length == 0)
            {
                return false;
            }
            if (macAddressInput.Text.Length == 0 || !macAddressInput.Text.IsMacAddress())
            {
                return false;
            }
            if (hostInput.Text.Length == 0)
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ComputerModel c = (ComputerModel)computersListBox.Items[_selectedContextMenuItem];
     
            Clipboard.SetText($"{ c.Name }: { c.Domain }, { c.MacAddress }");
        }

        private void computersListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && computersListBox.IndexFromPoint(e.Location) != ListBox.NoMatches)
            {
                _selectedContextMenuItem = computersListBox.IndexFromPoint(e.Location);
                computerContextMenu.Show(Cursor.Position);                
            }
        }
    }
}
