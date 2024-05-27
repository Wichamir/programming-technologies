using Service;

namespace ServiceTests
{
    [TestClass]
    public class ServiceTests
    {
        private IServiceApi testDataService;

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
            string userFirstName = testDataService.GetUserFirstName(userId);
            string userLastName = testDataService.GetUserLastName(userId);

            Assert.AreEqual(firstName, userFirstName);
            Assert.AreEqual(lastName, userLastName);
        }

        [TestMethod]
        public void TestRemoveUser()
        {
            int userId = 1;
            string firstName = "John";
            string lastName = "Doe";
            testDataService.AddUser(userId, firstName, lastName);

            testDataService.RemoveUser(userId);
            string userFirstName = testDataService.GetUserFirstName(userId);
            string userLastName = testDataService.GetUserLastName(userId);

            Assert.AreEqual("", userFirstName);
            Assert.AreEqual("", userLastName);
        }

        [TestMethod]
        public void TestAddEvent()
        {
            int eventId = 1;
            int userId = 1;
            int bookId = 1;
            DateTime occurrenceTime = DateTime.Now;

            testDataService.AddEvent(eventId, userId, bookId, occurrenceTime);
            int eventUserId = testDataService.GetEventUserId(eventId);
            int eventBookId = testDataService.GetEventBookId(eventId);
            DateTime eventOccurrenceTime = testDataService.GetOccuranceTime(eventId);

            Assert.AreEqual(userId, eventUserId);
            Assert.AreEqual(bookId, eventBookId);
            Assert.AreEqual(occurrenceTime, eventOccurrenceTime);
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
            int eventUserId = testDataService.GetEventUserId(eventId);
            int eventBookId = testDataService.GetEventBookId(eventId);
            DateTime eventOccurrenceTime = testDataService.GetOccuranceTime(eventId);

            Assert.AreEqual(0, eventUserId);
            Assert.AreEqual(0, eventBookId);
            Assert.AreEqual(default(DateTime), eventOccurrenceTime);
        }

        [TestMethod]
        public void TestAddBook()
        {
            int bookId = 1;
            string title = "Book Title";
            int state = 1;
            float fee = 10.99f;

            testDataService.AddBook(bookId, title, state, fee);
            string bookTitle = testDataService.GetBookTitle(bookId);
            float bookFee = testDataService.GetBookFee(bookId);
            int bookState = testDataService.GetBookState(bookId);

            Assert.AreEqual(title, bookTitle);
            Assert.AreEqual(fee, bookFee);
            Assert.AreEqual(state, bookState);
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
            string bookTitle = testDataService.GetBookTitle(bookId);
            float bookFee = testDataService.GetBookFee(bookId);
            int bookState = testDataService.GetBookState(bookId);

            Assert.AreEqual("", bookTitle);
            Assert.AreEqual(0, bookFee);
            Assert.AreEqual(0, bookState);
        }
    }
}