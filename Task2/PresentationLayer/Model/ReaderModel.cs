namespace Presentation.Model;

internal class Reader : IUser
{
    public int UserId { get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Reader(int uid, string fName, string lName)
    {
        UserId = uid;
        FirstName = fName;
        LastName = lName;
    }
}
