using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json.Linq;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace RateStar
{
    
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {

        private HttpClient httpClient;
        //private string url = "";
        private string result = "";

        public BlankPage1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
                getRatings("http://cs.ashesi.edu.gh/~csashesi/class2016/fredrick-abayie/mobileweb/bisa_codename1/php/bisa.php?cmd=rating_view");
        }

        public async void getRatings(string url)
        {
            string feedback = "", rate = "", date = "";

            InitializeComponent();
            httpClient = new HttpClient();
            result = await httpClient.GetStringAsync(url);

            JObject jObject = JObject.Parse(result);

            JArray jArray = (JArray)jObject["ratings"];
            
            for (int rating = 0; rating < jArray.Count; rating++)
            {
                //comment.Text = jArray[rating]["comment"] + "";
                feedback = jArray[rating]["comment"] + "";
                rate = jArray[rating]["rating"] + "";
                date = jArray[rating]["date"] + "";

                resultList.Items.Add("Comment: "+feedback+"\n Rating: "+rate+"\n Date: "+date+"\n");
                //resultList.Items.Add(rate);
            }
            

        }

        private void addRating_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
