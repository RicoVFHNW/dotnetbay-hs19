using DotNetBay.Data.Provider.FileStorage;
using DotNetBay.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DotNetBay.Core;
using DotNetBay.Core.Execution;
using DotNetBay.Data.Entity;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public static IMainRepository MainRepository
        {
            get
            {
                return new FileSystemMainRepository("db.txt");
            }
        }

        private IAuctionRunner _auctionRunner;

        public IAuctionRunner AuctionRunner
        {
            get
            {
                if (_auctionRunner == null)
                {
                    _auctionRunner = new AuctionRunner(MainRepository);
                }

                return _auctionRunner;
            } set { _auctionRunner = value; }
        }


        public App()
        {
            AuctionRunner.Start();

            var memberService = new SimpleMemberService(MainRepository);
            var service = new AuctionService(MainRepository, memberService);

            if (!service.GetAll().Any())
            {
                var me = memberService.GetCurrentMember();

                service.Save(new Auction
                {
                    Title = "My first Auction",
                    StartDateTimeUtc = DateTime.UtcNow.AddSeconds(10),
                    EndDateTimeUtc = DateTime.UtcNow.AddDays(14),
                    StartPrice = 72,
                    Seller = me
                });
            }
        }
    }
}
