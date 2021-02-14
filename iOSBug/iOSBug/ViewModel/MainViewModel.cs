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
            //-- Below doesn't work, uncomment the GetData that returns ObservablerangeCollection
            //Results = new ObservableRangeCollection<TestObject>(await GetData());

            // This does work, comment out out GetData that returns IEnumerable to test the above scenario.
            Results.AddRange(await GetData());

            TestText = "Helo World";
            IsVisible = true;
        }

        private async Task<IEnumerable<TestObject>> GetData()
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

        //private async Task<ObservableRangeCollection<TestObject>> GetData()
        //{

        //    return await Task.Run(() =>
        //    {
        //        return new ObservableRangeCollection<TestObject>()
        //        {
        //            {new TestObject(){ Name = "Test One" } },
        //            {new TestObject(){ Name = "Test One" } },
        //            {new TestObject(){ Name = "Test One" } },
        //            {new TestObject(){ Name = "Test One" } },
        //            {new TestObject(){ Name = "Test One" } },
        //            {new TestObject(){ Name = "Test One" } },
        //            {new TestObject(){ Name = "Test One" } },
        //            {new TestObject(){ Name = "Test One" } },
        //            {new TestObject(){ Name = "Test One" } },
        //            {new TestObject(){ Name = "Test One" } },
        //            {new TestObject(){ Name = "Test One" } },
        //            {new TestObject(){ Name = "Test One" } },
        //        };
        //    });

        //}

    }

    public class TestObject
    {
        string name;
        public string Name { get; set; }
    }
}
