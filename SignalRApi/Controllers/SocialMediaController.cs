using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;



       
        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            _socialMediaService.TAdd(new SocialMedia()
            {
               Title = createSocialMediaDto.Title,
               Icon = createSocialMediaDto.Icon,
               Url = createSocialMediaDto.Url,
            });
            return Ok("Sosyal Medya Bilgisi Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {
            var values = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(values);
            return Ok("Sosyal Medya Bilgisi Silindi");
        }
        [HttpGet("GetSocialMedia")]
        public IActionResult GetSocialMedia(int id)
        {
            var values = _socialMediaService.TGetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMedia updateSocialMedia)
        {
            _socialMediaService.TUpdate(new SocialMedia()
            {
                SocialMediaId = updateSocialMedia.SocialMediaId,
                Title = updateSocialMedia.Title,
                Icon = updateSocialMedia.Icon,
                Url = updateSocialMedia.Url,

            });
            return Ok("Sosyal Medya Bilgisi Güncellendi");
        }
    }
}
