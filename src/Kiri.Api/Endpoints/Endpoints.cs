using Kiri.Api.Models;
using Kiri.Api.Repositories;
using Kiri.Api.Services;
using Kiri.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Kiri.Api.Endpoints;

public static class Endpoints
{
    public static void UseEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/shorten", async (
            [FromBody] ShortenUrlRequest req,
            HttpContext ctx,
            [FromServices] IUrlShortenerService shortenerService) =>
        {
            if (!Uri.TryCreate(req.Url, UriKind.Absolute, out _))
                return Results.BadRequest("Invalid URL");

            var code = await shortenerService.ShortenAsync(req.Url);

            var url = $"{ctx.Request.Scheme}://{ctx.Request.Host}/{code}";
            return Results.Ok(new ShortenUrlResponse(url));
        });

        app.MapGet("/{code}", async (
            string code,
            [FromServices] IShortenedUrlRepo shortenedUrlRepo) =>
        {
            if (await shortenedUrlRepo.GetByCodeAsync(code)
                    is not ShortenedUrl shortenedUrl)
                return Results.NotFound();

            return Results.Redirect(shortenedUrl.LongUrl);
        });
    }
}
