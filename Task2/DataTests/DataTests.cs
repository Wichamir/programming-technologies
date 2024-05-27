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
            string firstName = dataApi.GetUserFirstName(1);
            string lastName = dataApi.GetUserLastName(1);
            Assert.AreEqual("John", firstName);
            Assert.AreEqual("Doe", lastName);

        }

        [TestMethod]
        public void TestEvent()
        {
            string connectionString = GetConnectionString();
            IDataApi dataApi = IDataApi.CreateDataRepository(connectionString);

            // Retrieve the event and check if it exists
            int userId = dataApi.GetEventUserId(1);
            int bookId = dataApi.GetEventBookId(1);
            Assert.AreEqual(1, userId);
            Assert.AreEqual(1, bookId);

        }

        [TestMethod]
        public void TestBook()
        {
            string connectionString = GetConnectionString();
            IDataApi dataApi = IDataApi.CreateDataRepository(connectionString);


            // Retrieve the book and check if it exists
            string title = dataApi.GetBookTitle(1);
            int state = dataApi.GetBookState(1);
            float fee = dataApi.GetBookFee(1);
            Assert.AreEqual("Book Title", title);
            Assert.AreEqual(0, state);
            Assert.AreEqual(9.99f, fee);

        }
    }
}