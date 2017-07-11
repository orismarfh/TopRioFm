using Furacao2000;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;
using Xamarin.Forms;


namespace TopRioFm
{
    public partial class TopRioFmPage : ContentPage
    {
        public TopRioFmPage()
        {
			InitializeComponent();
			BindingContext = new MainViewModel();
        }
    }
}
