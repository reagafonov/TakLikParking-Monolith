namespace Services.Contracts.Models;

public class GetBookingsResponseModel
{
    public IEnumerable<BookingModel> Data { get; set; }
    public int Count => Data.Count();
}