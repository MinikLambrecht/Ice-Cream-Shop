using System.Windows;
using System.Windows.Controls;
using IsButik.Modules;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;

namespace IsButik
{
    public partial class MainWindow : Window
    {
        #region Variables

        List<string> containerPrices = new List<string>();

        private float totalSprinklePrice;

        #endregion

        // Constructor
        public MainWindow()
        {
            InitializeComponent();

            // Initialize UpdateValues Method to update data to program
            UpdateValues();
            CreateDirectories();
        }

        #region Methods

        private void UpdateValues()
        {

            #region Containers

            // Add data from resources to lists
            CB_Containers.ItemsSource = Values.containers;

            // Get directory root
            var assemblyContainers = Assembly.GetExecutingAssembly();
            // Define filename and path
            var resourceNameContainers = "IsButik.Files.Containers.txt";

            // Use streamreader to find file and add data to list
            using (Stream stream = assemblyContainers.GetManifestResourceStream(resourceNameContainers))
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] lines = Regex.Split(line, ",");
                    Values.containers.Add(lines[0]);
                    containerPrices.Add(lines[1]);
                }
            }

            CB_Containers.SelectedIndex = 0;

            #endregion

            #region Scoops

            #region Cup

            // Get directory root
            var assemblyScoopsCup = Assembly.GetExecutingAssembly();
            // Define filename and path
            var resourceNameScoopsCup = "IsButik.Files.Cup.txt";

            // Use streamreader to find file and add data to list
            using (Stream stream = assemblyScoopsCup.GetManifestResourceStream(resourceNameScoopsCup))
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Values.scoops_Cup.Add(line);
                }
            }

            CB_Scoops.SelectedIndex = 0;

            #endregion

            #region Small Cone

            // Get directory root
            var assemblyScoopsSmallCone = Assembly.GetExecutingAssembly();
            // Define filename and path
            var resourceNameScoopsSmallCone = "IsButik.Files.SmallCone.txt";

            // Use streamreader to find file and add data to list
            using (Stream stream = assemblyScoopsSmallCone.GetManifestResourceStream(resourceNameScoopsSmallCone))
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Values.scoops_SmallCone.Add(line);
                }
            }

            CB_Scoops.SelectedIndex = 0;

            #endregion

            #region Medium Cone

            // Get directory root
            var assemblyScoopsMediumCone = Assembly.GetExecutingAssembly();
            // Define filename and path
            var resourceNameScoopsMediumCone = "IsButik.Files.MediumCone.txt";

            // Use streamreader to find file and add data to list
            using (Stream stream = assemblyScoopsMediumCone.GetManifestResourceStream(resourceNameScoopsMediumCone))
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Values.scoops_MediumCone.Add(line);
                }
            }

            CB_Scoops.SelectedIndex = 0;

            #endregion

            #region Big Cone

            // Get directory root
            var assemblyScoopsBigCone = Assembly.GetExecutingAssembly();
            // Define filename and path
            var resourceNameScoopsBigCone = "IsButik.Files.BigCone.txt";

            // Use streamreader to find file and add data to list
            using (Stream stream = assemblyScoopsBigCone.GetManifestResourceStream(resourceNameScoopsBigCone))
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Values.scoops_BigCone.Add(line);
                }
            }

            CB_Scoops.SelectedIndex = 0;

            #endregion

            #endregion

            #region Sprinkles

            // Add data from resources to lists
            CB_Sprinkles_1.ItemsSource = Values.sprinkles;
            CB_Sprinkles_2.ItemsSource = Values.sprinkles;
            CB_Sprinkles_3.ItemsSource = Values.sprinkles;

            // Get directory root
            var assemblySprinkles = Assembly.GetExecutingAssembly();
            // Define filename and path
            var resourceNameSprinkles = "IsButik.Files.Sprinkles.txt";

            // Use streamreader to find file and add data to list
            using (Stream stream = assemblySprinkles.GetManifestResourceStream(resourceNameSprinkles))
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Values.sprinkles.Add(line);
                }
            }

            CB_Sprinkles_1.SelectedIndex = 0;
            CB_Sprinkles_2.SelectedIndex = 0;
            CB_Sprinkles_3.SelectedIndex = 0;

            #endregion

        }

        private void CreateDirectories()
        {
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string rootDirectory = Path.Combine(appdata, "IceCreamShop");
            string subDir = Path.Combine(rootDirectory, "Settings");

            // If directory does not exist, create it. 
            if (!Directory.Exists(rootDirectory))
            {
                Directory.CreateDirectory(rootDirectory);
            }

            if (!Directory.Exists(subDir))
            {
                Directory.CreateDirectory(subDir);
            }
        }

        #endregion

        #region Events

        private void CB_Containers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Check if gelato is checked, if not don't enable scoops Combobox
            if (RB_Gelato.IsChecked == true)
            {
                CB_Scoops.IsEnabled = true;
            }
            else
            {
                CB_Scoops.IsEnabled = false;
            }

            // Checks what index containers is at to match scoops limit
            if (CB_Containers.SelectedIndex == 0)
            {
                CB_Scoops.ItemsSource = Values.scoops_Cup;
                CB_Scoops.SelectedIndex = 0;
                txt_Containers.Content = "containers: " + containerPrices[0];
            }
            else if (CB_Containers.SelectedIndex == 1)
            {
                CB_Scoops.ItemsSource = Values.scoops_SmallCone;
                CB_Scoops.SelectedIndex = 0;
                txt_Containers.Content = "containers: " + containerPrices[1];
            }
            else if (CB_Containers.SelectedIndex == 2)
            {
                CB_Scoops.ItemsSource = Values.scoops_MediumCone;
                CB_Scoops.SelectedIndex = 0;
                txt_Containers.Content = "containers: " + containerPrices[2];
            }
            else if (CB_Containers.SelectedIndex == 3)
            {
                CB_Scoops.ItemsSource = Values.scoops_BigCone;
                CB_Scoops.SelectedIndex = 0;
                txt_Containers.Content = "containers: " + containerPrices[3];
            }
        }

        private void RB_Gelato_Checked(object sender, RoutedEventArgs e)
        {
            // Checks if a container has been chosen, if not don't enable scoops combobox
            if (CB_Containers.SelectedIndex != -1)
            {
                CB_Scoops.IsEnabled = true;
                tab_Gelato.IsEnabled = true;
                tab_Softice.IsEnabled = false;

                tab_Gelato.Visibility = Visibility.Visible;
                tab_Softice.Visibility = Visibility.Hidden;
                TabCtrl.SelectedIndex = 0;
            }
            else
            {
                CB_Scoops.IsEnabled = false;
            }
        }

        private void RB_Softice_Checked(object sender, RoutedEventArgs e)
        {
            // If softice is checked don't enable scoops combobox
            CB_Scoops.IsEnabled = false;
            tab_Softice.IsEnabled = true;
            tab_Gelato.IsEnabled = false;

            tab_Gelato.Visibility = Visibility.Hidden;
            tab_Softice.Visibility = Visibility.Visible;
            TabCtrl.SelectedIndex = 1;
        }

        private void RB_SN0_Checked(object sender, RoutedEventArgs e)
        {
            CB_Sprinkles_1.Visibility = Visibility.Hidden;
            CB_Sprinkles_2.Visibility = Visibility.Hidden;
            CB_Sprinkles_3.Visibility = Visibility.Hidden;

            totalSprinklePrice = 0f;
            txt_Sprinkles.Content = "Sprinkle(s): " + totalSprinklePrice + "$";
        }

        private void RB_SN1_Checked(object sender, RoutedEventArgs e)
        {
            CB_Sprinkles_1.Visibility = Visibility.Visible;
            CB_Sprinkles_2.Visibility = Visibility.Hidden;
            CB_Sprinkles_3.Visibility = Visibility.Hidden;

            totalSprinklePrice = 1.50f;
            txt_Sprinkles.Content = "Sprinkle(s): " + totalSprinklePrice + "$";
        }

        private void RB_SN2_Checked(object sender, RoutedEventArgs e)
        {
            CB_Sprinkles_1.Visibility = Visibility.Visible;
            CB_Sprinkles_2.Visibility = Visibility.Visible;
            CB_Sprinkles_3.Visibility = Visibility.Hidden;

            totalSprinklePrice = 3f;
            txt_Sprinkles.Content = "Sprinkle(s): " + totalSprinklePrice + "$";
        }

        private void RB_SN3_Checked(object sender, RoutedEventArgs e)
        {
            CB_Sprinkles_1.Visibility = Visibility.Visible;
            CB_Sprinkles_2.Visibility = Visibility.Visible;
            CB_Sprinkles_3.Visibility = Visibility.Visible;

            totalSprinklePrice = 4.50f;
            txt_Sprinkles.Content = "Sprinkle(s): " + totalSprinklePrice + "$";
        }

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
