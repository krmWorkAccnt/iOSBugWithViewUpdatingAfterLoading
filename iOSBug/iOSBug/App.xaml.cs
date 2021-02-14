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


            // Setting up a scenario that acts like assigning the view model to view using a navigation service
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
