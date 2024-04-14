using Data;

namespace Logic.Implementation;

internal class ApplicationLogic : ILogicApi
{
    private IDataApi api;

    public ApplicationLogic(IDataApi api)
    {
        this.api = api;
    }

    public void RentBook(IBook book, IUser user, int quantity = 1)
    {
        var updatedQuantity = api.GetState(book.BookId).Quantity - quantity;
        
        if (updatedQuantity < 0)
        {
            throw new Exception("Tried to rent more books than available quantity.");
        }
        
        api.UpdateState(book.BookId, updatedQuantity);
        api.AddEvent(0, user.UserId, book.BookId, IDataApi.EventMode.Rent, DateTime.Now);
    }

    public void ReturnBook(IBook book, IUser user, int quantity = 1)
    {
        api.UpdateState(book.BookId, api.GetState(book.BookId).Quantity + quantity);
        api.AddEvent(0, user.UserId, book.BookId, IDataApi.EventMode.Return, DateTime.Now);
    }
}
