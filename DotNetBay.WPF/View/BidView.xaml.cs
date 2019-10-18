using System;
using System.ComponentModel;
using System.Windows;
using DotNetBay.Data.Entity;
using DotNetBay.WPF.ModelView;

namespace DotNetBay.WPF.View
{
    /// <summary>
    /// Interaktionslogik für BidView.xaml
    /// </summary>
    public partial class BidView : Window
    {

        public BidView(Auction auction)
        {
            DataContext = new BidViewModel(auction);

            InitializeComponent();
        }
    }
}
