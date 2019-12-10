using ControlLibrary;
using ControlUI.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace ControlUI
{
    public partial class ComputerViewForm : Form
    {
        /// <summary>
        /// The set of _computers.
        /// </summary>
        private readonly List<ComputerModel> _computers = new List<ComputerModel>();


        public ComputerViewForm()
        {
            InitializeComponent();

            computerIcon.Images.Add(Image.FromFile("C:\\Users\\onova\\source\\repos\\PCControlApp\\icon.png"));
            computerIcon.Images.Add(Image.FromFile("C:\\Users\\onova\\source\\repos\\PCControlApp\\icon2.png"));
            computerIcon.Images.Add(Image.FromFile("C:\\Users\\onova\\source\\repos\\PCControlApp\\icon3.png"));

            try
            {
                List<string[]> listOfComputers = Utility.GetSetting();

                InitComputers(listOfComputers);

            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
            catch (InvalidDataException e)
            {
                MessageBox.Show(e.Message);
                throw;
            }

            CheckComputersStatus();
            SetTimer();

        }

        private void InitComputers(List<string[]> listOfComputers)
        {
            var i = 0;

            listOfComputers.ForEach(delegate (string[] line)
            {
                if (line.Length != 2)
                    MessageBox.Show($"There is something wrong with file _computers.txt on line {i + 1}.");

                try
                {
                    _computers.Add(new ComputerModel(line[0], line[1]));
                    CreateButton(i);
                }
                catch (ArgumentException)
                {
                    MessageBox.Show($"MAC address on line {i + 1} is invalid.");
                    throw;
                }

                ++i;
            });
        }

        private void CreateButton(int buttonId)
        {           
            var lvi = new ListViewItem((buttonId + 1).ToString())
            {
                ImageIndex = 0,
                Tag = buttonId.ToString()
            };

            computerList.Items.Add(lvi);
        }

         private async void SetComputerStatus(ComputerModel computer, int itemInList)
         {
             if (await computer.IsRunning())
                 computerList.Items[itemInList].ImageIndex = 2;
             else
                 computerList.Items[itemInList].ImageIndex = 0;
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
         private void SetTimer()
         {
             Timer aTimer = new Timer
             {
                 Interval = 60000,
                 Enabled = true
             };
             aTimer.Tick += (s, e) => CheckComputersStatus();
         }
         
         private void CheckComputersStatus()
         {
             for (var i = 0; i < _computers.Count; i++)
                 SetComputerStatus(_computers[i], i);
         }

        private void SetComputer(ListViewItem selectedComputer)
        {
            var content = Int32.Parse(selectedComputer.Tag.ToString());
            selectedComputer.Selected = false;
            selectedComputer.ImageIndex = 0;

            if (!_computers[content].isStarting)
            {
                _computers[content].Start();
            }

            SetComputerStatus(_computers[content], content);
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
    }
}
