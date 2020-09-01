using AngleSharp.Browser;
using AuctionerMTG.Controler;
using AuctionerMTG.Model.Parsers;
using AuctionerMTG.Model.ParsersSettings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AuctionerMTG
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string auctionName;
        ParserWorker parser;

        public MainWindow()
        {
            InitializeComponent();
            AuthorizationForm GetToken = new AuthorizationForm();
            GetToken.ShowDialog();

        }

        private void ParserOnNewData(object arg1, List<IAuction> arg2)
        {
            AuctionView.ItemsSource = arg2;
        }
        

        private void ParserOnComplited(object obj)
        {
            MessageBox.Show("I vse!");
        }
        private void UrlLink(object sender, RoutedEventArgs e)
        {
            Hyperlink hyperlink = (Hyperlink)sender;
            string url = hyperlink.NavigateUri.ToString();
            Process.Start(new ProcessStartInfo(url));
            e.Handled = true;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            AuctionNameList name = (AuctionNameList)Enum.Parse(typeof(AuctionNameList), auctionName, true);
            ParserSettings.SetParser(name);
            parser = ParserSettings.GetCurrentParser;
            parser.OnComplited += ParserOnComplited;
            parser.OnNewName += ParserOnNewData;
            parser.Start();
            MessageBox.Show("Waith!");

        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            AuctionView.ItemsSource = null;

        }
        

        private void CloseButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MinButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Logo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left )
            {
                this.DragMove();
            }
        }

        private void AuctionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBlock selectedItem = (TextBlock)comboBox.SelectedItem;
            auctionName = selectedItem.Text;
            //ParserSettings.SetParser(selectedItem.Text);
            //parser = ParserSettings.GetCurrentParser;
            
        }
    }
}
