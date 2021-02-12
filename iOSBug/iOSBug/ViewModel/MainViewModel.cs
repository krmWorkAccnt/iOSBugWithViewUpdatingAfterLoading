using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace iOSBug.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        bool isVisible;
        ObservableRangeCollection<TestObject> results;

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
            Task.Run(async () =>
            {
                await SearchAsync();
            });

        }

        protected async Task SearchAsync()
        {
            Results = new ObservableRangeCollection<TestObject>(await GetData());
            IsVisible = true;
        }

        private async Task<ObservableRangeCollection<TestObject>> GetData()
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
