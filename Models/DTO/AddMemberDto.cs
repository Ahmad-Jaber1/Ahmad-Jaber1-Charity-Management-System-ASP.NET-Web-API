namespace Models.DTO
{
	public class AddMemberDto
	{
		public string Id { get; set; }
		public string FirstName { get; set; }
		public string SecondName { get; set; }
		public string LastName { get; set; }
		public string Location { get; set; }
		public string? PhoneNumber { get; set; }
		public bool IsMembershipPaid { get; set; }
		public int? ReceiptNO { get; set; }
	}
}
