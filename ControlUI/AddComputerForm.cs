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
        }

        private void addComputerButton_Click(object sender, EventArgs e)
        {
            if(ValidateForm())
            {
                ComputerModel c = new ComputerModel(hostInput.Text, macAddressInput.Text);

                GlobalConfig.Connections.AddComputer(c);
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
            return true;
        }
    }
}
