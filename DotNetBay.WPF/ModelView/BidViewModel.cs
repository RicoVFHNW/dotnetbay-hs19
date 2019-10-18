using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DotNetBay.Data.Entity;
using DotNetBay.WPF.Command;

namespace DotNetBay.WPF.ModelView
{
    class BidViewModel: ViewModelBase
    {
        public String BidPrice { get; set; }
        public Auction Auction { get; set; }

        public BidViewModel(Auction auction)
        {
            Auction = auction;
        }

        public ICommand SaveBid
        {
            get { return new RelayCommand(SaveBidExecute, CanSaveBidExecute);}
        }

        void SaveBidExecute()
        {
            //TODO: IMPLEMENT
            Console.WriteLine("SAVE!");
        }

        bool CanSaveBidExecute()
        {
            int p;

            if (int.TryParse(BidPrice, out p) && p > 0)
            {
                return true;
            }

            return false;
        }
    }
}
