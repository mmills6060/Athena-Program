using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Athena_Program
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static int __step_no = 0;
        private static string message = "Symbol:";
        private static string title = "Price Request";
        private static string price;
        private static string pricechange;
        private static string pricechangepercent;
        private static string weightedavgprice;
        private static string prevclosecprice;
        private static string lastQty;
        private static string bidprice;
        private static string bidqty;
        private static string askprice;
        private static string openprice;
        private static string highprice;
        private static string lowprice;
        private static string volume;
        private static string quotevolume;
        private static string symbol;
        private static string pricee;
        private static string search;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string message = "Symbol:";
            // string title = "Price Request";

            Task objTask = MichaelMain();

            //MessageBox.Show(message, title);
        }

        private static async Task MichaelMain()
        {
            //string message = "Symbol:";

            var _public_api = new CCXT.NET.Binance.Public.PublicApi();

            if (__step_no == 0 || __step_no == 1)
            {
                var _tickers = await _public_api.FetchTickersAsync();
                // var _tickers =  _public_api.FetchTickersAsync();
                if (_tickers.success == true)
                {
                    var _btcusd_tickers = _tickers.result.Where(t => t.symbol.ToUpper().Contains("BTCUSD"));

                    foreach (var _t in _btcusd_tickers)
                    {

                        message = message + _t.symbol + _t.lastPrice;


                        //Console.Out.WriteLine($"symbol: {_t.symbol}, lastprice: {_t.lastPrice}");
                    }
                    MessageBox.Show(message, title);
                }
                else
                {
                    //Console.Out.WriteLine($"error: {_tickers.message}");
                    message = "Fail";
                }
            }
        }
        private static async Task BruceMain()
        {

            {
                var _public_api = new CCXT.NET.Binance.Public.PublicApi();

                if (__step_no == 0 || __step_no == 1)
                {
                    var _tickers = await _public_api.FetchTickersAsync();
                    if (_tickers.success == true)
                    {
                        var _btcusd_tickers = _tickers.result.Where(t => t.symbol.ToUpper().Contains("BTCUSD"));

                        foreach (var _t in _btcusd_tickers)
                        {
                            // DataGridView1.Rows[price].cells["Last"].Value = _t.lastPrice;
                            message = "works";
                        }
                        MessageBox.Show(message, title);

                    }
                    else
                    {
                        message = "Fail";
                    }
                }
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Task objTask = BruceMain();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        public static async Task RobinMain()
        {
            //string message = "Symbol:";

            var _public_api = new CCXT.NET.Binance.Public.PublicApi();

            if (__step_no == 0 || __step_no == 1)
            {
                var _tickers = await _public_api.FetchTickersAsync();
                // var _tickers =  _public_api.FetchTickersAsync();
                if (_tickers.success == true)
                {
                    var _btcusd_tickers = _tickers.result.Where(t => t.symbol.ToUpper().Contains(search));

                    foreach (var _t in _btcusd_tickers)
                    {
                        price = "";
                        price = price + _t.lastPrice;
                        price = price.TrimEnd('0');
                        pricechange = "";
                        pricechange = pricechange + _t.changePrice;
                        pricechange = pricechange.TrimEnd('0');
                        pricechangepercent = "";
                        pricechangepercent = pricechangepercent + _t.percentage;
                        pricechangepercent = pricechangepercent.TrimEnd('0');
                        weightedavgprice = "";
                        weightedavgprice = weightedavgprice + _t.vwap;
                        weightedavgprice = weightedavgprice.TrimEnd('0');
                        prevclosecprice = "";
                        prevclosecprice = prevclosecprice + _t.closePrice;
                        prevclosecprice = prevclosecprice.TrimEnd('0');
                        //lastQty = "";                  //unable to find API connection
                        //lastQty = lastQty + _t.qu;
                        //lastQty = lastQty.TrimEnd('0');
                        bidprice = "";
                        bidprice = bidprice + _t.bidPrice;
                        bidprice = bidprice.TrimEnd('0');
                        bidqty = "";
                        bidqty = bidqty + _t.bidQuantity;
                        bidqty = bidqty.TrimEnd('0');
                        askprice = "";
                        askprice = askprice + _t.askPrice;
                        askprice = askprice.TrimEnd('0');
                        openprice = "";
                        openprice = openprice + _t.openPrice;
                        openprice = openprice.TrimEnd('0');
                        highprice = "";
                        highprice = highprice + _t.highPrice;
                        highprice = highprice.TrimEnd('0');
                        lowprice = "";
                        lowprice = lowprice + _t.lowPrice;
                        lowprice = lowprice.TrimEnd('0');
                        volume = "";
                        volume = volume + _t.baseVolume;
                        volume = volume.TrimEnd('0');
                        quotevolume = "";
                        quotevolume = quotevolume + _t.quoteVolume;
                        quotevolume = quotevolume.TrimEnd('0');
                        symbol = "";
                        symbol = symbol + _t.symbol;
                        symbol = symbol.TrimEnd('0');

                    }
                }
                else
                {
                    //Console.Out.WriteLine($"error: {_tickers.message}");
                    message = "Fail";
                }
            }
        }
       // private void textchanged1(object sender, TextChangedEventArgs e)
       // {
            //Task objTask = RobinMain();
           //search = textBox.Text;
            //textBox1.Text = price;
        //}
        public void textchanged(object sender, TextChangedEventArgs e)
        {
            Task objTask = RobinMain();
            search = textBox.Text;
            LastPrice.Text = price;
            PriceChange.Text = pricechange;
            Pricechangeprcnt.Text = pricechange;
            weightedaverageprice.Text = weightedavgprice;
            Previouscloseprice.Text = prevclosecprice;
            biddprice.Text = bidprice;
            bidQty.Text = bidqty;
            AskPrice.Text = askprice;
            Openprice.Text = openprice;
            Highprice.Text = highprice;
            Lowprice.Text = lowprice;
            Volume.Text = volume;
            Quotevolume.Text = quotevolume;
            Symbol.Text = symbol;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
