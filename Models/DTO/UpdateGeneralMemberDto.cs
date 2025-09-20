namespace Models.DTO
{
	public class UpdateGeneralMemberDto
	{
		public string FirstName { get; set; }
		public string SecondName { get; set; }
		public string LastName { get; set; }
		public string Location { get; set; }
		public string? PhoneNumber { get; set; }
		public bool IsAdministrativeMember { get; set; }
		public string AdministrativePosition { get; set; }
	}
}
