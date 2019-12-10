using PCControlApp.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Media;

namespace PCControlApp
{
    /// <summary>
    /// Interakční logika pro PcViewerForm.xaml
    /// </summary>
    public partial class PcViewerForm : Window
    {
        /// <summary>
        /// Represents the number of columns in the button grid.
        /// </summary>
        private const int ColumnsTotal = 4;

        /// <summary>
        /// Represents the smallest number of rows in the button grid.
        /// </summary>
        private const int RowsMinimum = 7;

        /// <summary>
        /// The set of dynamic _buttons in the button grid.
        /// </summary>
        private readonly List<Button> _buttons = new List<Button>();

        /// <summary>
        /// The set of _computers.
        /// </summary>
        private readonly List<ComputerModel> _computers = new List<ComputerModel>();


        public PcViewerForm()
        {
            InitializeComponent();

            try
            {
                List<string[]> listOfComputers = Utility.GetSetting();

                var rows = listOfComputers.Count / ColumnsTotal;
                var totalRows = listOfComputers.Count % ColumnsTotal != 0 ? rows + 1 : rows;

                if (totalRows < RowsMinimum)
                    totalRows = RowsMinimum;

                for (var i = 0; i < totalRows; i++)
                    ButtonGrid.RowDefinitions.Add(new RowDefinition());

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

            for (var i = 0; i < ColumnsTotal; i++)
                ButtonGrid.ColumnDefinitions.Add(new ColumnDefinition());

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
            var buttonRowColumn = buttonId + 1; // To calculate particular column and row for the button.
            var column = (buttonRowColumn % ColumnsTotal) - 1;
            var row = buttonRowColumn / 4;

            if (column == -1)
            {
                column = 3;
                row--;
            }


            _buttons.Add(new Button
            {
                Content = buttonRowColumn.ToString()
            });

            _buttons[buttonId].Click += (s, e) => // Event to start computer.
            {
                if (s is Button btn)
                {
                    var content = Int32.Parse(btn.Content.ToString());

                    _computers[buttonId].Start();
                    DisableButton(btn);
                    SetComputerStatus(content);
                }
            };

            Grid.SetColumn(_buttons[buttonId], column);
            Grid.SetRow(_buttons[buttonId], row);

            ButtonGrid.Children.Add(_buttons[buttonId]);

        }

        private async void SetComputerStatus(int computer)
        {
            Button btn = _buttons[computer];

            if (await _computers[computer].IsRunning())
                Dispatcher.Invoke((Action)(() => btn.Background = Brushes.Green));
            else
                Dispatcher.Invoke((Action)(() => btn.ClearValue(Button.BackgroundProperty)));
        }

        private async void DisableButton(Button btn)
        {
            btn.IsEnabled = false;
            await Task.Delay(3000);
            btn.IsEnabled = true;
        }

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

        private void SetTimer()
        {
            Timer aTimer = new Timer
            {
                Interval = 60000,
                AutoReset = true,
                Enabled = true
            };
            aTimer.Elapsed += (s, e) => CheckComputersStatus();
        }

        private void CheckComputersStatus() 
        {
            for (var i = 0; i < _computers.Count; i++) 
                SetComputerStatus(i);
        }
    }
}
