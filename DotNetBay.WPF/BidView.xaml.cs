using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using DotNetBay.Data.Entity;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaktionslogik für BidView.xaml
    /// </summary>
    public partial class BidView : Window, INotifyPropertyChanged
    {
        public Auction auctionAu;
        public event PropertyChangedEventHandler PropertyChanged;
        private Boolean BidAbleBool = false;
        private String BidPriceString = "0";

        public Auction auction
        {
            get { return auctionAu;} set { auctionAu = value; }
        }

        public Boolean BidAble
        {
            get { return BidAbleBool; }
            set { BidAbleBool = value;
                OnPropertyChanged("BidAble");
            }
        }

        public String BidPrice
        {
            get { return BidPriceString; }
            set
            {
                BidPriceString = value;
                try
                {
                    if (int.Parse(value) > 0)
                    {
                        BidAble = true;
                    }
                    else
                    {
                        BidAble = false;
                    }
                }
                catch (Exception e)
                {
                    BidAble = false;
                }

                OnPropertyChanged("BidPrice");
            }
        }

        public BidView(Auction auction)
        {
            this.auctionAu = auction;

            DataContext = this;

            InitializeComponent();
        }

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void SaveBid(object sender, RoutedEventArgs e)
        {
            //TODO: SAVE BID
            this.Close();
        }
    }
}
