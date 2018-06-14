using System.Windows;
using System.Windows.Controls;
using IsButik.Modules;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;
using System.Windows.Media;
using System.Windows.Input;

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
            // Initialize CreateDirectories Method to create needed directories if not created already 
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
                    // If the current line the streamreader is reading is not null then create a string array named lines and split teh string for each "," in the current string
                    string[] lines = Regex.Split(line, ",");
                    // Add the first string in the string array to the string list
                    Values.containers.Add(lines[0]);
                    // Add the second string in the string array to the other string list
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
                    // If the current line the streamreader is reading is not null then add the current line to the string list
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
                    // If the current line the streamreader is reading is not null then add the current line to the string list
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
                    // If the current line the streamreader is reading is not null then add the current line to the string list
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
                    // If the current line the streamreader is reading is not null then add the current line to the string list
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
                    // If the current line the streamreader is reading is not null then add the current line to the string list
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
            // Path to appdata folder
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            // Path to create root directory with
            string rootDirectory = Path.Combine(appdata, "IceCreamShop");
            // Path to create subdirectory with
            string subDir = Path.Combine(rootDirectory, "Settings");

            // If directory does not exist, create it. 
            if (!Directory.Exists(rootDirectory))
            {
                Directory.CreateDirectory(rootDirectory);
            }

            // If directory does not exist, create it. 
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
            // If checked this will make all radio buttons below invisible, change the totalSprinklePrice int and the txt_Sprinkles text
            CB_Sprinkles_1.Visibility = Visibility.Hidden;
            CB_Sprinkles_2.Visibility = Visibility.Hidden;
            CB_Sprinkles_3.Visibility = Visibility.Hidden;

            totalSprinklePrice = 0f;
            txt_Sprinkles.Content = "Sprinkle(s): " + totalSprinklePrice + "$";
        }

        private void RB_SN1_Checked(object sender, RoutedEventArgs e)
        {
            // If checked this will make the two last radio buttons below invisible, change the totalSprinklePrice int and the txt_Sprinkles text
            CB_Sprinkles_1.Visibility = Visibility.Visible;
            CB_Sprinkles_2.Visibility = Visibility.Hidden;
            CB_Sprinkles_3.Visibility = Visibility.Hidden;

            totalSprinklePrice = 1.50f;
            txt_Sprinkles.Content = "Sprinkle(s): " + totalSprinklePrice + "$";
        }

        private void RB_SN2_Checked(object sender, RoutedEventArgs e)
        {
            // If checked this will the last radio button below invisible, change the totalSprinklePrice int and the txt_Sprinkles text
            CB_Sprinkles_1.Visibility = Visibility.Visible;
            CB_Sprinkles_2.Visibility = Visibility.Visible;
            CB_Sprinkles_3.Visibility = Visibility.Hidden;

            totalSprinklePrice = 3f;
            txt_Sprinkles.Content = "Sprinkle(s): " + totalSprinklePrice + "$";
        }

        private void RB_SN3_Checked(object sender, RoutedEventArgs e)
        {
            // If checked this will make all radio buttons below visible, change the totalSprinklePrice int and the txt_Sprinkles text
            CB_Sprinkles_1.Visibility = Visibility.Visible;
            CB_Sprinkles_2.Visibility = Visibility.Visible;
            CB_Sprinkles_3.Visibility = Visibility.Visible;

            totalSprinklePrice = 4.50f;
            txt_Sprinkles.Content = "Sprinkle(s): " + totalSprinklePrice + "$";
        }

        private void Btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            // Opens a messagebox to make sure you want to quit, if ok is cliked you will exit the application
            if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                Application.Current.Shutdown();
            }
        }

        private void Btn_Settings_Click(object sender, RoutedEventArgs e)
        {
            // Opens the settings window and closes this window
            Settings settings = new Settings();
            settings.Show();
            this.Close();
        }

        private void Btn_PlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            // Changes from current tab to the checkout tab
            TabCtrl.SelectedIndex = 2;
        }

        private void txt_FullName_GotFocus(object sender, RoutedEventArgs e)
        {
            // If the textbox is not null do nothing
            if (!string.IsNullOrEmpty(txt_FullName.Text))
            {

            }

            // If the textbox has default content, clear it
            if (txt_FullName.Text == "Full Name")
            {
                txt_FullName.Clear();
            }

            // Change the borderbrush color if it's not already black
            txt_Exp_Year.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));
        }

        private void txt_FullName_LostFocus(object sender, RoutedEventArgs e)
        {
            // If the textbox is not null go on, else change content back to defualt
            if (!string.IsNullOrEmpty(txt_FullName.Text))
            {
                // If text is greater than 2 then go on, else if text equals 0 then change the content back to default. If none of the options make the borderbrush red
                if (txt_FullName.Text.Length > 49)
                {
                    // If the borderbrush equals red then change it back to black
                    if (txt_FullName.BorderBrush == Brushes.Red)
                    {
                        txt_FullName.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));
                    }
                    else
                    {

                    }
                }
                else if (txt_FullName.Text.Length == 0)
                {
                    txt_FullName.Text = "Full Name";
                }
            }
            else
            {
                txt_FullName.Text = "Full Name";
            }
        }

        private void txt_FullName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Allows only alphabetic input, if no letters are pressed no input will come
            e.Handled = Regex.IsMatch(e.Text, @"^[a-zA-Z]+$");
        }

        private void txt_CardNo_GotFocus(object sender, RoutedEventArgs e)
        {
            // If the textbox is not null do nothing
            if (!string.IsNullOrEmpty(txt_CardNo.Text))
            {

            }

            // If the textbox has default content, clear it
            if (txt_CardNo.Text == "**** **** **** ****")
            {
                txt_CardNo.Clear();
            }

            // Change the borderbrush color if it's not already black
            txt_CardNo.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));
        }

        private void txt_CardNo_LostFocus(object sender, RoutedEventArgs e)
        {
            // If the textbox is not null go on, else change content back to defualt
            if (!string.IsNullOrEmpty(txt_CardNo.Text))
            {
                // If text is longer or equals to 16 then go on, else if text equals 0 then change the content back to default. If none of the options make the borderbrush red
                if (txt_CardNo.Text.Length >= 16)
                {
                    txt_CardNo.Text = txt_CardNo.Text.Insert(4, " ");
                    txt_CardNo.Text = txt_CardNo.Text.Insert(9, " ");
                    txt_CardNo.Text = txt_CardNo.Text.Insert(14, " ");

                    // If the borderbrush equals red then change it back to black
                    if (txt_CardNo.BorderBrush == Brushes.Red)
                    {
                        txt_CardNo.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));
                    }
                    else
                    {

                    }
                }
                else if (txt_CardNo.Text.Length == 0)
                {
                    txt_CardNo.Text = "**** **** **** ****";
                }
                else
                {
                    txt_CardNo.BorderBrush = Brushes.Red;
                }
            }
            else
            {
                txt_CardNo.Text = "**** **** **** ****";
            }
        }

        private void txt_CardNo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Allows only numeric input, if nothing numeric is pressed no input will come
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void txt_Exp_Month_GotFocus(object sender, RoutedEventArgs e)
        {
            // If the textbox is not null do nothing
            if (!string.IsNullOrEmpty(txt_Exp_Month.Text))
            {

            }

            // If the textbox has default content, clear it
            if (txt_Exp_Month.Text == "MM")
            {
                txt_Exp_Month.Clear();
            }

            // Change the borderbrush color if it's not already black
            txt_Exp_Month.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));
        }

        private void txt_Exp_Month_LostFocus(object sender, RoutedEventArgs e)
        {
            // If the textbox is not null go on, else change content back to defualt
            if (!string.IsNullOrEmpty(txt_Exp_Month.Text))
            {
                // If text is greater than 1 then go on, else if text equals 0 then change the content back to default. If none of the options make the borderbrush red
                if (txt_Exp_Month.Text.Length > 1)
                {
                    // If the borderbrush equals red then change it back to black
                    if (txt_Exp_Month.BorderBrush == Brushes.Red)
                    {
                        txt_Exp_Month.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));
                    }
                    else
                    {

                    }
                }
                else if (txt_Exp_Month.Text.Length == 0)
                {
                    txt_Exp_Month.Text = "MM";
                }
                else
                {
                    txt_Exp_Month.BorderBrush = Brushes.Red;
                }
            }
            else
            {
                txt_Exp_Month.Text = "MM";
            }
        }

        private void txt_Exp_Month_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Allows only numeric input, if nothing numeric is pressed no input will come
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void txt_Exp_Year_GotFocus(object sender, RoutedEventArgs e)
        {
            // If the textbox is not null do nothing
            if (!string.IsNullOrEmpty(txt_Exp_Year.Text))
            {

            }

            // If the textbox has default content, clear it
            if (txt_Exp_Year.Text == "YY")
            {
                txt_Exp_Year.Clear();
            }

            // Change the borderbrush color if it's not already black
            txt_Exp_Year.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));
        }

        private void txt_Exp_Year_LostFocus(object sender, RoutedEventArgs e)
        {
            // If the textbox is not null go on, else change content back to defualt
            if (!string.IsNullOrEmpty(txt_Exp_Year.Text))
            {
                // If text is greater than 1 then go on, else if text equals 0 then change the content back to default. If none of the options make the borderbrush red
                if (txt_Exp_Year.Text.Length > 1)
                {
                    // If the borderbrush equals red then change it back to black
                    if (txt_Exp_Year.BorderBrush == Brushes.Red)
                    {
                        txt_Exp_Year.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));
                    }
                    else
                    {

                    }
                }
                else if (txt_Exp_Year.Text.Length == 0)
                {
                    txt_Exp_Year.Text = "YY";
                }
                else
                {
                    txt_Exp_Year.BorderBrush = Brushes.Red;
                }
            }
            else
            {
                txt_Exp_Year.Text = "YY";
            }
        }

        private void txt_Exp_Year_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Allows only numeric input, if nothing numeric is pressed no input will come
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void txt_CVC_GotFocus(object sender, RoutedEventArgs e)
        {
            // If the textbox is not null do nothing
            if (!string.IsNullOrEmpty(txt_CVC.Text))
            {

            }

            // If the textbox has default content, clear it
            if (txt_CVC.Text == "CVC")
            {
                txt_CVC.Clear();
            }

            // Change the borderbrush color if it's not already black
            txt_Exp_Year.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));
        }

        private void txt_CVC_LostFocus(object sender, RoutedEventArgs e)
        {
            // If the textbox is not null go on, else change content back to defualt
            if (!string.IsNullOrEmpty(txt_CVC.Text))
            {
                // If text is greater than 2 then go on, else if text equals 0 then change the content back to default. If none of the options make the borderbrush red
                if (txt_CVC.Text.Length > 2)
                {
                    // If the borderbrush equals red then change it back to black
                    if (txt_CVC.BorderBrush == Brushes.Red)
                    {
                        txt_CVC.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));
                    }
                    else
                    {

                    }
                }
                else if (txt_CVC.Text.Length == 0)
                {
                    txt_CVC.Text = "CVC";
                }
                else
                {
                    txt_CVC.BorderBrush = Brushes.Red;
                }
            }
            else
            {
                txt_CVC.Text = "CVC";
            }
        }

        private void txt_CVC_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Allows only numeric input, if nothing numeric is pressed no input will come
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        #endregion

    }
}