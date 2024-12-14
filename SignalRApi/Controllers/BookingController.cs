using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        { 
            Booking booking = new Booking()
            {
                BookingName = createBookingDto.BookingName,
                Date = createBookingDto.Date,
                Mail = createBookingDto.Mail,
                PersonCount = createBookingDto.PersonCount,
                Phone = createBookingDto.Phone,
            };
            _bookingService.TAdd(booking);
            return Ok("Rezervasyon Yapıldı");
        }
        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            var values = _bookingService.TGetById(id);
            _bookingService.TDelete(values);
            return Ok("Rezervasyon İptal Edildi");
        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                BookingId = updateBookingDto.BookingId,
                BookingName = updateBookingDto.BookingName,
                Date = updateBookingDto.Date,
                Mail = updateBookingDto.Mail,
                PersonCount = updateBookingDto.PersonCount,
                Phone = updateBookingDto.Phone,
            };
            _bookingService.TUpdate(booking);
            return Ok("Rezervasyon Güncellendi");
        }
        [HttpGet("GetBooking")]
        public IActionResult GetBooking(int id)
        {
            var values = _bookingService.TGetById(id);
            return Ok(values);
        }
    }
}
