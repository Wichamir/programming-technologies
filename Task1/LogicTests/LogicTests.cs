using System;
using System.Collections;
using Data;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicTests;

[TestClass]
public class LogicTests
{
    private Random random = new();
    
    [TestMethod]
    public void TestRent()
    {
        var dataApi = IDataApi.CreateDataRepository();
        var logicApi = ILogicApi.CreateApplicationLogic(dataApi);
        
        var time = DateTime.Now;
        
        dataApi.AddBook(0, "Solaris");
        dataApi.AddUser(0, "John", "Carmack");

        var book = dataApi.GetBook(0);
        var user = dataApi.GetUser(0);
        var @event = dataApi.GetEvent(0);
        
        dataApi.UpdateState(0, 5);
        
        logicApi.RentBook(book, user, 1);
        
        Assert.AreEqual(dataApi.GetEvent(0).BookId, 0);
        Assert.AreEqual(dataApi.GetEvent(0).UserId, 0);
        Assert.AreEqual(dataApi.GetState(0).Quantity, 4);
    }
    
    [TestMethod]
    public void TestReturn()
    {
        var dataApi = IDataApi.CreateDataRepository();
        var logicApi = ILogicApi.CreateApplicationLogic(dataApi);
        
        var time = DateTime.Now;
        
        dataApi.AddBook(0, "Solaris");
        dataApi.AddUser(0, "John", "Carmack");

        var book = dataApi.GetBook(0);
        var user = dataApi.GetUser(0);
        var @event = dataApi.GetEvent(0);
        
        dataApi.UpdateState(0, 5);
        
        logicApi.ReturnBook(book, user, 1);
        
        Assert.AreEqual(dataApi.GetEvent(0).BookId, 0);
        Assert.AreEqual(dataApi.GetEvent(0).UserId, 0);
        Assert.AreEqual(dataApi.GetState(0).Quantity, 6);
    }
    
    [TestMethod]
    public void TestRandomRent()
    {
        var dataApi = IDataApi.CreateDataRepository();
        var logicApi = ILogicApi.CreateApplicationLogic(dataApi);
        
        int bookId = random.Next();
        string bookTitle = "Book" + random.Next(1000);
        int userId = random.Next();
        string firstName = "User" + random.Next(1000);
        string lastName = "Random" + random.Next(1000);

        dataApi.AddBook(bookId, bookTitle);
        dataApi.AddUser(userId, firstName, lastName);

        var book = dataApi.GetBook(bookId);
        var user = dataApi.GetUser(userId);
        int initialQuantity = random.Next(1, 10);
        
        dataApi.UpdateState(bookId, initialQuantity);

        logicApi.RentBook(book, user, 1);

        Assert.AreEqual(dataApi.GetEvent(0).BookId, bookId);
        Assert.AreEqual(dataApi.GetEvent(0).UserId, userId);
        Assert.AreEqual(dataApi.GetState(bookId).Quantity, initialQuantity - 1);
    }

    [TestMethod]
    public void TestRandomReturn()
    {
        var dataApi = IDataApi.CreateDataRepository();
        var logicApi = ILogicApi.CreateApplicationLogic(dataApi);
        
        int bookId = random.Next();
        string bookTitle = "Book" + random.Next(1000);
        int userId = random.Next();
        string firstName = "User" + random.Next(1000);
        string lastName = "Random" + random.Next(1000);

        dataApi.AddBook(bookId, bookTitle);
        dataApi.AddUser(userId, firstName, lastName);

        var book = dataApi.GetBook(bookId);
        var user = dataApi.GetUser(userId);

        int initialQuantity = random.Next(1, 10);
        dataApi.UpdateState(bookId, initialQuantity);

        logicApi.ReturnBook(book, user, 1);

        Assert.AreEqual(dataApi.GetEvent(0).BookId, bookId);
        Assert.AreEqual(dataApi.GetEvent(0).UserId, userId);
        Assert.AreEqual(dataApi.GetState(bookId).Quantity, initialQuantity + 1);
    }

}
