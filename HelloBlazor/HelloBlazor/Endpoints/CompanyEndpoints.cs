using HelloBlazor.Client.Shared;
using HelloBlazor.Data;

namespace HelloBlazor.Endpoints;

public static class CompanyEndpoints
{
	public static void MapCompanyEndpoints(this IEndpointRouteBuilder app)
	{
		app.MapGet("/api/company", async (UserDatabase db) =>
		{
			var company = await db.GetCompanyInfoAsync();

			return Results.Ok(new CompanyInfoResponse(
				company.CompanyName,
				company.Street,
				company.PostalCode,
				company.City,
				company.Country,
				company.Representative,
				company.Phone,
				company.Email,
				company.CommercialRegisterNumber,
				company.VatId));
		});
	}
}
