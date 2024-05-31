
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Wakacje4U.Api.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Wakacje4U.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationController : ControllerBase
{
     private readonly ILogger<ReservationController> _logger;

    public ReservationController(ILogger<ReservationController> logger)
    {
        _logger = logger;
    }

    [HttpGet("dates/unavailable")]
    public async Task<ReservationSettings> GetUnavailableDates()
    {
        using(var dbContext = new WakacjeDbContext()){
            var reservations = dbContext.Reservations.Include(r => r.Customer).ToList();
        }

        var datesUnavailable = new List<DateTime>();

        var currentDate = new DateTime(2024,6,22);
        while(currentDate < new DateTime(2024, 7,8))
        {
            datesUnavailable.Add(currentDate);
            currentDate = currentDate.AddDays(1);
        }

       var reservationSettings = new ReservationSettings{
        MinDaysOfStay = 5,
        DatesUnavailable = datesUnavailable.ToArray()
       } ;

       return reservationSettings;
    }

    [HttpPost("enquire")]
    public IActionResult PostEnquire(EnquiryDto enquire)
    {
        return Ok();
    }


    public class ReservationSettings{
        public int MinDaysOfStay { get; set; }

        public DateTime[] DatesUnavailable { get; set; } = [];
    }

    public class EnquiryDto
    {
        [Required]
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; } = "";

        public DateRangeDto DateRange { get; set; }
    }

    public class DateRangeDto{
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Key { get; set; } = "selection";
    }
}