using Service;

namespace Presentation.Model;

internal class User : IUser
{
    public IServiceApi ServiceApi { get; set; }
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public User()
    {
    }

    public User(IServiceApi serviceApi, int uid, string fName, string lName)
    {
        UserId = uid;
        FirstName = fName;
        LastName = lName;
        ServiceApi = serviceApi;
    }

    public void Add()
    {
        ServiceApi.AddUser(UserId, FirstName, LastName);
    }

    public void Remove()
    {
        ServiceApi.RemoveUser(UserId);
    }

    public void Update()
    {
        var user = ServiceApi.GetUser(UserId);
        user.FirstName = FirstName;
        user.LastName = LastName;
    }
}
