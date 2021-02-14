using MvvmHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iOSBug.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        bool isVisible;
        ObservableRangeCollection<TestObject> results;
        string testText;

        public string TestText
        {
            get => testText;
            set => SetProperty(ref testText, value);
        }

        public ObservableRangeCollection<TestObject> Results
        {
            get => results;
            set => SetProperty(ref results, value);
        }

        public bool IsVisible
        {
            get => isVisible;
            set => SetProperty(ref isVisible, value);
        }

        public MainViewModel()
        {
            IsVisible = false;
            Results = new ObservableRangeCollection<TestObject>();
        }

        public async Task InitializeAsync()
        {
            await SearchAsync();

        }

        protected async Task SearchAsync()
        {
            // Scenario one
            // Below doesn't work
            Results = new ObservableRangeCollection<TestObject>(await GetData1());

            // Scenario two
            // This does work, comment out out the above call that sets Results and uncomment below
            //Results.AddRange(await GetData2());

            TestText = "Helo World";
            IsVisible = true;
        }

        private async Task<ObservableRangeCollection<TestObject>> GetData1()
        {

            return await Task.Run(() =>
            {
                return new ObservableRangeCollection<TestObject>()
                {
                    {new TestObject(){ Name = "Test One" } },
                    {new TestObject(){ Name = "Test One" } },
                    {new TestObject(){ Name = "Test One" } },
                    {new TestObject(){ Name = "Test One" } },
                    {new TestObject(){ Name = "Test One" } },
                    {new TestObject(){ Name = "Test One" } },
                    {new TestObject(){ Name = "Test One" } },
                    {new TestObject(){ Name = "Test One" } },
                    {new TestObject(){ Name = "Test One" } },
                    {new TestObject(){ Name = "Test One" } },
                    {new TestObject(){ Name = "Test One" } },
                    {new TestObject(){ Name = "Test One" } },
                };
            });

        }

        private async Task<IEnumerable<TestObject>> GetData2()
        {

            return await Task.Run(() =>
            {
                return new ObservableRangeCollection<TestObject>()
                {
                    {new TestObject(){ Name = "Test One" } },
                    {new TestObject(){ Name = "Test One" } },
                    {new TestObject(){ Name = "Test One" } },
                    {new TestObject(){ Name = "Test One" } },
                    {new TestObject(){ Name = "Test One" } },
                    {new TestObject(){ Name = "Test One" } },
                    {new TestObject(){ Name = "Test One" } },
                    {new TestObject(){ Name = "Test One" } },
                    {new TestObject(){ Name = "Test One" } },
                    {new TestObject(){ Name = "Test One" } },
                    {new TestObject(){ Name = "Test One" } },
                    {new TestObject(){ Name = "Test One" } },
                };
            });

        }

    }

    public class TestObject
    {
        string name;
        public string Name { get; set; }
    }
}
