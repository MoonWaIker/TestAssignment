using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TestAssignment.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CurrencyPage : Page
    {
        public string currency;
        public static string temp;
        public CurrencyPage()
        {
            this.InitializeComponent();
            Show().ConfigureAwait(false);
        }

        public static void SetCurrency(string currency) 
        {
            temp = currency;
        }

        public async Task Show()
        {
            currency = temp;
            infoList.Items.Add("Currence: " + currency);
            infoList.Items.Add("Price: " + await CryptoCurrencies.GetPrice(currency) + "$");
            infoList.Items.Add("Volume: " + await CryptoCurrencies.GetVolume(currency) + "$");
            infoList.Items.Add("Price changing: " + String.Join(", ", await CryptoCurrencies.GetChanges(currency)));
            infoList.Items.Add("Market: " + await CryptoCurrencies.GetMarket(currency));
        }
    }
}
