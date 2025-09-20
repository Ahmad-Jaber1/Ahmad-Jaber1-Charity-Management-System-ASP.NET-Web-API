namespace Models.DTO
{
	public class UpdateReceiptDto
	{
		public int Value { get; set; }
		public int Year { get; set; }
		public int Month { get; set; }
		public DateOnly? PaidDate { get; set; }
		public int BasicMemberId { get; set; }
	}
}
