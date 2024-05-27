using Presentation.Model;
using Service;

namespace PresentationTests
{
    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void TestIUserModel()
        {
            IUser userModel = new UserModel();
            userModel.UserId = 1;
            userModel.FirstName = "John";
            userModel.LastName = "Doe";

            int userId = userModel.UserId;
            string firstName = userModel.FirstName;
            string lastName = userModel.LastName;

            Assert.AreEqual(1, userId);
            Assert.AreEqual("John", firstName);
            Assert.AreEqual("Doe", lastName);
        }

        [TestMethod]
        public void TestIBookModel()
        {
            IBook bookModel = new BookModel();
            bookModel.BookId = 1;
            bookModel.Title = "The Great Gatsby";
            bookModel.Fee = 9.99f;
            bookModel.State = 1;

            int bookId = bookModel.BookId;
            string title = bookModel.Title;
            float fee = bookModel.Fee;
            int state = bookModel.State;

            Assert.AreEqual(1, bookId);
            Assert.AreEqual("The Great Gatsby", title);
            Assert.AreEqual(9.99f, fee);
            Assert.AreEqual(1, state);
        }

        [TestMethod]
        public void TestIEventModel()
        {
            IEvent eventModel = new EventModel();
            eventModel.EventId = 1;
            eventModel.UserId = 1;
            eventModel.BookId = 1;

            int eventId = eventModel.EventId;
            int userId = eventModel.UserId;
            int bookId = eventModel.BookId;

            Assert.AreEqual(1, eventId);
            Assert.AreEqual(1, userId);
            Assert.AreEqual(1, bookId);
        }
    }

    public class UserModel : IUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IServiceApi ServiceApi { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }

    public class BookModel : IBook
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public float Fee { get; set; }
        public int State { get; set; }
        public IServiceApi ServiceApi { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }

    public class EventModel : IEvent
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime OccurenceTime { get; set; }
        public IServiceApi ServiceApi { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}