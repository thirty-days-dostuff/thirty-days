using HelloBlazor.Client.Shared;
using HelloBlazor.Data;

namespace HelloBlazor.Endpoints;

public static class CompanyEndpoints
{
	public static void MapCompanyEndpoints(this IEndpointRouteBuilder app)
	{
		app.MapGet("/api/company", (CompanyInfo companyInfo) => Results.Ok(
			new CompanyInfoResponse(
			companyInfo.CompanyName,
			companyInfo.Street,
			companyInfo.PostalCode,
			companyInfo.City,
			companyInfo.Country,
			companyInfo.Representative,
			companyInfo.Phone,
			companyInfo.Email,
			companyInfo.CommercialRegisterNumber,
			companyInfo.VatId)));
	}
}
