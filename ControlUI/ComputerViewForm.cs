using ControlLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ControlUI
{
    public partial class ComputerViewForm : Form
    {
        /// <summary>
        /// The set of computers.
        /// </summary>
        private readonly List<ComputerModel> computers = GlobalConfig.Connections.GetComputers_All();

        public ComputerViewForm()
        {
            InitializeComponent();

            computerIcon.Images.Add(Image.FromFile("C:\\Users\\onova\\source\\repos\\PCControlApp\\icon.png"));
            computerIcon.Images.Add(Image.FromFile("C:\\Users\\onova\\source\\repos\\PCControlApp\\icon2.png"));
            computerIcon.Images.Add(Image.FromFile("C:\\Users\\onova\\source\\repos\\PCControlApp\\icon3.png"));

            WireUpListView();
            CheckComputersStatus();
            SetTimer();
        }

        private void WireUpListView()
        {
            foreach (ComputerModel computer in computers)
            {
                var lvi = new ListViewItem()
                {
                    Text = computer.Name,
                    ImageIndex = 0,
                    Tag = computer.Id.ToString()
                };

                computerListView.Items.Add(lvi);
            }
        }

        private async void SetComputerStatus(int itemInList)
        {
            if (await computers[itemInList].IsRunning())
            {
                computerListView.Items[itemInList].ImageIndex = 2;
            }
            else
            {
                computerListView.Items[itemInList].ImageIndex = 0;
            }
        }

        private void CheckComputersStatus()
        {
            for (var i = 0; i < computers.Count; i++)
            {
                SetComputerStatus(i);
            }
        }

        private void SetComputer(ListViewItem selectedComputer)
        {
            var content = Int32.Parse(selectedComputer.Tag.ToString());

            selectedComputer.Selected = false;
            selectedComputer.ImageIndex = 0;

            if (!computers[content].IsStarting)
            {
                computers[content].Start();
            }

            SetComputerStatus(content);
        }

        private void computerList_DoubleClick(object sender, EventArgs e)
        {
            if (sender is ListView item)
            {
                ListViewItem selectedItem = item.SelectedItems[0];
                SetComputer(selectedItem);
            }
        }

        private void computerList_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is ListView item && e.KeyCode == Keys.Enter)
            {
                ListViewItem selectedItem = item.SelectedItems[0];
                SetComputer(selectedItem);
            }
        }

        private void SetTimer()
        {
            Timer aTimer = new Timer
            {
                Interval = 60000,
                Enabled = true
            };
            aTimer.Tick += (s, e) => CheckComputersStatus();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddComputerForm addComputerForm = new AddComputerForm();

            addComputerForm.Show();
        }

        /*
         private void DisableAllButtons()
         {
             EnableMainButtons(false);

             for (var i = 0; i < _buttons.Count; i++)
             {
                 _buttons[i].IsEnabled = false;
             }
         }

         private void EnableAllButtons()
         {
             EnableMainButtons(true);

             for (var i = 0; i < _buttons.Count; i++)
             {
                 _buttons[i].IsEnabled = true;
             }
         }

         private void EnableMainButtons(bool enabled)
         {
             startAll.IsEnabled = enabled;
             stopAll.IsEnabled = enabled;
             teacherComputer.IsEnabled = enabled;
         }
         */
    }
}
