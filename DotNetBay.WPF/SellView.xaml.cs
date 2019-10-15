using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Microsoft.Win32;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaktionslogik für SellView.xaml
    /// </summary>
    public partial class SellView : Window
    {
        public SellView()
        {
            InitializeComponent();
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                ImageURL.Text = openFileDialog.FileName;
            }
        }
    }
}
