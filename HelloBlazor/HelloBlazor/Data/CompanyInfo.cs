using SQLite;

namespace HelloBlazor.Data;

public class CompanyInfo
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }

	public string CompanyName { get; set; } = string.Empty;

	public string Street { get; set; } = string.Empty;

	public string PostalCode { get; set; } = string.Empty;

	public string City { get; set; } = string.Empty;

	public string Country { get; set; } = string.Empty;

	public string Representative { get; set; } = string.Empty;

	public string Phone { get; set; } = string.Empty;

	public string Email { get; set; } = string.Empty;

	public string CommercialRegisterNumber { get; set; } = string.Empty;

	public string VatId { get; set; } = string.Empty;
}
