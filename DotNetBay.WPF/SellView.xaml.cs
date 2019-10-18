using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using DotNetBay.Core;
using DotNetBay.Data.Entity;
using Microsoft.Win32;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaktionslogik für SellView.xaml
    /// </summary>
    public partial class SellView : Window, INotifyPropertyChanged
    {
        private Boolean createableBool = false;

        public Boolean Createable
        {
            get { return createableBool; }
            set
            {
                createableBool = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Createable");
            }
        }

        private AuctionService auctionService;

        public event PropertyChangedEventHandler PropertyChanged;

        public SellView(AuctionService auctionService)
        {
            this.auctionService = auctionService;
            Createable = false;
            this.DataContext = this;
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

        private void validateInput(object sender, RoutedEventArgs e)
        {
            int startPrice;

            if (TitleInput.Text.Length == 0 || DescriptionInput.Text.Length == 0 || StartPriceInput.Text.Length == 0 || !int.TryParse(StartPriceInput.Text, out startPrice)
                || String.IsNullOrEmpty(StartDateInput.Text) || String.IsNullOrEmpty(EndDateInput.Text) || String.IsNullOrEmpty(ImageURL.Text))
            {
                this.Createable = false;
            }
            else
            {
                this.Createable = true;
            }
        }

        private void SaveAuction(object sender, RoutedEventArgs e)
        {
            //TODO: SAVE AUCTION
            /*auctionService.Save(new Auction
            {
                Title = TitleInput.Text,
                StartDateTimeUtc = StartDateInput.SelectedDate.Value,
                EndDateTimeUtc = EndDateInput.SelectedDate.Value,
                StartPrice = int.Parse(StartPriceInput.Text),
                Seller = new SimpleMemberService(App.MainRepository).GetCurrentMember()
            });*/

            this.Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
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
    }
}
