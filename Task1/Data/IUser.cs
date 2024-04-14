namespace Data;

public interface IUser
{
    public int UserId { get; }
    public string FirstName { get; set; }
    public string LastName { get; set;  }
}
