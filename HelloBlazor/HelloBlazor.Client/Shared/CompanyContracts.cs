namespace HelloBlazor.Client.Shared;

public record CompanyInfoResponse(
	string CompanyName,
	string Street,
	string PostalCode,
	string City,
	string Country,
	string Representative,
	string Phone,
	string Email,
	string CommercialRegisterNumber,
	string VatId);
