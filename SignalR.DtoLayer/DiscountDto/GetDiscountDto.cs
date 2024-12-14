using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.DiscountDto
{
    public class GetDiscountDto
    {
        public int DiscontId { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public string DiscountImgUrl { get; set; }
    }
}
