using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DotNetBay.Core;
using DotNetBay.Data.Entity;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Auction> Auctions { get; set; } = new ObservableCollection<Auction>();
        private AuctionService auctionService;

        public MainWindow()
        {
            this.auctionService = new AuctionService(App.MainRepository, new SimpleMemberService(App.MainRepository));
            this.Auctions = new ObservableCollection<Auction>(this.auctionService.GetAll());
            this.DataContext = this;
        
           
            InitializeComponent();
        }

        private void SellButtonClick(object sender, RoutedEventArgs e)
        {
            var sellView = new SellView();
            sellView.ShowDialog();
        }

        private void BidButtonClick(object sender, RoutedEventArgs e)
        {
            var bidView = new BidView(((Button)sender).DataContext as Auction);
            bidView.ShowDialog();
        }
    }
}
