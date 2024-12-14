using System.ComponentModel.DataAnnotations;

namespace SignalR.EntityLayer.Entities
{
    public class Discount
    {
        [Key]
        public int DiscontId { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public string DiscountImgUrl { get; set; }

    }
}
