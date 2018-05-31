using System.Net.Http;
using Newtonsoft.Json;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace VincentTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// Vincent's Code !! 
        /// string url = Link Json API irail -> new http client 
        /// Output in Textblock -> Liveboard results in minutes

        async void getLiveboardStation()
        {
            string url = "https://api.irail.be/liveboard/?station=Antwerpen-Centraal&format=json&arrdep=ARR";
            HttpClient client = new HttpClient();

            string LiveboardStation = await client.GetStringAsync(url);
            var data = JsonConvert.DeserializeObject<RootObjectStation>(LiveboardStation);


            string vertraging = data.arrivals.arrival[9].delay;

            if (vertraging.Contains("0") == true) //text block content
            {
                txtBlockLiveboardResult.Text = "Op dit moment zijn er geen vertragingen"; 
            }
            else
            {
                txtBlockLiveboardResult.Text = "Opgelet ! Op dit moment zijn er" + vertraging + "minuten vertragingen";
            }
        }

        private void Liveboard_Click(object sender, RoutedEventArgs e)
        {
            getLiveboardStation();
        }
    }

    internal class RootObjectStation
    {
    }
}
