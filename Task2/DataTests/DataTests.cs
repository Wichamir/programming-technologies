using Data;

namespace DataTests
{
    [TestClass]
    public class DataTests
    {
        public string GetConnectionString()
        {
            string RPath = @"Database.mdf";
            string RootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string DatabasePath = Path.Combine(RootPath, RPath);
            return $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={DatabasePath};Integrated Security = True;";
        }

        [TestMethod]
        public void TestDatabaseConnection()
        {
            string connectionString = GetConnectionString();
            IDataApi dataApi = IDataApi.CreateDataRepository(connectionString);
            Assert.IsNotNull(dataApi);
        }

        [TestMethod]
        public void TestUser()
        {
            string connectionString = GetConnectionString();
            IDataApi dataApi = IDataApi.CreateDataRepository(connectionString);

            // Retrieve the user and check if it exists
            IUser user = dataApi.GetUser(1);
            Assert.IsNotNull(user);
            Assert.AreEqual("John", user.FirstName);
            Assert.AreEqual("Doe", user.LastName);
        }

        [TestMethod]
        public void TestEvent()
        {
            string connectionString = GetConnectionString();
            IDataApi dataApi = IDataApi.CreateDataRepository(connectionString);

            // Retrieve the event and check if it exists
            IEvent evnt = dataApi.GetEvent(1);
            Assert.IsNotNull(evnt);
            Assert.AreEqual(1, evnt.EventId);
            Assert.AreEqual(1, evnt.UserId);
            Assert.AreEqual(1, evnt.BookId);
        }

        [TestMethod]
        public void TestBook()
        {
            string connectionString = GetConnectionString();
            IDataApi dataApi = IDataApi.CreateDataRepository(connectionString);

            // Retrieve the book and check if it exists
            IBook book = dataApi.GetBook(1);
            Assert.IsNotNull(book);
            Assert.AreEqual("Book Title", book.Title);
            Assert.AreEqual(0, book.State);
            Assert.AreEqual(9.99f, book.Fee);
        }
    }
}