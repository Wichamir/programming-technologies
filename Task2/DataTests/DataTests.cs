using Data;

namespace DataTests
{
    [TestClass]
    [DeploymentItem(@"Database.mdf", "@Database.mdf")]
    public class DataTests
    {
        private static string m_ConnectionString;

        [ClassInitialize]
        public static void ClassInitializeMethod(TestContext context)
        {
            
            string _DBRelativePath = @"Database.mdf";
            string _TestingWorkingFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string _DBPath = Path.Combine(_TestingWorkingFolder, _DBRelativePath);
            m_ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_DBPath};Integrated Security = True; Connect Timeout = 30;";
        }

        [TestMethod]
        public void TestDatabaseConnection()
        {
            string connectionString = m_ConnectionString;
            IDataApi dataApi = IDataApi.CreateDataRepository(connectionString);
            Assert.IsNotNull(dataApi);
        }

        [TestMethod]
        public void TestUser()
        {
            string connectionString = m_ConnectionString;
            IDataApi dataApi = IDataApi.CreateDataRepository(connectionString);

            string firstName = dataApi.GetUserFirstName(1);
            string lastName = dataApi.GetUserLastName(1);
            Assert.AreEqual("John", firstName);
            Assert.AreEqual("Doe", lastName);

        }

        [TestMethod]
        public void TestEvent()
        {
            string connectionString = m_ConnectionString;
            IDataApi dataApi = IDataApi.CreateDataRepository(connectionString);

            int userId = dataApi.GetEventUserId(1);
            int bookId = dataApi.GetEventBookId(1);
            Assert.AreEqual(1, userId);
            Assert.AreEqual(1, bookId);

        }

        [TestMethod]
        public void TestBook()
        {
            string connectionString = m_ConnectionString;
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