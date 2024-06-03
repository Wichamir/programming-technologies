using Presentation.Model;
using Presentation.ViewModel;
using System.Text;
using Service;

namespace PresentationTests
{
    [TestClass]
    public class ViewModelTests
    {
        [TestMethod]
        public void AddCommandAddsNewItemToItemsCollection()
        {
            var viewModel = new TestViewModel(new TestService());

            viewModel.AddCommand.Execute(null);

            Assert.AreEqual(1, viewModel.Items.Count);
        }

        [TestMethod]
        public void RemoveCommandRemovesSelectedItemFromItemsCollection()
        {
            var viewModel = new TestViewModel(new TestService());
            viewModel.Items.Add(new TestModel());

            viewModel.SelectedItem = viewModel.Items[0];
            viewModel.RemoveCommand.Execute(null);

            Assert.AreEqual(0, viewModel.Items.Count);
        }

        [TestMethod]
        public void UpdateCommandCallsUpdateMethodOfSelectedItem()
        {
            var viewModel = new TestViewModel(new TestService());
            var selectedItem = new TestModel();
            viewModel.Items.Add(selectedItem);

            viewModel.SelectedItem = selectedItem;
            viewModel.UpdateCommand.Execute(null);

            Assert.IsTrue(selectedItem.UpdateCalled);
        }

        [TestMethod]
        public void RandomNumberTest()
        {
            var viewModel = new TestViewModel(new TestService());
            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                var number = random.Next();

                var testModel = new TestModel();
                testModel.Number = number;
                viewModel.Items.Add(testModel);
            }

            Assert.AreEqual(10, viewModel.Items.Count);
        }

        [TestMethod]
        public void RandomCharsTest()
        {
            var viewModel = new TestViewModel(new TestService());
            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                var chars = Guid.NewGuid().ToString();

                var testModel = new TestModel();
                testModel.Chars = chars;
                viewModel.Items.Add(testModel);
            }

            Assert.AreEqual(10, viewModel.Items.Count);
        }

        [TestMethod]
        public void RandomCharsTest2()
        {
            var viewModel = new TestViewModel(new TestService());

            for (int i = 0; i < 10; i++)
            {
                var chars = GetRandomString(10);

                var testModel = new TestModel();
                testModel.Chars = chars;
                viewModel.Items.Add(testModel);
            }

            Assert.AreEqual(10, viewModel.Items.Count);
        }

        private class TestModel : IModel
        {
            public bool UpdateCalled { get; private set; }
            public IServiceApi ServiceApi { get; set; }
            public int Number { get; set; }
            public string Chars { get; set; }

            public void Update()
            {
                UpdateCalled = true;
            }

            public void Remove() {}
            public void Add() {}
        }

        private class TestViewModel : ViewModel<TestModel>
        {
            public TestViewModel(IServiceApi serviceApi) : base(serviceApi)
            {
                Items = new System.Collections.ObjectModel.ObservableCollection<TestModel>();
            }
        }

        private static string GetRandomString(int length)
        {
            var rand = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var builder = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                builder.Append(chars[rand.Next(chars.Length)]);
            }

            return builder.ToString();
        }


    }
}
