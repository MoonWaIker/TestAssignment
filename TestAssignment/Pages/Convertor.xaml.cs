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
    public sealed partial class Convertor : Page
    {
        public Convertor()
        {
            this.InitializeComponent();
            AddElements().ConfigureAwait(false);
        }

        public async Task AddElements() 
        {
            List<string> list = await CryptoCurrencies.GetTop();

            foreach(string currency in list)
            {
                Combo1.Items.Add(currency);
                Combo2.Items.Add(currency);
            }
        }

        public void OnClick(Object sender, RoutedEventArgs e) => AddToHistory().ConfigureAwait(false);
        
        public async Task AddToHistory()
        {
            historyOfCalculating.Items.Add(await CryptoCurrencies.CalculateRates(Combo1.SelectionBoxItem.ToString().ToLower(), Combo2.SelectionBoxItem.ToString().ToLower(), Convert.ToDecimal(convertBox.Text)));
        }
    }
}
