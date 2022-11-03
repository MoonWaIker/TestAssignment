using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using TestAssignment.Pages;
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

namespace TestAssignment
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchPage : Page
    {
        public SearchPage()
        {
            this.InitializeComponent();
            Show().ConfigureAwait(false);
        }

        public async Task Show() 
        {
            List<string> cryptoList = await CryptoCurrencies.GetList();

            foreach (string str in cryptoList)
                cryptoCurrenciesList.Items.Add(str);
        }

        public void OnClick(Object sender, RoutedEventArgs e) => Redo().ConfigureAwait(false);

        public async Task Redo()
        {
            if (findBox.Text != "" && findBox.Text != null)
            {
                cryptoCurrenciesList.Items.Clear();

                List<string> cryptoList = await CryptoCurrencies.GetList();

                foreach (string str in cryptoList)
                    if (str.Contains(findBox.Text))
                        cryptoCurrenciesList.Items.Add(str);
            }
            else await Show();
        }

        public void ItemClick(Object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CurrencyPage));
        }
    }
}
