using Kiri.Api.Services;
using Kiri.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Kiri.Api.Endpoints;

public static class Endpoints
{
    public static void UseEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/shorten", (
            ShortenUrlRequest req,
            IUrlShortenerService shortenerService) =>
        {
            if (!Uri.TryCreate(req.Url, UriKind.Absolute, out _))
                return Results.BadRequest("Invalid URL");

            return Results.Ok("todo: shorten url");
        });
    }
}
