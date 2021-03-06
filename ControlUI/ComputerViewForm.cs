﻿using ControlLibrary;
using ControlLibrary.Exceptions;
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
        delegate void SetListViewCallback(int itemIntList, int num);

        public ComputerViewForm()
        {
            InitializeComponent();
            WireUpListView();
            WireUpImageList();
            SetTimer();
        }

        private async void computerList_DoubleClick(object sender, EventArgs e)
        {
            if (sender is ListView item && item.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = item.SelectedItems[0];
                await ChangeComputerStateAsync(selectedItem);
            }
        }

        private async void computerList_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is ListView item && e.KeyCode == Keys.Enter && item.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = item.SelectedItems[0];
                await ChangeComputerStateAsync(selectedItem);
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

        private async void startAll_Click(object sender, EventArgs e)
        {
            DisableMainButtons();

            foreach (ComputerModel computer in computers)
            {
                computer.Start();
            }

            await EnableButtonsAsync(false);
        }

        private async void stopAll_Click(object sender, EventArgs e)
        {
            DisableMainButtons();

            foreach (ComputerModel computer in computers)
            {
                try
                {
                    computer.Shutdown();
                }
                catch (ComputerServiceException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            await EnableButtonsAsync(false);
        }

        private async Task EnableButtonsAsync(bool computerStarting)
        {
            for (var i = 0; i < 15; i++)
            {
                if ((await CheckComputersStateAsync()) == computerStarting)
                {
                    break;
                }
                await Task.Delay(250);
            }

            DisableMainButtons(false);
        }

        private async Task<bool> CheckComputersStateAsync()
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
            Task.Run(() => UpdateListViewComputersAsync().Wait());
        }

        private void WireUpImageList()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            computerIcon.Images.Add(Image.FromFile($"{ path }\\res\\icon_offline.png"));
            computerIcon.Images.Add(Image.FromFile($"{ path }\\res\\icon_online.png"));
        }

        private async Task UpdateListViewComputersAsync()
        {
            for (var i = 0; i < computers.Count; i++)
            {
                await SetListViewComputerStateAsync(i);
            }
        }

        private async Task SetListViewComputerStateAsync(int itemInList)
        {
            if (await computers[itemInList].IsRunning())
            {
                SetImage(itemInList, 1);
            }
            else
            {
                SetImage(itemInList, 0);
            }
        }

        private void SetImage(int itemInList, int imgId)
        {
            if (computerListView.InvokeRequired)
            {
                SetListViewCallback d = new SetListViewCallback(SetImage);
                Invoke(d, new object[] { itemInList, imgId });
                return;
            }
            computerListView.Items[itemInList].ImageIndex = imgId;
        }

        private async Task ChangeComputerStateAsync(ListViewItem selectedComputer)
        {
            int index = selectedComputer.Index;

            selectedComputer.Selected = false;

            if (await computers[index].IsRunning())
            {
                selectedComputer.ImageIndex = 0;
                try
                {
                    computers[index].Shutdown();
                }
                catch (ComputerServiceException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                selectedComputer.ImageIndex = 1;
                computers[index].Start();
            }
            await SetListViewComputerStateAsync(index);
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
                Interval = 10000,
                Enabled = true
            };
            aTimer.Tick += (s, e) => Task.Run(() => UpdateListViewComputersAsync().Wait());
        }

    }
}
