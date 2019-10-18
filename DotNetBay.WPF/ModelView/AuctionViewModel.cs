using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DotNetBay.Data.Entity;
using DotNetBay.WPF.Command;
using DotNetBay.WPF.View;

namespace DotNetBay.WPF.ModelView
{
    class AuctionViewModel
    {
        public Auction Auction { get; set; }

        public AuctionViewModel(Auction auction)
        {
            Auction = auction;
        }

        public ICommand OpenSellView
        {
            get { return new RelayCommand(OpenBidViewExecute, CanOpenBidViewExecute); }
        }

        void OpenBidViewExecute()
        {
            var bidView = new BidView(Auction);
            bidView.ShowDialog();
        }


        bool CanOpenBidViewExecute()
        {
            return true;
        }
    }
}
