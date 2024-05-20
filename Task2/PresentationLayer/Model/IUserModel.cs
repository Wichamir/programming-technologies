namespace Presentation.Model;

public interface IUser
{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set;  }
}
