using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Xml.Linq;
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
    public sealed partial class Home : Page
    {
        public Home()
        {
            this.InitializeComponent();
            Show().ConfigureAwait(false);
        }

        public async Task Show() 
        {
            List<string> methodList = await CryptoCurrencies.GetTop();
            int n = 10;

            if (n <= 0)
                n = methodList.Count;

            for (int i = 0; i < n; ++i)
                cryptoCurrenciesList.Items.Add(new ListViewItem { Name = methodList[i], Content = methodList[i] });
        }

        private void SettingsHub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                CurrencyPage.SetCurrency((e.AddedItems[0] as ListViewItem).Name.ToString().ToLower());
                this.Frame.Navigate(typeof(CurrencyPage));
            }
        }
    }
}
