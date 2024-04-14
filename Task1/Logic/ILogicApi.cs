using Data;
using Logic.Implementation;

namespace Logic;

public interface ILogicApi
{
    public static ILogicApi CreateApplicationLogic(IDataApi api)
    {
        return new ApplicationLogic(api); // use DI pattern to insert api
    }

    public void RentBook(IBook book, IUser user, int quantity = 1);
    public void ReturnBook(IBook book, IUser user, int quantity = 1);
}
