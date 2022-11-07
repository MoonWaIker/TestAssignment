using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CoinGecko.Clients;
using System.Net.Http;

namespace TestAssignment
{
    internal class CryptoCurrencies
    {
        // Return the price of an ids
        public static async Task<decimal?> GetPrice(string ids)

        {

            // Initialization...

            HttpClient httpClient = new HttpClient();

            JsonSerializerSettings serializerSettings = new JsonSerializerSettings();



            PingClient pingClient = new PingClient(httpClient, serializerSettings);

            SimpleClient simpleClient = new SimpleClient(httpClient, serializerSettings);



            if ((await pingClient.GetPingAsync()).GeckoSays != string.Empty)

                return (await simpleClient.GetSimplePrice(new[] { ids }, new[] { "usd" }))[ids]["usd"];

            else

                return null;

        }



        // Return  volume of an ids

        public static async Task<decimal?> GetVolume(string ids)

        {

            // Initialization...

            HttpClient httpClient = new HttpClient();

            JsonSerializerSettings serializerSettings = new JsonSerializerSettings();



            PingClient pingClient = new PingClient(httpClient, serializerSettings);

            CoinGeckoClient coinGeckoClient = new CoinGeckoClient();



            if ((await pingClient.GetPingAsync()).GeckoSays != string.Empty)

                return (await coinGeckoClient.CoinsClient.GetCoinMarkets("usd", new[] { ids }, null, null, null, false,

            "1h,24h,7d,14d,30d,200d,1y", "")).First().TotalVolume;

            return null;

        }



        // Return changes of ids

        public static async Task<List<decimal?>> GetChanges(string ids)

        {

            // Initialization...

            HttpClient httpClient = new HttpClient();

            JsonSerializerSettings serializerSettings = new JsonSerializerSettings();



            PingClient pingClient = new PingClient(httpClient, serializerSettings);

            CoinGeckoClient coinGeckoClient = new CoinGeckoClient();



            if ((await pingClient.GetPingAsync()).GeckoSays != string.Empty)

            {

                List<decimal?> list = new List<decimal?>();

                var result = await coinGeckoClient.CoinsClient.GetCoinMarkets("usd", new[] { ids }, null, null, null, false,

            "1h,24h,7d,14d,30d,200d,1y", "");

                list.Add(result.First().PriceChangePercentage1HInCurrency);

                list.Add(result.First().PriceChangePercentage24HInCurrency);

                list.Add(result.First().PriceChangePercentage7DInCurrency);

                list.Add(result.First().PriceChangePercentage14DInCurrency);

                list.Add(result.First().PriceChangePercentage30DInCurrency);

                list.Add(result.First().PriceChangePercentage200DInCurrency);

                list.Add(result.First().PriceChangePercentage1YInCurrency);

                return list;

            }

            return null;

        }



        // Get market of ids

        public static async Task<string> GetMarket(string ids)

        {

            // Initialization...

            HttpClient httpClient = new HttpClient();

            JsonSerializerSettings serializerSettings = new JsonSerializerSettings();



            PingClient pingClient = new PingClient(httpClient, serializerSettings);

            CoinGeckoClient coinGeckoClient = new CoinGeckoClient();



            if ((await pingClient.GetPingAsync()).GeckoSays != string.Empty)

            {

                var result = await coinGeckoClient.CoinsClient.GetAllCoinDataWithId(ids);

                return result.Tickers.First().TradeUrl;

            }

            return null;

        }



        // Calculate exchange rates of ids

        public static async Task<decimal?> CalculateRates(string ids1, string ids2, decimal value)

        {

            HttpClient httpClient = new HttpClient();

            JsonSerializerSettings serializerSettings = new JsonSerializerSettings();



            PingClient pingClient = new PingClient(httpClient, serializerSettings);

            CoinGeckoClient coinGeckoClient = new CoinGeckoClient();

            if ((await pingClient.GetPingAsync()).GeckoSays != string.Empty)

            {

                return await GetPrice(ids1) / await GetPrice(ids2) * value;

            }

            return null;

        }



        // Get top of currencies

        public static async Task<List<string>> GetTop()

        {

            // Initialization...

            HttpClient httpClient = new HttpClient();

            JsonSerializerSettings serializerSettings = new JsonSerializerSettings();



            PingClient pingClient = new PingClient(httpClient, serializerSettings);

            CoinGeckoClient coinGeckoClient = new CoinGeckoClient();



            if ((await pingClient.GetPingAsync()).GeckoSays != string.Empty)

            {

                var result = await coinGeckoClient.CoinsClient.GetCoinMarkets("usd");

                List<string> list = new List<string>();

                for (int i = 0; i < result.Count; i++)

                    list.Add(result[i].Name);

                return list;

            }

            return null;

        }
    }
}
