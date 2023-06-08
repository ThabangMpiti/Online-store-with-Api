namespace store2.Models
{
    public class products
    {
        public int ORDER_ID { get; set; }
        public string PRODUCT_NAME { get; set; }
        public decimal TOTAL_PRICE { get; set; }
        public int QUANTITY { get; set; }
        public string ORDER_STATUS { get; set; }
        public DateTime CREATED_DATE { get; set; }


    }
}
