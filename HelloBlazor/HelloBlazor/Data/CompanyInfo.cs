namespace HelloBlazor.Data;

public sealed record CompanyInfo{
	public required string CompanyName { get; init; }
	public required string Street { get; init; }
	public required string PostalCode { get; init; }
	public required string City { get; init; }
	public required string Country { get; init; }
	public required string Representative { get; init; }
	public required string Phone { get; init; }
	public required string Email { get; init; }
	public required string CommercialRegisterNumber { get; init; }
	public required string VatId { get; init; }
}