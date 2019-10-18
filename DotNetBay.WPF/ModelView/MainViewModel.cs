using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DotNetBay.Core;
using DotNetBay.Core.Execution;
using DotNetBay.Data.Entity;
using DotNetBay.WPF.Command;
using DotNetBay.WPF.View;

namespace DotNetBay.WPF.ModelView
{
    class MainViewModel: ViewModelBase
    {
        public ObservableCollection<AuctionViewModel> Auctions { get; set; } = new ObservableCollection<AuctionViewModel>();
        private AuctionService auctionService { get; set; }

        public MainViewModel()
        {
            this.auctionService = new AuctionService(App.MainRepository, new SimpleMemberService(App.MainRepository));
            IQueryable<Auction> auctions = this.auctionService.GetAll();

            foreach (var auction in auctions)
            {
                Auctions.Add(new AuctionViewModel(auction));
            }

            var app = Application.Current as App;
            app.AuctionRunner.Auctioneer.AuctionEnded += AuctioneerOnAuctionEnded;
            app.AuctionRunner.Auctioneer.AuctionStarted += AuctioneerOnAuctionStarted;
            app.AuctionRunner.Auctioneer.BidDeclined += Auctioneer_BidDeclined;
            app.AuctionRunner.Auctioneer.BidAccepted += Auctioneer_BidAccepted;
        }

        private void Auctioneer_BidAccepted(object sender, ProcessedBidEventArgs e)
        {
            Console.WriteLine("Bid Accepted");
        }

        private void Auctioneer_BidDeclined(object sender, ProcessedBidEventArgs e)
        {
            Console.WriteLine("Bid Declined");
        }

        private void AuctioneerOnAuctionStarted(object sender, AuctionEventArgs e)
        {
            Console.WriteLine("Auction Started");
        }

        private void AuctioneerOnAuctionEnded(object sender, AuctionEventArgs e)
        {
            Console.WriteLine("Auction Ended");
        }

        public ICommand OpenSellView
        {
            get { return new RelayCommand(OpenSellViewExecute, CanOpenSellViewExecute);}
        }

        void OpenSellViewExecute()
        {
            var sellView = new SellView();
            sellView.ShowDialog();
        }


        bool CanOpenSellViewExecute()
        {
            return true;
        }
    }
}
