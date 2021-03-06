﻿using System.Windows;
using System.Windows.Controls;
using IsButik.Modules;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;
using System.Windows.Media;
using System.Windows.Input;
using Newtonsoft.Json;

namespace IsButik
{
    public partial class MainWindow : Window
    {
        #region Variables

        private List<string> containerPrices = new List<string>();

        private float totalSprinklePrice;

        private string container;
        private string iceType;
        private string scoops;
        private string flavours;
        private string sprinkles;

        private string fullName;
        private string cardType;
        private string cardNumber;
        private string exp_Month;
        private string exp_Year;
        private string CVC;

        private string Order;

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

        public static void WriteToJsonFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite, Formatting.Indented);
                writer = new StreamWriter(filePath, append);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public static T ReadFromJsonFile<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader(filePath);
                var fileContents = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(fileContents);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
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

        private void GetInformation()
        {
            if (CB_Containers.SelectedIndex != -1)
            {
                container = CB_Containers.SelectedItem.ToString();
            }
            if (CB_Scoops.SelectedIndex != -1)
            {
                scoops = CB_Scoops.SelectedItem.ToString();
            }
            if (RB_SN1.IsChecked == true)
            {
                sprinkles = CB_Sprinkles_1.SelectedItem.ToString();
            }
            if (RB_SN2.IsChecked == true)
            {
                sprinkles = CB_Sprinkles_1.SelectedItem.ToString() + ", " + CB_Sprinkles_2.SelectedItem.ToString();
            }
            if (RB_SN3.IsChecked == true)
            {
                sprinkles = CB_Sprinkles_1.SelectedItem.ToString() + ", " + CB_Sprinkles_2.SelectedItem.ToString() + ", " + CB_Sprinkles_3.SelectedItem.ToString();
            }
            fullName = txt_FullName.Text;
            cardNumber = txt_CardNo.Text;
            exp_Month = txt_Exp_Month.Text;
            exp_Year = txt_Exp_Year.Text;
            CVC = txt_CVC.Text;
        }

