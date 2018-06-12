using System.Windows;
using System.Windows.Controls;
using IsButik.Modules;
using System.IO;
using System.Reflection;

namespace IsButik
{
    public partial class MainWindow : Window
    {
        string data;
        public MainWindow()
        {
            InitializeComponent();
            UpdateValues();
        }

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
                    Values.containers.Add(line);
                }
            }

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

            #endregion

        }

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
            }
            else if (CB_Containers.SelectedIndex == 1)
            {
                CB_Scoops.ItemsSource = Values.scoops_SmallCone;
            }
            else if (CB_Containers.SelectedIndex == 2)
            {
                CB_Scoops.ItemsSource = Values.scoops_MediumCone;
            }
            else if (CB_Containers.SelectedIndex == 3)
            {
                CB_Scoops.ItemsSource = Values.scoops_BigCone;
            }
        }

        private void RB_Gelato_Checked(object sender, RoutedEventArgs e)
        {
            // Checks if a container has been chosen, if not don't enable scoops combobox
            if (CB_Containers.SelectedIndex != -1)
            {
                CB_Scoops.IsEnabled = true;
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
        }
    }
}
