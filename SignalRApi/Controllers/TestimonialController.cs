using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

       

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService.TAdd(new Testimonial()
            {
               TestimonialCommand= createTestimonialDto.TestimonialCommand,
               TestimonialImgUrl = createTestimonialDto.TestimonialTitle,
               TestimonialTitle = createTestimonialDto.TestimonialTitle,
               TestimonialName = createTestimonialDto.TestimonialTitle,
               TestimonialStatus = createTestimonialDto.TestimonialStatus
            });
            return Ok("Müşteri Yorum Bilgisi Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var values = _testimonialService.TGetById(id);
            _testimonialService.TDelete(values);
            return Ok("Müşteri Yorum Bilgisi Silindi");
        }
        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var values = _testimonialService.TGetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService.TUpdate(new Testimonial()
            {
                TestimonialId = updateTestimonialDto.TestimonialId,
                TestimonialCommand = updateTestimonialDto.TestimonialCommand,
                TestimonialImgUrl = updateTestimonialDto.TestimonialTitle,
                TestimonialTitle = updateTestimonialDto.TestimonialTitle,
                TestimonialName = updateTestimonialDto.TestimonialTitle,
                TestimonialStatus = updateTestimonialDto.TestimonialStatus

            });
            return Ok("Müşteri Yorum Bilgisi Bilgisi Güncellendi");
        }
    }
}
