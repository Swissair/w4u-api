
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

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
       var reservationSettings = new ReservationSettings{
        MinDaysOfStay = 5,
        DatesUnavailable = [DateTime.Now.AddDays(1), DateTime.Now.AddDays(2),  DateTime.Now.AddDays(3),  DateTime.Now.AddDays(4)]
       } ;

       return reservationSettings;
    }

    [HttpPost("enquire")]
    public IActionResult PostEnquire(Enquiry enquire)
    {
        return Ok();
    }


    public class ReservationSettings{
        public int MinDaysOfStay { get; set; }

        public DateTime[] DatesUnavailable { get; set; } = [];
    }

    public class Enquiry
    {
        [Required]
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; } = "";

        public DateRange DateRange { get; set; }
    }

    public class DateRange{
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Key { get; set; } = "selection";
    }
}