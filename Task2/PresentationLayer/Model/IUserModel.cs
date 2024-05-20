namespace Presentation.Model;

public interface IUser : IModel
{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
