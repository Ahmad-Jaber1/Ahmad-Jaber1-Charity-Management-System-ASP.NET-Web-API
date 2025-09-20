namespace Models.DTO
{
	public class GetReceiptDto
	{
		public int ReceiptNO { get; set; }
		public int Value { get; set; }
		public int Year { get; set; }
		public int Month { get; set; }
		public DateOnly? PaidDate { get; set; }
		public int BasicMemberId { get; set; }
	}
}
