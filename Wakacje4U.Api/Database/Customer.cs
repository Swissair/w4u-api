namespace Wakacje4U.Api.Database;

public class Customer : BaseEntity{ 
    public Customer()
    {
    }

    public Customer(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
 }