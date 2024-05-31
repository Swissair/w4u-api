using System.ComponentModel.DataAnnotations;

namespace Wakacje4U.Api.Database;

public class Reservation : BaseEntity
{
    public Reservation()
    {
    }

    public Reservation(Customer customer, DateTime startDate, DateTime endDate)
    {
        this.Customer = customer;
        this.StartDate =startDate;
        this.EndDate = endDate;
    }

    public int CustomerId { get; set; }
    public Customer Customer {get;set;}
    public DateTime StartDate {get;set;}
    public DateTime EndDate {get;set;}
}

 public abstract class BaseEntity
 {
    [Key]
     public int Id { get; set; }
 }