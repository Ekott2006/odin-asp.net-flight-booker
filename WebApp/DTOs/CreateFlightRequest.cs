using System.ComponentModel;
using WebApp.Model.Enum;

namespace WebApp.DTOs;

public class CreateFlightRequest
{
    [DisplayName("Departure Code")]
    public AirportCode DepartureCode { get; set; }
    [DisplayName("Arrival Code")]
    public AirportCode ArrivalCode { get; set; }
    public DateOnly Date { get; set; }
    [DisplayName("Tickets No.")]
    public int TicketsNumber { get; set; }
}