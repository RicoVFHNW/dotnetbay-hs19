using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DotNetBay.Core;
using DotNetBay.WPF.Command;
using Microsoft.Win32;

namespace DotNetBay.WPF.ModelView
{
    class SellViewModel: ViewModelBase
    {
        private string imageUrl = "";

        public String Title { get; set; } = "";
        public String StartPrice { get; set; } = "";
        public String Description { get; set; } = "";
        public String ImageUrl
        {
            get { return imageUrl;}
            set { imageUrl = value; OnPropertyChanged(new PropertyChangedEventArgs("ImageUrl")); }
        }

        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);

        void SaveAuctionExecute()
        {
            //TODO: IMPLEMENT
        }

        bool CanSaveAuctionExecute()
        {
            int startPrice;

            if (Title.Length == 0 || Description.Length == 0 || StartPrice.Length == 0 || !int.TryParse(StartPrice, out startPrice)
                || String.IsNullOrEmpty(StartDate.ToString()) || String.IsNullOrEmpty(EndDate.ToString()) || String.IsNullOrEmpty(ImageUrl))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public ICommand SaveAuction
        {
            get { return new RelayCommand(SaveAuctionExecute, CanSaveAuctionExecute); }
        }

        public ICommand ChooseImageUrl
        {
            get { return new RelayCommand(OpenFileDialog, CanOpenFile);}
        }

        bool CanOpenFile()
        {
            return true;
        }

        void OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                ImageUrl = openFileDialog.FileName;
            }
        }
    }
}
