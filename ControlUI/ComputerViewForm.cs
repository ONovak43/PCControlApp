﻿using ControlLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlUI
{
    public partial class ComputerViewForm : Form
    {
        /// <summary>
        /// Seznam počítačů.
        /// </summary>
        private List<ComputerModel> computers = GlobalConfig.Connections.GetComputers_All();

        public ComputerViewForm()
        {
            InitializeComponent();
            WireUpListView();
            WireUpImageList();
            SetTimer();
        }

        private void computerList_DoubleClick(object sender, EventArgs e)
        {
            if (sender is ListView item)
            {
                ListViewItem selectedItem = item.SelectedItems[0];
                ChangeComputerState(selectedItem);
            }
        }

        private void computerList_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is ListView item && e.KeyCode == Keys.Enter)
            {
                ListViewItem selectedItem = item.SelectedItems[0];
                ChangeComputerState(selectedItem);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddComputerForm addComputerForm = new AddComputerForm();

            addComputerForm.ShowDialog();
            computers = GlobalConfig.Connections.GetComputers_All();

            computerListView.Items.Clear();
            WireUpListView();
        }

        private void startAll_Click(object sender, EventArgs e)
        {
            DisableMainButtons();

            foreach (ComputerModel computer in computers)
            {
                computer.Start();
            }

            EnableButtons(false);
        }

        private void stopAll_Click(object sender, EventArgs e)
        {
            DisableMainButtons();

            foreach (ComputerModel computer in computers)
            {
                if (!computer.Shutdown())
                {
                    MessageBox.Show("Někde se vyskytla chyba. Nejspíše jsou špatně zadané přihlašovací údaje nebo host.");
                }
            }

            EnableButtons(false);
        }

        private async Task EnableButtons(bool computerStarting)
        {
            for (var i = 0; i < 15; i++)
            {
                if ((await CheckComputersState()) == computerStarting)
                {
                    break;
                }
                await Task.Delay(250);
            }

            DisableMainButtons(false);
        }

        private async Task<bool> CheckComputersState()
        {
            var allowEnable = false;

            foreach (ComputerModel computer in computers)
            {
                if (!(await computer.IsRunning()))
                {
                    allowEnable = true;
                    continue;
                }
                allowEnable = false;
            }

            return allowEnable;
        }

        private void WireUpListView()
        {
            foreach (ComputerModel computer in computers)
            {
                var lvi = new ListViewItem()
                {
                    Text = computer.Name,
                    ImageIndex = 0,
                };

                computerListView.Items.Add(lvi);
            }
            UpdateListViewComputers();
        }

        private void WireUpImageList()
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            computerIcon.Images.Add(Image.FromFile($"{ path }\\res\\icon_offline.png"));
            computerIcon.Images.Add(Image.FromFile($"{ path }\\res\\icon_online.png"));
        }

        private void UpdateListViewComputers()
        {
            for (var i = 0; i < computers.Count; i++)
            {
                SetListViewComputerState(i);
            }
        }

        private async Task SetListViewComputerState(int itemInList)
        {
            if (await computers[itemInList].IsRunning())
            {
                computerListView.Items[itemInList].ImageIndex = 2;
            }

            computerListView.Items[itemInList].ImageIndex = 0;
        }

        private async Task ChangeComputerState(ListViewItem selectedComputer)
        {
            int index = selectedComputer.Index;

            selectedComputer.Selected = false;
            selectedComputer.ImageIndex = 0;

            if (await computers[index].IsRunning())
            {
                if (!computers[index].Shutdown())
                {
                    MessageBox.Show("Někde se vyskytla chyba. Nejspíše jsou špatně zadané přihlašovací údaje nebo doména.");
                }
            }
            else
            {
                computers[index].Start();
            }

            SetListViewComputerState(index);
        }

        private void DisableMainButtons(bool disable = true)
        {
            startAll.Enabled = !disable;
            stopAll.Enabled = !disable;
            computerListView.Enabled = !disable;
        }

        private void SetTimer()
        {
            Timer aTimer = new Timer
            {
                Interval = 30000,
                Enabled = true
            };
            aTimer.Tick += (s, e) => UpdateListViewComputers();
        }
    }
}
