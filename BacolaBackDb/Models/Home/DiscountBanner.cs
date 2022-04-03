namespace BacolaBackDb.Models.Home
{
    public class DiscountBanner:BaseEntity
    {
        public string Header { get; set; }
        public string Name { get; set; }
        public string DiscountType { get; set; }
        public string ButtonColor { get; set; }
        public string Image { get; set; }
    }
}
