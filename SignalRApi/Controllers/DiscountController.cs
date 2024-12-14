using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            _discountService.TAdd(new Discount()
            {
                Amount = createDiscountDto.Amount,
                Description = createDiscountDto.Description,
                DiscountImgUrl = createDiscountDto.DiscountImgUrl,
                Title = createDiscountDto.Title,
            });
            return Ok("Discount Bilgisi Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteDiscount(int id)
        {
            var values = _discountService.TGetById(id);
            _discountService.TDelete(values);
            return Ok("Discount Bilgisi Silindi");
        }
        [HttpGet("GetDiscount")]
        public IActionResult GetDiscount(int id)
        {
            var values = _discountService.TGetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            _discountService.TUpdate(new Discount()
            {
                Title = updateDiscountDto.Title,
                Description = updateDiscountDto.Description,
                DiscountImgUrl=updateDiscountDto.DiscountImgUrl,
                Amount = updateDiscountDto.Amount,
                DiscontId = updateDiscountDto.DiscontId,
            });
            return Ok("Discount Bilgisi Güncellendi");
        }
    }
}

