using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Presentation.Model;
using Presentation.ViewModel;
using Service;

namespace PresentationTests
{
    [TestClass]
    public class ViewModelTests
    {
        [TestMethod]
        public void AddCommandAddsNewItemToItemsCollection()
        {
            var viewModel = new TestViewModel();

            viewModel.AddCommand.Execute(null);

            Assert.AreEqual(1, viewModel.Items.Count);
        }

        [TestMethod]
        public void RemoveCommandRemovesSelectedItemFromItemsCollection()
        {
            var viewModel = new TestViewModel();
            viewModel.Items.Add(new TestModel());

            viewModel.SelectedItem = viewModel.Items[0];
            viewModel.RemoveCommand.Execute(null);

            Assert.AreEqual(0, viewModel.Items.Count);
        }

        [TestMethod]
        public void UpdateCommandCallsUpdateMethodOfSelectedItem()
        {
            var viewModel = new TestViewModel();
            var selectedItem = new TestModel();
            viewModel.Items.Add(selectedItem);

            viewModel.SelectedItem = selectedItem;
            viewModel.UpdateCommand.Execute(null);

            Assert.IsTrue(selectedItem.UpdateCalled);
        }

        private class TestModel : IModel
        {
            public bool UpdateCalled { get; private set; }
            public IServiceApi ServiceApi { get; set; }

            public void Update()
            {
                UpdateCalled = true;
            }

            public void Remove()
            {

            }

            public void Add()
            {

            }
        }

        private class TestViewModel : ViewModel<TestModel>
        {
            public TestViewModel()
            {
                Items = new System.Collections.ObjectModel.ObservableCollection<TestModel>();
            }
        }
    }
}
