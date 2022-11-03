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
        public string currency = "bitcoin";
        public CurrencyPage()
        {
            this.InitializeComponent();
            Show().ConfigureAwait(false);
        }

        public async Task Show()
        {
            infoList.Items.Add(currency);
            infoList.Items.Add(await CryptoCurrencies.GetPrice(currency));
            infoList.Items.Add(await CryptoCurrencies.GetVolume(currency));
            infoList.Items.Add(String.Join(", ", await CryptoCurrencies.GetChanges(currency)));
            infoList.Items.Add(await CryptoCurrencies.GetMarket(currency));
        }
    }
}
