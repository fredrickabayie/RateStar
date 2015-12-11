using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json.Linq;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace RateStar
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }


        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private async void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            string result, url, comment, rating = "";

            if (Convert.ToBoolean(worse.IsChecked))
            {
                rating = "1";
               // MessageBox.Show("1 checked");
            }
            else if (Convert.ToBoolean(bad.IsChecked))
            {
                rating = "2";
            }
            else if (Convert.ToBoolean(ok.IsChecked))
            {
                rating = "3";
            }
            else if (Convert.ToBoolean(good.IsChecked))
            {
                rating = "4";
            }
            else if (Convert.ToBoolean(excellent.IsChecked))
            {
                rating = "5";
            }

            comment = commentTxt.Text;

            url = "http://cs.ashesi.edu.gh/~csashesi/class2016/fredrick-abayie/mobileweb/bisa_codename1/php/bisa.php?cmd=add_rating&rating="+rating+"&comment="+comment;

            HttpClient client = new HttpClient();
            result = await client.GetStringAsync(url);

            JObject jObject = JObject.Parse(result);

           

            MessageDialog messageDialog = new MessageDialog("App rated");
            await messageDialog.ShowAsync();

            commentTxt.Text = "";
        }

        //Button to load another page to view the results
        private void resultPage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPage1), null);
            //NavigationService.Navigate(new Uri("/Results.xaml", UriKind.Relative));
        }
    }

}
