using System;
using System.ComponentModel;
using System.Windows;
using DotNetBay.Core;
using DotNetBay.WPF.ModelView;
using Microsoft.Win32;

namespace DotNetBay.WPF.View
{
    /// <summary>
    /// Interaktionslogik für SellView.xaml
    /// </summary>
    public partial class SellView : Window
    {   
        public SellView()
        {
            this.DataContext = new SellViewModel();
            InitializeComponent();
        }
    }
}
