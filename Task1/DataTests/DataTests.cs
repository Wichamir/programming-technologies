using System;
using System.Reflection;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataTests;

[TestClass]
public class DataTests
{
    private static Random random = new Random();
    
    [TestMethod]
    public void TestUser()
    {
        var api = IDataApi.CreateDataRepository();
        
        api.AddUser(0, "John", "Doe");
        api.AddUser(1, "Mary", "Jane");

        Assert.AreEqual(api.GetUser(0).UserId, 0);
        Assert.AreEqual(api.GetUser(0).FirstName, "John");
        Assert.AreEqual(api.GetUser(0).LastName, "Doe");
        
        Assert.AreEqual(api.GetUser(1).UserId, 1);
        Assert.AreEqual(api.GetUser(1).FirstName, "Mary");
        Assert.AreEqual(api.GetUser(1).LastName, "Jane");
    }

    [TestMethod]
    public void TestEvent()
    {
        var api = IDataApi.CreateDataRepository();

        var time = DateTime.Now;
        
        api.AddEvent(0, 0, 0, IDataApi.EventMode.Rent, time);
        api.AddEvent(1, 0, 0, IDataApi.EventMode.Return, time);

        Assert.AreEqual(api.GetEvent(0).EventId, 0);
        Assert.AreEqual(api.GetEvent(0).UserId, 0);
        Assert.AreEqual(api.GetEvent(0).BookId, 0);
        Assert.AreEqual(api.GetEvent(0).OccurenceTime, time);
        
        Assert.AreEqual(api.GetEvent(1).EventId, 1);
        Assert.AreEqual(api.GetEvent(1).UserId, 0);
        Assert.AreEqual(api.GetEvent(1).BookId, 0);
        Assert.AreEqual(api.GetEvent(1).OccurenceTime, time);
    }

    [TestMethod]
    public void TestBook()
    {
        var api = IDataApi.CreateDataRepository();
        
        api.AddBook(0, "1984");
        api.AddBook(1, "The Heart of Darkness", 0f);
        api.AddBook(2, "Trainspotting", 1f);
        
        Assert.AreEqual(api.GetBook(0).BookId, 0);
        Assert.AreEqual(api.GetBook(0).Title, "1984");
        Assert.AreEqual(api.GetBook(0).Fee, 0f);
        
        Assert.AreEqual(api.GetBook(1).BookId, 1);
        Assert.AreEqual(api.GetBook(1).Title, "The Heart of Darkness");
        Assert.AreEqual(api.GetBook(1).Fee, 0f);
        
        Assert.AreEqual(api.GetBook(2).BookId, 2);
        Assert.AreEqual(api.GetBook(2).Title, "Trainspotting");
        Assert.AreEqual(api.GetBook(2).Fee, 1f);
    }

    [TestMethod]
    public void TestState()
    {
        var api = IDataApi.CreateDataRepository();
        
        api.UpdateState(0, 4);
        api.UpdateState(1, 0);
        
        Assert.AreEqual(api.GetState(0).Quantity, 4);
        Assert.AreEqual(api.GetState(1).Quantity, 0);
        Assert.AreEqual(api.GetState(2).Quantity, 0);
    }

    [TestMethod]
    public void TestRandomUser()
    {
        var api = IDataApi.CreateDataRepository();

        // Generate random user data
        int userId1 = random.Next();
        int userId2 = random.Next();
        string firstName1 = "User" + random.Next(1000);
        string lastName1 = "Random" + random.Next(1000);
        string firstName2 = "User" + random.Next(1000);
        string lastName2 = "Random" + random.Next(1000);

        api.AddUser(userId1, firstName1, lastName1);
        api.AddUser(userId2, firstName2, lastName2);

        Assert.AreEqual(api.GetUser(userId1).UserId, userId1);
        Assert.AreEqual(api.GetUser(userId1).FirstName, firstName1);
        Assert.AreEqual(api.GetUser(userId1).LastName, lastName1);

        Assert.AreEqual(api.GetUser(userId2).UserId, userId2);
        Assert.AreEqual(api.GetUser(userId2).FirstName, firstName2);
        Assert.AreEqual(api.GetUser(userId2).LastName, lastName2);
    }

    [TestMethod]
    public void TestRandomEvent()
    {
        var api = IDataApi.CreateDataRepository();

        // Generate random event data
        int eventId1 = random.Next();
        int eventId2 = random.Next();
        int userId = random.Next();
        int bookId = random.Next();
        DateTime time = DateTime.Now;

        api.AddEvent(eventId1, userId, bookId, IDataApi.EventMode.Rent, time);
        api.AddEvent(eventId2, userId, bookId, IDataApi.EventMode.Return, time);

        Assert.AreEqual(api.GetEvent(eventId1).EventId, eventId1);
        Assert.AreEqual(api.GetEvent(eventId1).UserId, userId);
        Assert.AreEqual(api.GetEvent(eventId1).BookId, bookId);
        Assert.AreEqual(api.GetEvent(eventId1).OccurenceTime, time);

        Assert.AreEqual(api.GetEvent(eventId2).EventId, eventId2);
        Assert.AreEqual(api.GetEvent(eventId2).UserId, userId);
        Assert.AreEqual(api.GetEvent(eventId2).BookId, bookId);
        Assert.AreEqual(api.GetEvent(eventId2).OccurenceTime, time);
    }

    [TestMethod]
    public void TestRandomBook()
    {
        var api = IDataApi.CreateDataRepository();

        // Generate random book data
        int bookId1 = random.Next();
        int bookId2 = random.Next();
        string title1 = "Book" + random.Next(1000);
        string title2 = "Book" + random.Next(1000);
        float fee1 = (float)random.NextDouble() * 100;
        float fee2 = (float)random.NextDouble() * 100;

        api.AddBook(bookId1, title1, fee1);
        api.AddBook(bookId2, title2, fee2);

        Assert.AreEqual(api.GetBook(bookId1).BookId, bookId1);
        Assert.AreEqual(api.GetBook(bookId1).Title, title1);
        Assert.AreEqual(api.GetBook(bookId1).Fee, fee1);

        Assert.AreEqual(api.GetBook(bookId2).BookId, bookId2);
        Assert.AreEqual(api.GetBook(bookId2).Title, title2);
        Assert.AreEqual(api.GetBook(bookId2).Fee, fee2);
    }

    [TestMethod]
    public void TestRandomState()
    {
        var api = IDataApi.CreateDataRepository();

        // Generate random state data
        int bookId1 = random.Next();
        int bookId2 = random.Next();
        int quantity1 = random.Next();
        int quantity2 = random.Next();

        api.UpdateState(bookId1, quantity1);
        api.UpdateState(bookId2, quantity2);

        Assert.AreEqual(api.GetState(bookId1).BookId, bookId1);
        Assert.AreEqual(api.GetState(bookId1).Quantity, quantity1);

        Assert.AreEqual(api.GetState(bookId2).BookId, bookId2);
        Assert.AreEqual(api.GetState(bookId2).Quantity, quantity2);
    }

}