        private void CreateDirectories()
        {
            // Path to appdata folder
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            // Path to create root directory with
            string rootDirectory = Path.Combine(appdata, "IceCreamShop");
            // Path to create settings subdirectory with
            string subdirSettings = Path.Combine(rootDirectory, "Settings");
            // Path to create orders subdirectory with
            string subdirOrders = Path.Combine(rootDirectory, "Orders");

            // If directory does not exist, create it. 
            if (!Directory.Exists(rootDirectory))
            {
                Directory.CreateDirectory(rootDirectory);
            }

            // If directory does not exist, create it. 
            if (!Directory.Exists(subdirSettings))
            {
                Directory.CreateDirectory(subdirSettings);
            }

            // If directory does not exist, create it. 
            if (!Directory.Exists(subdirOrders))
            {
                Directory.CreateDirectory(subdirOrders);
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

            iceType = "Gelato";
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
            iceType = "softice";
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

        private void RB_Mastercard_Checked(object sender, RoutedEventArgs e)
        {
            // If checked then set the value to Mastercard
            cardType = "Mastercard";
        }

        private void RB_Visa_Checked(object sender, RoutedEventArgs e)
        {
            // If checked then set the value to Visa
            cardType = "Visa";
        }

        private void RB_CreditCards_Checked(object sender, RoutedEventArgs e)
        {
            // If checked then set the value to Credit Cards
            cardType = "Credit Card";
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

        private void btn_Pay_Click(object sender, RoutedEventArgs e)
        {
            // User Settings window to check the save point
            Settings settings = new Settings();
            // Initialize GetInformation Method to fill the information to the Order class
            GetInformation();

            // Create a new instance of the Order class to serialize and turn into a json file
            Order order = new Order()
            {
                container = container,
                scoops = scoops,
                iceType = iceType,
                flavours = flavours,
                sprinkles = sprinkles,
                fullName = fullName,
                cardType = cardType,
                cardNumber = cardNumber,
                exp_Month = exp_Month,
                exp_Year = exp_Year,
                CVC = CVC
            };

            // Path to appdata folder
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            // Path to create root directory with
            string rootDirectory = Path.Combine(appdata, "IceCreamShop");
            // Path to subdir
            string subdir = Path.Combine(rootDirectory, "Orders");
            // Generate a unique number for the order ids
            string number = String.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);

            if (settings.RB_SaveLocally.IsChecked == true)
            {
                WriteToJsonFile<Order>(subdir + "\\order" + "#" + $"{number}.json", order);
            }
            else
            {

            }
        }

        private void Flavour_Vanilla_Click(object sender, RoutedEventArgs e)
        {
            // If textcolor is red change it to black, else change it to red
            if (txt_Vanilla.Foreground == Brushes.Red)
            {
                txt_Vanilla.Foreground = Brushes.Black;
                flavours = flavours.Replace("Vanilla ", "");
            }
            else
            {
                txt_Vanilla.Foreground = Brushes.Red;
                flavours = flavours + "Vanilla ";
            }
        }

        private void Flavour_Strawberry_Click(object sender, RoutedEventArgs e)
        {
            // If textcolor is red change it to black, else change it to red
            if (txt_Strawberry.Foreground == Brushes.Red)
            {
                txt_Strawberry.Foreground = Brushes.Black;
                flavours = flavours.Replace("Strawberry ", "");
            }
            else
            {
                txt_Strawberry.Foreground = Brushes.Red;
                flavours = flavours + "Strawberry ";
            }
        }

        private void Flavour_Chocolate_Click(object sender, RoutedEventArgs e)
        {
            // If textcolor is red change it to black, else change it to red
            if (txt_Chocolate.Foreground == Brushes.Red)
            {
                txt_Chocolate.Foreground = Brushes.Black;
                flavours = flavours.Replace("Chocolate ", "");
            }
            else
            {
                txt_Chocolate.Foreground = Brushes.Red;
                flavours = flavours + "Chocolate ";
            }
        }

        private void Flavour_Limone_Click(object sender, RoutedEventArgs e)
        {
            // If textcolor is red change it to black, else change it to red
            if (txt_Limone.Foreground == Brushes.Red)
            {
                txt_Limone.Foreground = Brushes.Black;
                flavours = flavours.Replace("Limone ", "");
            }
            else
            {
                txt_Limone.Foreground = Brushes.Red;
                flavours = flavours + "Limone ";
            }
        }

        private void Flavour_Pistacchio_Click(object sender, RoutedEventArgs e)
        {
            // If textcolor is red change it to black, else change it to red
            if (txt_Pistacchio.Foreground == Brushes.Red)
            {
                txt_Pistacchio.Foreground = Brushes.Black;
                flavours = flavours.Replace("Pistacchio ", "");
            }
            else
            {
                txt_Pistacchio.Foreground = Brushes.Red;
                flavours = flavours + "Pistacchio ";
            }
        }

        private void Flavour_Caffé_Click(object sender, RoutedEventArgs e)
        {
            // If textcolor is red change it to black, else change it to red
            if (txt_Caffé.Foreground == Brushes.Red)
            {
                txt_Caffé.Foreground = Brushes.Black;
                flavours = flavours.Replace("Caffé ", "");
            }
            else
            {
                txt_Caffé.Foreground = Brushes.Red;
                flavours = flavours + "Caffé ";
            }
        }

        private void Flavour_Pesca_Click(object sender, RoutedEventArgs e)
        {
            // If textcolor is red change it to black, else change it to red
            if (txt_Pesca.Foreground == Brushes.Red)
            {
                txt_Pesca.Foreground = Brushes.Black;
                flavours = flavours.Replace("Pesca ", "");
            }
            else
            {
                txt_Pesca.Foreground = Brushes.Red;
                flavours = flavours + "Pesca ";
            }
        }

        private void Flavour_Cocco_Click(object sender, RoutedEventArgs e)
        {
            // If textcolor is red change it to black, else change it to red
            if (txt_Cocco.Foreground == Brushes.Red)
            {
                txt_Cocco.Foreground = Brushes.Black;
                flavours = flavours.Replace("Cocco ", "");
            }
            else
            {
                txt_Cocco.Foreground = Brushes.Red;
                flavours = flavours + "Cocco ";
            }
        }

        private void Flavour_Stracciatella_Click(object sender, RoutedEventArgs e)
        {
            // If textcolor is red change it to black, else change it to red
            if (txt_Stracciatella.Foreground == Brushes.Red)
            {
                txt_Stracciatella.Foreground = Brushes.Black;
                flavours = flavours.Replace("Stracciatella ", "");
            }
            else
            {
                txt_Stracciatella.Foreground = Brushes.Red;
                flavours = flavours + "Stracciatella ";
            }
        }

        private void Flavour_Menta_Click(object sender, RoutedEventArgs e)
        {
            // If textcolor is red change it to black, else change it to red
            if (txt_Menta.Foreground == Brushes.Red)
            {
                txt_Menta.Foreground = Brushes.Black;
                flavours = flavours.Replace("Menta ", "");
            }
            else
            {
                txt_Menta.Foreground = Brushes.Red;
                flavours = flavours + "Menta ";
            }
        }

        private void Flavour_Melone_Click(object sender, RoutedEventArgs e)
        {
            // If textcolor is red change it to black, else change it to red
            if (txt_Melone.Foreground == Brushes.Red)
            {
                txt_Melone.Foreground = Brushes.Black;
                flavours = flavours.Replace("Melone ", "");
            }
            else
            {
                txt_Melone.Foreground = Brushes.Red;
                flavours = flavours + "Melone ";
            }
        }

        private void Flavour_Banana_Click(object sender, RoutedEventArgs e)
        {
            // If textcolor is red change it to black, else change it to red
            if (txt_Banana.Foreground == Brushes.Red)
            {
                txt_Banana.Foreground = Brushes.Black;
                flavours = flavours.Replace("Banana ", "");
            }
            else
            {
                txt_Banana.Foreground = Brushes.Red;
                flavours = flavours + "Banana ";
            }
        }

        #endregion
    }
}