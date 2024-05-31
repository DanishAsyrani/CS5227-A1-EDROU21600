namespace CS5227_A1_EDROU21600.Pages
{
	public class CartItem
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public decimal Subtotal => Quantity * Price;
	}
}
