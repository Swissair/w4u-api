
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

    public class ReservationSettings{
        public int MinDaysOfStay { get; set; }

        public DateTime[] DatesUnavailable { get; set; }
    }
}