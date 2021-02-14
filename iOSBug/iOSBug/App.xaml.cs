using iOSBug.ViewModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace iOSBug
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainViewModel viewModel = new MainViewModel();

            MainPage page = new MainPage();
            page.BindingContext = viewModel;

            MainPage = page;


            // Here we are simulating use of the navigation service where the service through the InitializeAsync
            // sets the view controls to values from the view model.
            // This isn't an issue when run on Android, however is an issue for iOS.
            // it appears as though once the view has been created and the binding context set to the view model
            // the view isn't updating correctly for iOS when the visibilty setting for the view updates to true after
            // the view's values have been obtained.
            Task.Run(async () => 
            {
                await viewModel.InitializeAsync();
            });            

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
