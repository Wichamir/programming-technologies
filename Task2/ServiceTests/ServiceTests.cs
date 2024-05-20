using Service;
using Data;

namespace ServiceTests
{
    [TestClass]
    public class ServiceTests
    {
        private TestDataService testDataService;

        [TestInitialize]
        public void Initialize()
        {
            testDataService = new TestDataService();
        }

        [TestMethod]
        public void TestAddUser()
        {
            int userId = 1;
            string firstName = "John";
            string lastName = "Doe";

            testDataService.AddUser(userId, firstName, lastName);
            IUser user = testDataService.GetUser(userId);

            Assert.IsNotNull(user);
            Assert.AreEqual(userId, user.UserId);
            Assert.AreEqual(firstName, user.FirstName);
            Assert.AreEqual(lastName, user.LastName);
        }

        [TestMethod]
        public void TestRemoveUser()
        {
            int userId = 1;
            string firstName = "John";
            string lastName = "Doe";
            testDataService.AddUser(userId, firstName, lastName);

            testDataService.RemoveUser(userId);
            IUser user = testDataService.GetUser(userId);

            Assert.IsNull(user);
        }

        [TestMethod]
        public void TestAddEvent()
        {
            int eventId = 1;
            int userId = 1;
            int bookId = 1;
            DateTime occurrenceTime = DateTime.Now;

            testDataService.AddEvent(eventId, userId, bookId, occurrenceTime);
            IEvent evnt = testDataService.GetEvent(eventId);

            Assert.IsNotNull(evnt);
            Assert.AreEqual(eventId, evnt.EventId);
            Assert.AreEqual(userId, evnt.UserId);
            Assert.AreEqual(bookId, evnt.BookId);
        }

        [TestMethod]
        public void TestRemoveEvent()
        {
            int eventId = 1;
            int userId = 1;
            int bookId = 1;
            DateTime occurrenceTime = DateTime.Now;
            testDataService.AddEvent(eventId, userId, bookId, occurrenceTime);

            testDataService.RemoveEvent(eventId);
            IEvent evnt = testDataService.GetEvent(eventId);

            Assert.IsNull(evnt);
        }

        [TestMethod]
        public void TestAddBook()
        {
            int bookId = 1;
            string title = "Book Title";
            int state = 1;
            float fee = 10.99f;

            testDataService.AddBook(bookId, title, state, fee);
            IBook book = testDataService.GetBook(bookId);

            Assert.IsNotNull(book);
            Assert.AreEqual(bookId, book.BookId);
            Assert.AreEqual(title, book.Title);
            Assert.AreEqual(state, book.State);
            Assert.AreEqual(fee, book.Fee);
        }

        [TestMethod]
        public void TestRemoveBook()
        {
            int bookId = 1;
            string title = "Book Title";
            int state = 1;
            float fee = 10.99f;
            testDataService.AddBook(bookId, title, state, fee);

            testDataService.RemoveBook(bookId);
            IBook book = testDataService.GetBook(bookId);

            Assert.IsNull(book);
        }
    }
}