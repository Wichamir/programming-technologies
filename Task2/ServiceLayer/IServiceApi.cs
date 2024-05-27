using System;
using System.Collections.Generic;
using System.Linq;
using Data;

namespace Service
{
    public interface IServiceApi
    {
        public static IServiceApi CreateDataService(string connectionString)
        {
            return new DataService(IDataApi.CreateDataRepository(connectionString));
        }

        void AddUser(int userId, string firstName, string lastName);
        void RemoveUser(int userId);
        void UpdateUser(int userId, string firstName, string lastName);

        void AddEvent(int eventId, int userId, int bookId, DateTime occurrenceTime);
        void RemoveEvent(int eventId);
        void UpdateEvent(int eventId, int userId, int bookId, DateTime occurrenceTime);

        void AddBook(int bookId, string title, int state, float fee = 0f);
        void RemoveBook(int bookId);
        void UpdateBook(int bookId, string title, int state, float fee);

        string GetUserFirstName(int userId);
        string GetUserLastName(int userId);

        int GetEventUserId(int eventId);
        int GetEventBookId(int eventId);
        DateTime GetOccuranceTime(int eventId);

        string GetBookTitle(int bookId);
        float GetBookFee(int bookId);
        int GetBookState(int bookId);
    }
}
