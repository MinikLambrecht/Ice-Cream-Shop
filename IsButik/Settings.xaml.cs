using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IsButik
{
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();

            // Initialize GetsavedSettings Method to load every saved setting
            GetSavedSettings();
        }

        #region Events

        private void RB_SaveLocally_Checked(object sender, RoutedEventArgs e)
        {
            // If checked change settings to be saved
            Properties.Settings.Default.saveLocally = true;
            Properties.Settings.Default.saveInDB = false;
        }

        private void RB_SaveInDB_Checked(object sender, RoutedEventArgs e)
        {
            // If checked change settings to be saved
            Properties.Settings.Default.saveLocally = false;
            Properties.Settings.Default.saveInDB = true;
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            // Saves the settings
            Properties.Settings.Default.Save();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Closes current window and opens the mainwindows again
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // If program unexpectedly shuts down or is closed by the x button, then save the settings before closing
            Properties.Settings.Default.Save();
        }

        #endregion

        #region Methods

        private void GetSavedSettings()
        {
            RB_SaveLocally.IsChecked = Properties.Settings.Default.saveLocally;
            RB_SaveInDB.IsChecked = Properties.Settings.Default.saveInDB;
        }

        #endregion

    }
}
