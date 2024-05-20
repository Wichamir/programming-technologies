namespace Presentation.Model;

public class Reader : IUser
{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Reader() { }

    public Reader(int uid, string fName, string lName)
    {
        UserId = uid;
        FirstName = fName;
        LastName = lName;
    }
}
