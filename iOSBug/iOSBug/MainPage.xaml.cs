using iOSBug.ViewModel;
using Xamarin.Forms;

namespace iOSBug
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            this.BindingContext = new MainViewModel();
            InitializeComponent();
        }
    }
}
