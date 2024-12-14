using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.TestimonialDto
{
    public class GetTestimonialDto
    {
        public int TestimonialId { get; set; }
        public string TestimonialName { get; set; }
        public string TestimonialTitle { get; set; }
        public string TestimonialCommand { get; set; }
        public string TestimonialImgUrl { get; set; }
        public bool TestimonialStatus { get; set; }
    }
}
